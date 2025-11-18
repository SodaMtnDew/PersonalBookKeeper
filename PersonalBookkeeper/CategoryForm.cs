using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalBookKeeper
{
    public partial class CategoryForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        public CategoryForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            parentForm = parent2Set;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            labelTreeView.Text = PersonalBookKeeper.Properties.Resources.strTxtCategories;
            btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddCategory;
            btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModCategory;
            labelCategoryName.Text = PersonalBookKeeper.Properties.Resources.strTxtNameCategory;
            labelCategoryDesc.Text = PersonalBookKeeper.Properties.Resources.strTxtDescription;
            labelCategoryDirect.Text = PersonalBookKeeper.Properties.Resources.strTxtFlowDirect;
            rBtnIncome.Text = PersonalBookKeeper.Properties.Resources.strTxtIncome;
            rBtnTransfer.Text = PersonalBookKeeper.Properties.Resources.strTxtTransfer;
            rBtnOutcome.Text = PersonalBookKeeper.Properties.Resources.strTxtOutcome;
            RefreshCategoryTree();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddCategory)
            {
                string strTmp = "";
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmAdd;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelAdd;
                if (trViewCategories.SelectedNode != null)
                {
                    if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strTxtAddSubCategory, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        strTmp = txtID.Text;
                }
                ClearEditForm();
                if (strTmp != "")
                {
                    txtParentID.Text = strTmp;
                    short sTypeFlag = GetFlowDirect(strTmp);
                    if (sTypeFlag > 0)
                        rBtnIncome.Checked = true;
                    else if (sTypeFlag < 0)
                        rBtnOutcome.Checked = true;
                    else
                        rBtnTransfer.Checked = true;
                }
                SetEditAll(true, (txtID.Text == "") && (txtParentID.Text == ""));
                parentForm.LockTab();
            }
            else
            {
                if (ChkEditForm())
                {
                    SetEditAll(false, true);
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddCategory;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModCategory; ;
                    CommitChange();
                    ClearEditForm();
                    RefreshCategoryTree();
                    parentForm.UnlockTab();
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddCategory)
            {
                if (trViewCategories.SelectedNode == null)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoCategorySelected, PersonalBookKeeper.Properties.Resources.strHintTitle);
                else
                {
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmMod;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelMod;
                    SetEditAll(true, false);
                    parentForm.LockTab();
                }
            }
            else
            {
                SetEditAll(false, true);
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddCategory;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModCategory;
                parentForm.UnlockTab();
                if (trViewCategories.SelectedNode != null)
                    UpdateEditForm();
                else
                    ClearEditForm();
            }
        }

        private void trViewCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trViewCategories.SelectedNode != null)
                UpdateEditForm();
            else
                ClearEditForm();
        }

        private void CategoryForm_SizeChanged(object sender, EventArgs e)
        {
            trViewCategories.Width = this.Width * 5 / 9;
            trViewCategories.Height = this.Height - 12 - trViewCategories.Top;
            btnAdd.Left = trViewCategories.Left + trViewCategories.Width + 6;
            btnMod.Left = btnAdd.Left + btnAdd.Width + 6;
            txtParentID.Left = btnMod.Left + btnMod.Width + 6;
            txtID.Left = txtParentID.Left + txtParentID.Width + 6;
            labelCategoryName.Left = btnAdd.Left;
            txtCategoryName.Left = labelCategoryName.Left + labelCategoryName.Width + 6;
            txtCategoryName.Width = this.Width - 12 - txtCategoryName.Left;
            labelCategoryDesc.Left = btnAdd.Left;
            txtCategoryDesc.Left = labelCategoryDesc.Left + labelCategoryDesc.Width + 6;
            txtCategoryDesc.Width = this.Width - 12 - txtCategoryDesc.Left;
            labelCategoryDirect.Left = btnAdd.Left;
            labelCategoryDirect.Top = this.Height * 2 / 3;
            txtCategoryDesc.Height = labelCategoryDirect.Top - txtCategoryDesc.Top - 6;
            rBtnIncome.Left = labelCategoryDirect.Left + labelCategoryDirect.Width + 6;
            rBtnIncome.Top = labelCategoryDirect.Top + 3;
            rBtnTransfer.Left = rBtnIncome.Left + rBtnIncome.Width + 6;
            rBtnTransfer.Top = rBtnIncome.Top;
            rBtnOutcome.Left = rBtnTransfer.Left + rBtnTransfer.Width + 6;
            rBtnOutcome.Top = rBtnTransfer.Top;
        }

        private void RefreshCategoryTree()
        {
            trViewCategories.Nodes.Clear();
            ListChildren(null, trViewCategories.Nodes);
            if (trViewCategories.Nodes.Count > 0)
                trViewCategories.ExpandAll();
        }

        private void ListChildren(string strKey, TreeNodeCollection trNodes)
        {
            string strSQL = @"SELECT [ID],[NAME] FROM [dbo].[CATEGORY] WHERE PARENT_ID" + (strKey == null ? " IS NULL" : String.Format("={0}", strKey));
            SqlCommand cmdSelectChildren = new SqlCommand(strSQL, dbConn);
            SqlDataReader dr4TypeTree = cmdSelectChildren.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr4TypeTree);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode childNode = trNodes.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                ListChildren(dt.Rows[i][0].ToString(), childNode.Nodes);
            }
        }

        private void SetEditAll(bool bEdit, bool bAll)
        {
            txtCategoryName.ReadOnly = !bEdit;
            txtCategoryDesc.ReadOnly = !bEdit;
            rBtnIncome.Enabled = (bEdit && bAll);
            rBtnOutcome.Enabled = (bEdit && bAll);
            rBtnTransfer.Enabled = (bEdit && bAll);
            trViewCategories.Enabled = !bEdit;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;
            if (bOK)
            {
                if (txtCategoryName.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNameBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if ((rBtnIncome.Checked == false) &&
                    (rBtnOutcome.Checked == false) &&
                    (rBtnTransfer.Checked == false))
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoFlowDirectSelected, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            return bOK;
        }

        private void UpdateEditForm()
        {
            SqlCommand cmdSelectDetail = new SqlCommand("SELECT [ID],[PARENT_ID],[NAME],[DESCRIPTION],[FLOW_DIRECT] FROM [dbo].[CATEGORY] WHERE ID=" + trViewCategories.SelectedNode.Name, dbConn);
            SqlDataReader dr4TDetail = cmdSelectDetail.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr4TDetail);
            txtID.Text = dt.Rows[0][0].ToString();
            txtParentID.Text = dt.Rows[0][1].ToString();
            txtCategoryName.Text = dt.Rows[0][2].ToString();
            txtCategoryDesc.Text = dt.Rows[0][3].ToString();
            short shortFlowDirect = Convert.ToInt16(dt.Rows[0][4]);
            if (shortFlowDirect > 0)
                rBtnIncome.Checked = true;
            else if (shortFlowDirect < 0)
                rBtnOutcome.Checked = true;
            else
                rBtnTransfer.Checked = true;
        }

        private void ClearEditForm()
        {
            txtID.Text = "";
            txtParentID.Text = "";
            txtCategoryName.Text = "";
            txtCategoryDesc.Text = "";
            rBtnIncome.Checked = false;
            rBtnTransfer.Checked = false;
            rBtnOutcome.Checked = false;
        }

        private void CommitChange()
        {
            if (txtID.Text == "")
            {
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[CATEGORY]([PARENT_ID],[NAME],[DESCRIPTION],[FLOW_DIRECT]) VALUES(@CurParent,@CurName,@CurDesc,@CurDirect)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@CurParent", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@CurName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@CurDesc", SqlDbType.NVarChar, 4000));
                cmdInsert.Parameters.Add(new SqlParameter("@CurDirect", SqlDbType.SmallInt));
                if (txtParentID.Text == "")
                    cmdInsert.Parameters["@CurParent"].Value = DBNull.Value;
                else
                    cmdInsert.Parameters["@CurParent"].Value = txtParentID.Text;
                cmdInsert.Parameters["@CurName"].Value = txtCategoryName.Text;
                cmdInsert.Parameters["@CurDesc"].Value = txtCategoryDesc.Text;
                cmdInsert.Parameters["@CurDirect"].Value = rBtnIncome.Checked ? 1 : (rBtnOutcome.Checked ? -1 : 0);
                cmdInsert.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdUpdate = new SqlCommand(@"UPDATE [dbo].[CATEGORY] SET [NAME]=@CurName,[DESCRIPTION]=@CurDesc WHERE ID=@CurID", dbConn);
                cmdUpdate.Parameters.Add(new SqlParameter("@CurID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@CurName", SqlDbType.NVarChar, 50));
                cmdUpdate.Parameters.Add(new SqlParameter("@CurDesc", SqlDbType.NVarChar, 4000));
                cmdUpdate.Parameters["@CurID"].Value = txtID.Text;
                cmdUpdate.Parameters["@CurName"].Value = txtCategoryName.Text;
                cmdUpdate.Parameters["@CurDesc"].Value = txtCategoryDesc.Text;
                cmdUpdate.ExecuteNonQuery();
            }
        }

        private short GetFlowDirect(string strID)
        {
            short direct2Ret = 0;
            SqlCommand cmdGetFlowDirect = new SqlCommand(@"SELECT FLOW_DIRECT FROM [dbo].[CATEGORY] WHERE ID=@ID2Get", dbConn);
            cmdGetFlowDirect.Parameters.Add(new SqlParameter("@ID2Get", SqlDbType.BigInt));
            cmdGetFlowDirect.Parameters["@ID2Get"].Value = strID;
            var objFlowDirect = cmdGetFlowDirect.ExecuteScalar();
            if (objFlowDirect != null)
                direct2Ret = Convert.ToInt16(objFlowDirect);
            return direct2Ret;
        }
    }
}
