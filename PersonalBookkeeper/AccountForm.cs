using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PersonalBookKeeper
{
    public partial class AccountForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        SqlCommand cmdGetAccount;
        public AccountForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            parentForm = parent2Set;
            cmdGetAccount = null;
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            labelDbAccounts.Text = PersonalBookKeeper.Properties.Resources.strTxtAccounts;
            btnRefresh.Text = PersonalBookKeeper.Properties.Resources.strBtnRefresh;
            btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddAccount;
            btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModAccount;
            btnDel.Text = PersonalBookKeeper.Properties.Resources.strBtnDelAccount;
            labelAccountName.Text = PersonalBookKeeper.Properties.Resources.strTxtNameAccount;
            labelAccountDesc.Text = PersonalBookKeeper.Properties.Resources.strTxtDescription;
            labelAccountBalance.Text = PersonalBookKeeper.Properties.Resources.strTxtBalance;
            labelAccountType.Text = PersonalBookKeeper.Properties.Resources.strTxtAccountType;
            labelAccountCurrency.Text = PersonalBookKeeper.Properties.Resources.strTxtCurrency;
            RefreshAccounts();
            InitDbGridAccount();
            RefreshTypes();
            RefreshCurrencies();
            dbGridAccount.ClearSelection();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddAccount)
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
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddAccount;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModAccount;
                    CommitChange();
                    ClearEditForm();
                    RefreshAccounts();
                    parentForm.UnlockTab();
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddAccount)
            {
                if (dbGridAccount.SelectedRows.Count == 0)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoAccount2Modify, PersonalBookKeeper.Properties.Resources.strErrTitle);
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
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddAccount;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModAccount;
                parentForm.UnlockTab();
                if (dbGridAccount.SelectedRows.Count > 0)
                    UpdateEditForm();
                else
                    ClearEditForm();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dbGridAccount.SelectedRows.Count == 0)
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoAccount2Delete, PersonalBookKeeper.Properties.Resources.strErrTitle);
            else if (Convert.ToDecimal(txtAccountBalance.Text) != 0)
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrAccountBalanceNot0, PersonalBookKeeper.Properties.Resources.strErrTitle);
            else
            {
                SqlCommand sqlAccountDel = new SqlCommand("UPDATE [dbo].[ACCOUNT] SET [DELETED]=1 WHERE [ID]=@AccID", dbConn);
                sqlAccountDel.Parameters.Add("@AccID",SqlDbType.BigInt);
                sqlAccountDel.Parameters["@AccID"].Value = txtID.Text;
                sqlAccountDel.ExecuteNonQuery();
                ClearEditForm();
                RefreshAccounts();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAccounts();
        }

        private void dbGridAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dbGridAccount.SelectedRows.Count > 0)
                UpdateEditForm();
            else
                ClearEditForm();
        }

        private void txtAccountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void dbGridAccount_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int idx1st = e.RowIndex;
            int num2Add = e.RowCount;
            for (int i = idx1st; i < idx1st + num2Add; i++)
            {
                short sDecPoint = -1,
                    sFlowDirect = Convert.ToInt16(dgv.Rows[i].Cells[4].Value);
                if (sFlowDirect >= 0)
                    dgv.Rows[i].Cells[11].Style.ForeColor = Color.Black;
                else
                    dgv.Rows[i].Cells[11].Style.ForeColor = Color.Red;
                if (dgv.Rows[i].Cells[12].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[12].Value);
                if (sDecPoint >= 0)
                    dgv.Rows[i].Cells[11].Style.Format = String.Format("N{0}", sDecPoint);
            }
        }

        private void AccountForm_SizeChanged(object sender, EventArgs e)
        {
            btnRefresh.Left = this.Width - 12 - btnRefresh.Width;
            dbGridAccount.Height = this.Height / 3;
            dbGridAccount.Width = this.Width - 24;
            if (dbGridAccount.ColumnCount > 0)
            {
                dbGridAccount.Columns[5].Width = (dbGridAccount.Width - 20) / 7;
                dbGridAccount.Columns[6].Width = dbGridAccount.Columns[5].Width;
                dbGridAccount.Columns[7].Width = dbGridAccount.Columns[5].Width;
                dbGridAccount.Columns[8].Width = dbGridAccount.Columns[5].Width;
                dbGridAccount.Columns[9].Width = dbGridAccount.Columns[5].Width;
                dbGridAccount.Columns[10].Width = dbGridAccount.Columns[5].Width;
                dbGridAccount.Columns[11].Width = dbGridAccount.Width - 20 - dbGridAccount.Columns[5].Width * 6;
            }
            btnAdd.Top = dbGridAccount.Top + dbGridAccount.Height + 6;
            btnMod.Top = btnAdd.Top;
            btnDel.Top = btnMod.Top;
            txtID.Top = btnDel.Top;
            labelAccountCurrency.Top = txtID.Top;
            dbGridCurrency.Top = labelAccountCurrency.Top + labelAccountCurrency.Height + 6;
            dbGridCurrency.Width = this.Width / 5;
            dbGridCurrency.Left = this.Width - 12 - dbGridCurrency.Width;
            dbGridCurrency.Height = this.Height - 12 - dbGridCurrency.Top;
            if (dbGridCurrency.Columns.Count >= 2)
                dbGridCurrency.Columns[2].Width = dbGridCurrency.Width;
            labelAccountCurrency.Left = dbGridCurrency.Left;
            labelAccountCurrency.Width = dbGridCurrency.Width;
            labelAccountType.Top = labelAccountCurrency.Top;
            labelAccountType.Width = labelAccountCurrency.Width;
            labelAccountType.Left = dbGridCurrency.Left - 6 - labelAccountType.Width;
            dbGridType.Top = dbGridCurrency.Top;
            dbGridType.Width = dbGridCurrency.Width;
            dbGridType.Height = dbGridCurrency.Height;
            dbGridType.Left = dbGridCurrency.Left - 6 - dbGridType.Width;
            if (dbGridType.Columns.Count >= 2)
                dbGridType.Columns[1].Width = dbGridType.Width;
            labelAccountName.Top = dbGridType.Top;
            txtAccountName.Top = labelAccountName.Top;
            txtAccountName.Width = dbGridType.Width * 2 + 6;
            txtAccountName.Left = dbGridType.Left - 6 - txtAccountName.Width;
            labelAccountBalance.Top = this.Height - 12 - labelAccountBalance.Height;
            txtAccountBalance.Top = labelAccountBalance.Top;
            txtAccountBalance.Left = txtAccountName.Left;
            txtAccountBalance.Width = txtAccountName.Width;
            labelAccountDesc.Top = txtAccountName.Top + txtAccountName.Height + 6;
            txtAccountDesc.Top = labelAccountDesc.Top;
            txtAccountDesc.Left = txtAccountName.Left;
            txtAccountDesc.Width = txtAccountName.Width;
            txtAccountDesc.Height = txtAccountBalance.Top - 6 - txtAccountDesc.Top;
        }

        private void InitDbGridAccount()
        {
            dbGridAccount.Columns[0].Visible = false;
            dbGridAccount.Columns[1].Visible = false;
            dbGridAccount.Columns[2].Visible = false;
            dbGridAccount.Columns[3].Visible = false;
            dbGridAccount.Columns[4].Visible = false;
            dbGridAccount.Columns[5].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtName;
            dbGridAccount.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[6].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtDescription;
            dbGridAccount.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[7].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtAccountType;
            dbGridAccount.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[8].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtCurrency;
            dbGridAccount.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[9].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtCreatedTime;
            dbGridAccount.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[10].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtUpdatedTime;
            dbGridAccount.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[11].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtBalance;
            dbGridAccount.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridAccount.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridAccount.Columns[12].Visible = false;
        }
        private void RefreshAccounts()
        {
            if (cmdGetAccount == null)
                cmdGetAccount = new SqlCommand(@"SELECT * FROM [dbo].[ACCOUNTS_LIST] ORDER BY [IS_MAIN] DESC,[CURRENCY_ID],[TYPE_FLAG] DESC,[TYPE_ID]", dbConn);
            DataTable dtAccount = new DataTable();
            SqlDataReader dr4GetAccount = cmdGetAccount.ExecuteReader();
            dtAccount.Load(dr4GetAccount);
            dbGridAccount.DataSource = dtAccount;
            if (dbGridAccount.Rows.Count > 0)
                dbGridAccount.Rows[0].Selected = true;
        }

        private void RefreshTypes()
        {
            SqlCommand cmdGetType = new SqlCommand(@"SELECT A.[ID],A.[NAME] FROM [dbo].[TYPE] A WHERE NOT EXISTS (SELECT 1 FROM [dbo].[TYPE] B WHERE B.[PARENT_ID]=A.[ID]);", dbConn);
            DataTable dtType = new DataTable();
            SqlDataReader dr4GetType = cmdGetType.ExecuteReader();
            dtType.Load(dr4GetType);
            dbGridType.DataSource = dtType;
            dbGridType.Columns[0].Visible = false;
            dbGridType.Columns[1].Width = dbGridType.Width;
        }

        private void RefreshCurrencies()
        {
            SqlCommand cmdGetCurrency = new SqlCommand(@"SELECT [ID],[NAME],[ACRONYM] FROM [dbo].[CURRENCY] ORDER BY [IS_MAIN] DESC,[ID] ASC", dbConn);
            DataTable dtCurrency = new DataTable();
            SqlDataReader dr4GetCurrency = cmdGetCurrency.ExecuteReader();
            dtCurrency.Load(dr4GetCurrency);
            dbGridCurrency.DataSource = dtCurrency;
            dbGridCurrency.Columns[0].Visible = false;
            dbGridCurrency.Columns[1].Visible = false;
            dbGridCurrency.Columns[2].Width = dbGridCurrency.Width;
        }

        private void SetEditAll(bool bEdit, bool bAll)
        {
            txtAccountName.ReadOnly = !bEdit;
            txtAccountDesc.ReadOnly = !bEdit;
            txtAccountBalance.ReadOnly = !(bEdit && bAll);
            dbGridType.Enabled = (bEdit && bAll);
            dbGridCurrency.Enabled = (bEdit && bAll);            
            dbGridAccount.Enabled = !bEdit;
            btnDel.Enabled = !bEdit;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;
            if (bOK)
            {
                if (txtAccountName.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNameBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (txtAccountBalance.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrBalanceBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (dbGridType.SelectedRows.Count == 0)
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrTypeNotAssigned, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (dbGridCurrency.SelectedRows.Count == 0)
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrCurrencyNotAssigned, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            return bOK;
        }

        private void UpdateEditForm()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = "";
            txtID.Text = dbGridAccount.SelectedRows[0].Cells[0].Value.ToString();
            txtAccountName.Text = dbGridAccount.SelectedRows[0].Cells[5].Value.ToString();
            txtAccountDesc.Text = dbGridAccount.SelectedRows[0].Cells[6].Value.ToString();
            short sDecPoint = 0;
            if (dbGridAccount.SelectedRows[0].Cells[12].Value != DBNull.Value)
                sDecPoint = Convert.ToInt16(dbGridAccount.SelectedRows[0].Cells[12].Value);
            Decimal decAccountBalance = Convert.ToDecimal(dbGridAccount.SelectedRows[0].Cells[11].Value);
            txtAccountBalance.Text = decAccountBalance.ToString(String.Format("N{0}", sDecPoint), nfi);
            for (int i = 0; i < dbGridType.Rows.Count; i++)
            {
                if (dbGridType.Rows[i].Cells[0].Value.ToString() == dbGridAccount.SelectedRows[0].Cells[1].Value.ToString())
                {
                    dbGridType.Rows[i].Selected = true;
                    dbGridType.CurrentCell = dbGridType.Rows[i].Cells[1];
                    break;
                }
            }
            for (int i = 0; i < dbGridCurrency.Rows.Count; i++)
            {
                if (dbGridCurrency.Rows[i].Cells[0].Value.ToString() == dbGridAccount.SelectedRows[0].Cells[2].Value.ToString())
                {
                    dbGridCurrency.Rows[i].Selected = true;
                    dbGridCurrency.CurrentCell = dbGridCurrency.Rows[i].Cells[2];
                    break;
                }
            }
        }

        private void ClearEditForm()
        {
            txtID.Text = "";
            txtAccountName.Text = "";
            txtAccountDesc.Text = "";
            txtAccountBalance.Text = "";
            dbGridType.ClearSelection();
            dbGridCurrency.ClearSelection();
        }

        private void CommitChange()
        {
            if (txtID.Text == "")
            {
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[ACCOUNT]([NAME],[DESCRIPTION],[TYPE_ID],[CURRENCY_ID],[BALANCE]) VALUES(@AccName,@AccDesc,@AccType,@AccCurrency,@AccBalance)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@AccName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@AccDesc", SqlDbType.NVarChar, 4000));
                cmdInsert.Parameters.Add(new SqlParameter("@AccType", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@AccCurrency", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@AccBalance", SqlDbType.Decimal));
                cmdInsert.Parameters["@AccName"].Value = txtAccountName.Text;
                cmdInsert.Parameters["@AccDesc"].Value = txtAccountDesc.Text;
                cmdInsert.Parameters["@AccType"].Value = dbGridType.SelectedRows[0].Cells[0].Value.ToString();
                cmdInsert.Parameters["@AccCurrency"].Value = dbGridCurrency.SelectedRows[0].Cells[0].Value.ToString();
                cmdInsert.Parameters["@AccBalance"].Value = txtAccountBalance.Text;
                cmdInsert.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdUpdate = new SqlCommand(@"UPDATE [dbo].[ACCOUNT] SET [DESCRIPTION]=@AccDesc WHERE ID=@AccID", dbConn);
                cmdUpdate.Parameters.Add(new SqlParameter("@AccID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@AccDesc", SqlDbType.NVarChar, 4000));
                cmdUpdate.Parameters["@AccID"].Value = txtID.Text;
                cmdUpdate.Parameters["@AccDesc"].Value = txtAccountDesc.Text;
                cmdUpdate.ExecuteNonQuery();
            }
        }
    }
}
