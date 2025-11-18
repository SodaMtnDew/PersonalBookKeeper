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
    public partial class CurrencyForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        SqlCommand cmdGetCurrency;
        bool bIsMain;
        public CurrencyForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            cmdGetCurrency = null;
            parentForm = parent2Set;
            bIsMain = false;
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            labelDbGridView.Text = PersonalBookKeeper.Properties.Resources.strTxtCurrencies;
            btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddCurrency;
            btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModCurrency;
            labelCurrencyName.Text = PersonalBookKeeper.Properties.Resources.strTxtNameCurrency;
            labelCurrencyAcronym.Text = PersonalBookKeeper.Properties.Resources.strTxtAcronym;
            labelCurrencyDecimalPoint.Text = PersonalBookKeeper.Properties.Resources.strTxtDecPoint;
            chkIsMainCurrency.Text = PersonalBookKeeper.Properties.Resources.strTxtSetMainCurrency;
            RefreshCurrency();
            dbGridCurrency.ClearSelection();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddCurrency)
            {
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmAdd;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelAdd;
                ClearEditForm();
                SetEditAll(true, true);
                parentForm.LockTab();
            }
            else
            {
                if (ChkEditForm())
                {
                    SetEditAll(false, true);
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddCurrency;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModCurrency;
                    CommitChange();
                    RefreshCurrency();
                    parentForm.UnlockTab();
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddCurrency)
            {
                if (dbGridCurrency.SelectedRows.Count == 0)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strHintModCurrency, PersonalBookKeeper.Properties.Resources.strHintTitle);
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
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddCurrency;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModCurrency;
                if (dbGridCurrency.SelectedRows.Count > 0)
                    UpdateEditForm();
                else
                    ClearEditForm();
                parentForm.UnlockTab();
            }
        }

        private void dbGridCurrency_SelectionChanged(object sender, EventArgs e)
        {
            if (dbGridCurrency.SelectedRows.Count > 0)
                UpdateEditForm();
            else
                ClearEditForm();
        }

        private void txtCurrencyDecimalPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false))
                e.Handled = true;
            else if ((e.KeyChar != '0') && (e.KeyChar != '1') && (e.KeyChar != '2') && (e.KeyChar != '3') && (Char.IsControl(e.KeyChar) == false))
                e.Handled = true;
            else if ((Char.IsNumber(e.KeyChar) == true) && (txtCurrencyDecimalPoint.Text.Length > 0))
                e.Handled = true;
        }

        private void CurrencyForm_SizeChanged(object sender, EventArgs e)
        {
            dbGridCurrency.Width = this.Width * 5 / 9;
            dbGridCurrency.Height = this.Height - 12 - dbGridCurrency.Top;
            labelDbGridView.Width = dbGridCurrency.Width;
            if (dbGridCurrency.ColumnCount > 0)
            {
                dbGridCurrency.Columns[1].Width = (dbGridCurrency.Width - 20) / 4;
                dbGridCurrency.Columns[2].Width = dbGridCurrency.Columns[1].Width;
                dbGridCurrency.Columns[3].Width = dbGridCurrency.Columns[1].Width;
                dbGridCurrency.Columns[4].Width = dbGridCurrency.Width - 20 - dbGridCurrency.Columns[1].Width * 3;
            }
            btnAdd.Left = dbGridCurrency.Left + dbGridCurrency.Width + 6;
            btnMod.Left = btnAdd.Left + btnAdd.Width + 6;
            txtID.Left = btnMod.Left + btnMod.Width + 6;
            labelCurrencyName.Left = btnAdd.Left;
            txtCurrencyName.Left = labelCurrencyName.Left + labelCurrencyName.Width + 6;
            txtCurrencyName.Width = this.Width - 12 - txtCurrencyName.Left;
            labelCurrencyAcronym.Left = btnAdd.Left;
            txtCurrencyAcronym.Left = labelCurrencyAcronym.Left + labelCurrencyAcronym.Width + 6;
            txtCurrencyAcronym.Width = this.Width - 12 - txtCurrencyAcronym.Left;
            labelCurrencyDecimalPoint.Left = btnAdd.Left;
            txtCurrencyDecimalPoint.Left = labelCurrencyDecimalPoint.Left + labelCurrencyDecimalPoint.Width + 6;
            txtCurrencyDecimalPoint.Width = this.Width - 12 - txtCurrencyAcronym.Left;
            chkIsMainCurrency.Left = btnAdd.Left;
            chkIsMainCurrency.Width = this.Width - 12 - chkIsMainCurrency.Left;
        }

        private void RefreshCurrency()
        {
            if (cmdGetCurrency == null)
                cmdGetCurrency = new SqlCommand(@"SELECT [ID],[NAME],[ACRONYM],[DEC_POINT],[IS_MAIN] FROM [dbo].[CURRENCY];", dbConn);
            DataTable dtCurrency = new DataTable();
            SqlDataReader dr4GetCurrency = cmdGetCurrency.ExecuteReader();
            dtCurrency.Load(dr4GetCurrency);
            ClearEditForm();
            dbGridCurrency.DataSource = dtCurrency;
            dbGridCurrency.Columns[1].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtName;
            dbGridCurrency.Columns[2].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtAcronym;
            dbGridCurrency.Columns[3].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtDecPoint;
            dbGridCurrency.Columns[4].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtIsMainCurrency;
            dbGridCurrency.Columns[0].Visible = false;
            if (dbGridCurrency.Rows.Count > 0)
                dbGridCurrency.Rows[0].Selected = true;
        }

        private void SetEditAll(bool bEdit, bool bAll)
        {
            txtCurrencyName.ReadOnly = !(bEdit && bAll);
            txtCurrencyAcronym.ReadOnly = !bEdit;
            txtCurrencyDecimalPoint.ReadOnly = !bEdit;
            chkIsMainCurrency.Enabled = bEdit;
            dbGridCurrency.Enabled = bEdit;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;
            if (bOK)
            {
                if (txtCurrencyName.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNameBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (txtCurrencyAcronym.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrAcronymBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if ((txtCurrencyDecimalPoint.Text != "0") &&
                    (txtCurrencyDecimalPoint.Text != "1") &&
                    (txtCurrencyDecimalPoint.Text != "2") &&
                    (txtCurrencyDecimalPoint.Text != "3"))
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrInvalidDecPoint, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            return bOK;
        }

        private void UpdateEditForm()
        {
            txtID.Text = dbGridCurrency.SelectedRows[0].Cells[0].Value.ToString();
            txtCurrencyName.Text = dbGridCurrency.SelectedRows[0].Cells[1].Value.ToString();
            txtCurrencyAcronym.Text = dbGridCurrency.SelectedRows[0].Cells[2].Value.ToString();
            txtCurrencyDecimalPoint.Text = dbGridCurrency.SelectedRows[0].Cells[3].Value.ToString();
            bIsMain = Convert.ToBoolean(dbGridCurrency.SelectedRows[0].Cells[4].Value);
            if (bIsMain == true)
                chkIsMainCurrency.Checked = true;
            else
                chkIsMainCurrency.Checked = false;
        }

        private void ClearEditForm()
        {
            txtID.Text = "";
            txtCurrencyName.Text = "";
            txtCurrencyAcronym.Text = "";
            txtCurrencyDecimalPoint.Text = "";
            chkIsMainCurrency.Checked = false;
            bIsMain = false;
        }

        private void CommitChange()
        {
            SqlCommand cmdChkMain = new SqlCommand(@"SELECT COUNT(*) FROM [dbo].[CURRENCY] WHERE [IS_MAIN]=1", dbConn),
                       cmdClrMain = new SqlCommand(@"UPDATE [dbo].[CURRENCY] SET [IS_MAIN]=0", dbConn);
            ushort cntMain = Convert.ToUInt16(cmdChkMain.ExecuteScalar());
            if (txtID.Text == "")
            {
                if ((cntMain == 0) && (chkIsMainCurrency.Checked == false))
                    if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strHintConfirmMainCurrency, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        chkIsMainCurrency.Checked = true;
                else if ((cntMain > 0) && (chkIsMainCurrency.Checked == true))
                    if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strHintConfirmOverwriteMainCurrency, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.No)
                        chkIsMainCurrency.Checked = false;
                if(chkIsMainCurrency.Checked == true)
                    cmdClrMain.ExecuteNonQuery();
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[CURRENCY]([NAME],[ACRONYM],[DEC_POINT],[IS_MAIN]) VALUES(@CurName,@CurAcro,@CurDecPnt,@CurIsMain)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@CurName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@CurAcro", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@CurDecPnt", SqlDbType.TinyInt));
                cmdInsert.Parameters.Add(new SqlParameter("@CurIsMain", SqlDbType.Bit));
                cmdInsert.Parameters["@CurName"].Value = txtCurrencyName.Text;
                cmdInsert.Parameters["@CurAcro"].Value = txtCurrencyAcronym.Text;
                cmdInsert.Parameters["@CurDecPnt"].Value = Convert.ToUInt16(txtCurrencyDecimalPoint.Text);
                cmdInsert.Parameters["@CurIsMain"].Value = chkIsMainCurrency.Checked ? 1 : 0;
                cmdInsert.ExecuteNonQuery();
            }
            else
            {
                if ((bIsMain == true) && (chkIsMainCurrency.Checked == false))
                    if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strHintConfirmNotClearMainCurrency, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        chkIsMainCurrency.Checked = true;
                if ((bIsMain == false) && (chkIsMainCurrency.Checked == true))
                    if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strHintConfirmKeepMainCurrency, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        chkIsMainCurrency.Checked = false;
                if (chkIsMainCurrency.Checked == true)
                    cmdClrMain.ExecuteNonQuery();
                SqlCommand cmdUpdate = new SqlCommand(@"UPDATE [dbo].[CURRENCY] SET [ACRONYM]=@CurAcro,[DEC_POINT]=@CurDecPnt,[IS_MAIN]=@CurIsMain WHERE ID=@CurID", dbConn);
                cmdUpdate.Parameters.Add(new SqlParameter("@CurID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@CurAcro", SqlDbType.NVarChar, 50));
                cmdUpdate.Parameters.Add(new SqlParameter("@CurDecPnt", SqlDbType.TinyInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@CurIsMain", SqlDbType.Bit));
                cmdUpdate.Parameters["@CurID"].Value = txtID.Text;
                cmdUpdate.Parameters["@CurAcro"].Value = txtCurrencyAcronym.Text;
                cmdUpdate.Parameters["@CurDecPnt"].Value = Convert.ToUInt16(txtCurrencyDecimalPoint.Text);
                cmdUpdate.Parameters["@CurIsMain"].Value = chkIsMainCurrency.Checked ? 1 : 0;
                cmdUpdate.ExecuteNonQuery();
            }

        }
    }
}
