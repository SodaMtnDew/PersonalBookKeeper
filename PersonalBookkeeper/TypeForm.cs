using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalBookKeeper
{
    public partial class TypeForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        public TypeForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            parentForm = parent2Set;
        }

        private void TypeForm_Load(object sender, EventArgs e)
        {
            labelDbGridView.Text = PersonalBookKeeper.Properties.Resources.strTxtAccountTypes;
            btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddTypes;
            btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModTypes;
            labelTypeName.Text = PersonalBookKeeper.Properties.Resources.strTxtNameAccountType;
            labelTypeDesc.Text = PersonalBookKeeper.Properties.Resources.strTxtDescription;
            labelTypeFlag.Text = PersonalBookKeeper.Properties.Resources.strTxtTypeFlags;
            rBtnAsset.Text = PersonalBookKeeper.Properties.Resources.strTxtAssets;
            rBtnLiability.Text = PersonalBookKeeper.Properties.Resources.strTxtLiabilities;
            RefreshTypeTree();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddTypes)
            {
                string strTmp = "";
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmAdd;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelAdd;
                if (trViewTypes.SelectedNode != null)
                {
                    if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strTxtAddSubTypes, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        strTmp = txtID.Text;
                }
                ClearEditForm();
                if (strTmp != "")
                {
                    txtParentID.Text = strTmp;
                    short sTypeFlag = GetTypeFlag(strTmp);
                    if (sTypeFlag > 0)
                        rBtnAsset.Checked = true;
                    else
                        rBtnLiability.Checked = true;
                }
                SetEditAll(true, (txtID.Text == "") && (txtParentID.Text == ""));
                parentForm.LockTab();
            }
            else
            {
                if (ChkEditForm())
                {
                    SetEditAll(false, true);
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddTypes;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModTypes;
                    CommitChange();
                    ClearEditForm();
                    RefreshTypeTree();
                    parentForm.UnlockTab();
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddTypes)
            {
                if (trViewTypes.SelectedNode == null)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoTypeSelected, PersonalBookKeeper.Properties.Resources.strHintTitle);
                else
                {
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmMod;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelMod;
                    SetEditAll(true,false);
                    parentForm.LockTab();
                }
            }
            else
            {
                SetEditAll(false, true);
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddTypes;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModTypes;
                parentForm.UnlockTab();
                if (trViewTypes.SelectedNode != null)
                    UpdateEditForm();
                else
                    ClearEditForm();
            }
        }

        private void trViewTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trViewTypes.SelectedNode != null)
                UpdateEditForm();
            else
                ClearEditForm();
        }

        private void TypeForm_SizeChanged(object sender, EventArgs e)
        {
            trViewTypes.Width = this.Width * 5 / 9;
            trViewTypes.Height = this.Height - 47;
            btnAdd.Left = trViewTypes.Left + trViewTypes.Width + 6;
            btnMod.Left = btnAdd.Left + btnAdd.Width + 6;
            txtParentID.Left = btnMod.Left + btnMod.Width + 6;
            txtID.Left = txtParentID.Left + txtParentID.Width + 6;
            labelTypeName.Left = btnAdd.Left;
            txtTypeName.Left = labelTypeName.Left + labelTypeName.Width + 6;
            txtTypeName.Width = this.Width - 12 - txtTypeName.Left;
            labelTypeDesc.Left = btnAdd.Left;
            txtTypeDesc.Left = labelTypeDesc.Left + labelTypeDesc.Width + 6;
            txtTypeDesc.Width = this.Width - 12 - txtTypeDesc.Left;
            labelTypeFlag.Left = btnAdd.Left;
            labelTypeFlag.Top = this.Height * 2 / 3;
            txtTypeDesc.Height = labelTypeFlag.Top - txtTypeDesc.Top - 6;
            rBtnAsset.Left = labelTypeFlag.Left + labelTypeDesc.Width + 6;
            rBtnAsset.Top = labelTypeFlag.Top + 3;
            rBtnLiability.Left = rBtnAsset.Left + rBtnAsset.Width + 6;
            rBtnLiability.Top = rBtnAsset.Top;
        }

        private void RefreshTypeTree()
        {
            trViewTypes.Nodes.Clear();
            ListChildren(null, trViewTypes.Nodes);
            if(trViewTypes.Nodes.Count > 0)
                trViewTypes.ExpandAll();
        }

        private void ListChildren(string strKey, TreeNodeCollection trNodes)
        {
            string strSQL = @"SELECT [ID],[NAME] FROM [dbo].[TYPE] WHERE PARENT_ID" + (strKey == null ? " IS NULL" : String.Format("={0}", strKey));
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
            txtTypeName.ReadOnly = !bEdit;
            txtTypeDesc.ReadOnly = !bEdit;
            rBtnAsset.Enabled = (bEdit && bAll);
            rBtnLiability.Enabled = (bEdit && bAll);
            trViewTypes.Enabled = !bEdit;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;
            if (bOK)
            {
                if (txtTypeName.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNameBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if ((rBtnAsset.Checked == false) &&
                    (rBtnLiability.Checked == false))
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoTypeFlagSelected, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            return bOK;
        }

        private void UpdateEditForm()
        {
            SqlCommand cmdSelectDetail = new SqlCommand("SELECT [ID],[PARENT_ID],[NAME],[DESCRIPTION],[TYPE_FLAG] FROM [dbo].[TYPE] WHERE ID=" + trViewTypes.SelectedNode.Name, dbConn);
            SqlDataReader dr4TDetail = cmdSelectDetail.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr4TDetail);
            txtID.Text = dt.Rows[0][0].ToString();
            txtParentID.Text = dt.Rows[0][1].ToString();
            txtTypeName.Text = dt.Rows[0][2].ToString();
            txtTypeDesc.Text = dt.Rows[0][3].ToString();
            short shortAssetFlag = Convert.ToInt16(dt.Rows[0][4]);
            if (shortAssetFlag > 0)
                rBtnAsset.Checked = true;
            else
                rBtnLiability.Checked = true;
        }

        private void ClearEditForm()
        {
            txtID.Text = "";
            txtParentID.Text = "";
            txtTypeName.Text = "";
            txtTypeDesc.Text = "";
            rBtnAsset.Checked = false;
            rBtnLiability.Checked = false;
        }

        private void CommitChange()
        {
            if (txtID.Text == "")
            {
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[TYPE]([PARENT_ID],[NAME],[DESCRIPTION],[TYPE_FLAG]) VALUES(@CurParent,@CurName,@CurDesc,@CurFlag)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@TypeParent", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@TypeName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@TypeDesc", SqlDbType.NVarChar, 4000));
                cmdInsert.Parameters.Add(new SqlParameter("@TypeFlag", SqlDbType.SmallInt));
                if (txtParentID.Text == "")
                    cmdInsert.Parameters["@TypeParent"].Value = DBNull.Value;
                else
                    cmdInsert.Parameters["@TypeParent"].Value = txtParentID.Text;
                cmdInsert.Parameters["@TypeName"].Value = txtTypeName.Text;
                cmdInsert.Parameters["@TypeDesc"].Value = txtTypeDesc.Text;
                cmdInsert.Parameters["@TypeFlag"].Value = rBtnAsset.Checked ? 1 : -1;
                cmdInsert.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdUpdate = new SqlCommand(@"UPDATE [dbo].[TYPE] SET [NAME]=@TypeName,[DESCRIPTION]=@TypeDesc WHERE ID=@TypeID", dbConn);
                cmdUpdate.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@TypeName", SqlDbType.NVarChar, 50));
                cmdUpdate.Parameters.Add(new SqlParameter("@TypeDesc", SqlDbType.NVarChar, 4000));
                cmdUpdate.Parameters["@TypeID"].Value = txtID.Text;
                cmdUpdate.Parameters["@TypeName"].Value = txtTypeName.Text;
                cmdUpdate.Parameters["@TypeDesc"].Value = txtTypeDesc.Text;
                cmdUpdate.ExecuteNonQuery();
            }
        }
        
        private short GetTypeFlag(string strID)
        {
            short flag2Ret = 0;
            SqlCommand cmdGetTypeFlag = new SqlCommand(@"SELECT TYPE_FLAG FROM [dbo].[TYPE] WHERE ID=@ID2Get", dbConn);
            cmdGetTypeFlag.Parameters.Add(new SqlParameter("@ID2Get", SqlDbType.BigInt));
            cmdGetTypeFlag.Parameters["@ID2Get"].Value = strID;
            var objTypeFlag = cmdGetTypeFlag.ExecuteScalar();
            if(objTypeFlag!=null)
                flag2Ret = Convert.ToInt16(objTypeFlag);
            return flag2Ret;
        }
    }
}
