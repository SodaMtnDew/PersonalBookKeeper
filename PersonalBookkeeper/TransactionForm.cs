using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalBookKeeper
{
    public partial class TransactionForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        SqlCommand cmdGetTransaction;
        short sFlowDirect;
        public TransactionForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            parentForm = parent2Set;
            cmdGetTransaction = null;
            sFlowDirect = 0;
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            labelDbTransactions.Text = PersonalBookKeeper.Properties.Resources.strTxtTransactions;
            btnRefresh.Text = PersonalBookKeeper.Properties.Resources.strBtnRefresh;
            btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddTransaction;
            btnDel.Text = PersonalBookKeeper.Properties.Resources.strBtnDelTransaction;
            btnSchedule.Text = PersonalBookKeeper.Properties.Resources.strBtnAdd2Schedule;
            labelSrcAccount.Text = PersonalBookKeeper.Properties.Resources.strTxtSrcAccount;
            labelCategory.Text = PersonalBookKeeper.Properties.Resources.strTxtCategory;
            labelDstAccount.Text = PersonalBookKeeper.Properties.Resources.strTxtDstAccount;
            labelTransactionName.Text = PersonalBookKeeper.Properties.Resources.strTxtNameTransaction;
            labelTransactionDesc.Text = PersonalBookKeeper.Properties.Resources.strTxtDescTransaction;
            chkSetTime.Text = PersonalBookKeeper.Properties.Resources.strTxtMadeTime;
            labelSrcAmount.Text = PersonalBookKeeper.Properties.Resources.strTxtAmountOut;
            labelDstAmount.Text = PersonalBookKeeper.Properties.Resources.strTxtAmountIn;
            RefreshTransactions();
            InitDbGridTransaction();
            RefreshCategories();
            RefreshAccounts();
            dbGridTransaction.ClearSelection();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddTransaction)
            {
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmAdd;
                btnDel.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelAdd;
                ClearEditForm();
                SetEditAll(true);
                parentForm.LockTab();
            }
            else
            {
                if (ChkEditForm())
                {
                    SetEditAll(false);
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddTransaction;
                    btnDel.Text = PersonalBookKeeper.Properties.Resources.strBtnDelTransaction;
                    CommitChange();
                    ClearEditForm();
                    RefreshTransactions();
                    parentForm.UnlockTab();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddTransaction)
            {
                if (dbGridTransaction.SelectedRows.Count == 0)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoTransaction2Delete, PersonalBookKeeper.Properties.Resources.strErrTitle);
                else
                {
                    DeleteFromTransaction();
                    RefreshTransactions();
                }
            }
            else
            {
                SetEditAll(false);
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddTransaction;
                btnDel.Text = PersonalBookKeeper.Properties.Resources.strBtnDelTransaction;
                parentForm.UnlockTab();
                if (dbGridTransaction.SelectedRows.Count > 0)
                    UpdateEditForm();
                else
                    ClearEditForm();
            }

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (dbGridTransaction.SelectedRows.Count == 0)
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoTransaction2Add2Schedule, PersonalBookKeeper.Properties.Resources.strErrTitle);
            else
                Add2Schedule();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTransactions();
        }

        private void dbGridTransaction_SelectionChanged(object sender, EventArgs e)
        {
            if (dbGridTransaction.SelectedRows.Count > 0)
                UpdateEditForm();
            else
                ClearEditForm();
        }

        private void txtSrcAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void txtDstAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void chkSetTime_CheckedChanged(object sender, EventArgs e)
        {
            dtPickerMadeDate.Enabled = chkSetTime.Checked;
            dtPickerMadeTime.Enabled = chkSetTime.Checked;
        }

        private void dbGridCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (!dbGridTransaction.Enabled)
            {
                if (dbGridCategory.SelectedRows.Count > 0)
                {
                    sFlowDirect = Convert.ToInt16(dbGridCategory.SelectedRows[0].Cells[2].Value);
                    dbGridSrcAccount.Enabled = true;
                    dbGridDstAccount.Enabled = true;
                    if (sFlowDirect > 0)
                    {
                        dbGridSrcAccount.ClearSelection();
                        dbGridSrcAccount.Enabled = false;
                    }
                    if (sFlowDirect < 0)
                    {
                        dbGridDstAccount.ClearSelection();
                        dbGridDstAccount.Enabled = false;
                    }
                }
            }
        }

        private void dbGridTransaction_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int idx1st = e.RowIndex;
            int num2Add = e.RowCount;
            for (int i = idx1st; i < idx1st + num2Add; i++)
            {
                short sSrcDecPoint = -1, sDstDecPoint = -1;
                dgv.Rows[i].Cells[13].Style.ForeColor = Color.Red;
                if (dgv.Rows[i].Cells[14].Value != DBNull.Value)
                    sSrcDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[14].Value);
                if (sSrcDecPoint >= 0)
                    dgv.Rows[i].Cells[13].Style.Format = String.Format("N{0}", sSrcDecPoint);
                if (dgv.Rows[i].Cells[17].Value != DBNull.Value)
                    sDstDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[17].Value);
                if (sDstDecPoint >= 0)
                    dgv.Rows[i].Cells[16].Style.Format = String.Format("N{0}", sDstDecPoint);
            }
        }

        private void dbGridSrcAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (!dbGridTransaction.Enabled)
            {
                if (dbGridSrcAccount.SelectedRows.Count > 0)
                    txtSrcAmount.ReadOnly = false;
                else
                {
                    txtSrcAmount.ReadOnly = true;
                    txtSrcAmount.Text = "";
                }
            }
        }

        private void dbGridDstAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (!dbGridTransaction.Enabled)
            {
                if (dbGridDstAccount.SelectedRows.Count > 0)
                    txtDstAmount.ReadOnly = false;
                else
                {
                    txtDstAmount.ReadOnly = true;
                    txtDstAmount.Text = "";
                }
            }
        }

        private void txtSrcAmount_TextChanged(object sender, EventArgs e)
        {
            if (!dbGridTransaction.Enabled)
            {
                if ((dbGridSrcAccount.SelectedRows.Count > 0) && (dbGridDstAccount.SelectedRows.Count > 0))
                {
                    int srcCurID = -1, dstCurID = -1;
                    if (dbGridSrcAccount.SelectedRows[0].Cells[3].Value != DBNull.Value)
                        srcCurID = Convert.ToInt32(dbGridSrcAccount.SelectedRows[0].Cells[3].Value);
                    if (dbGridDstAccount.SelectedRows[0].Cells[3].Value != DBNull.Value)
                        dstCurID = Convert.ToInt32(dbGridDstAccount.SelectedRows[0].Cells[3].Value);
                    if (srcCurID == dstCurID)
                        txtDstAmount.Text = txtSrcAmount.Text;
                }
            }
        }

        private void txtDstAmount_TextChanged(object sender, EventArgs e)
        {
            if (!dbGridTransaction.Enabled)
            {
                if ((dbGridSrcAccount.SelectedRows.Count > 0) && (dbGridDstAccount.SelectedRows.Count > 0))
                {
                    int srcCurID = -1, dstCurID = -1;
                    if (dbGridSrcAccount.SelectedRows[0].Cells[3].Value != DBNull.Value)
                        srcCurID = Convert.ToInt32(dbGridSrcAccount.SelectedRows[0].Cells[3].Value);
                    if (dbGridDstAccount.SelectedRows[0].Cells[3].Value != DBNull.Value)
                        dstCurID = Convert.ToInt32(dbGridDstAccount.SelectedRows[0].Cells[3].Value);
                    if (srcCurID == dstCurID)
                        txtSrcAmount.Text = txtDstAmount.Text;
                }
            }
        }

        private void TransactionForm_SizeChanged(object sender, EventArgs e)
        {
            dbGridTransaction.Height = this.Height / 4;
            dbGridTransaction.Width = this.Width - 24;
            if(dbGridTransaction.ColumnCount > 0)
            {
                dbGridTransaction.Columns[8].Width = (dbGridTransaction.Width - 20) / 8;
                dbGridTransaction.Columns[9].Width = dbGridTransaction.Columns[8].Width;
                dbGridTransaction.Columns[10].Width = dbGridTransaction.Columns[8].Width;
                dbGridTransaction.Columns[11].Width = dbGridTransaction.Columns[8].Width;
                dbGridTransaction.Columns[12].Width = dbGridTransaction.Columns[8].Width;
                dbGridTransaction.Columns[13].Width = dbGridTransaction.Columns[8].Width;
                dbGridTransaction.Columns[15].Width = dbGridTransaction.Columns[8].Width;
                dbGridTransaction.Columns[16].Width = dbGridTransaction.Width - 20 - dbGridTransaction.Columns[8].Width * 7;
            }
            btnRefresh.Left = this.Width - 12 - btnRefresh.Width;
            btnAdd.Top = dbGridTransaction.Top + dbGridTransaction.Height + 6;
            btnDel.Top = btnAdd.Top;
            btnDel.Width = btnAdd.Left + btnAdd.Width + 6;
            btnSchedule.Top = btnDel.Top;
            btnSchedule.Left = btnDel.Left + btnDel.Width + 6;
            labelDstAccount.Top = btnSchedule.Top;
            dbGridDstAccount.Top = labelDstAccount.Top + labelDstAccount.Height + 6;
            dbGridDstAccount.Width = this.Width / 6;
            dbGridDstAccount.Left = this.Width - 12 - dbGridDstAccount.Width;
            dbGridDstAccount.Height = this.Height - 12 - dbGridDstAccount.Top;
            if (dbGridDstAccount.Columns.Count >= 2)
                dbGridDstAccount.Columns[1].Width = dbGridDstAccount.Width;
            labelDstAccount.Left = dbGridDstAccount.Left;
            labelDstAccount.Width = dbGridDstAccount.Width;
            labelCategory.Top = labelDstAccount.Top;
            labelCategory.Width = labelDstAccount.Width;
            labelCategory.Left = labelDstAccount.Left - 6 - labelCategory.Width;
            dbGridCategory.Top = dbGridDstAccount.Top;
            dbGridCategory.Width = dbGridDstAccount.Width;
            dbGridCategory.Height = dbGridDstAccount.Height;
            dbGridCategory.Left = dbGridDstAccount.Left - 6 - dbGridCategory.Width;
            if (dbGridCategory.Columns.Count >= 2)
                dbGridCategory.Columns[1].Width = dbGridCategory.Width;
            labelSrcAccount.Top = labelCategory.Top;
            labelSrcAccount.Width = labelCategory.Width;
            labelSrcAccount.Left = labelCategory.Left - 6 - labelSrcAccount.Width;
            dbGridSrcAccount.Top = dbGridCategory.Top;
            dbGridSrcAccount.Width = dbGridCategory.Width;
            dbGridSrcAccount.Height = dbGridCategory.Height;
            dbGridSrcAccount.Left = dbGridCategory.Left - 6 - dbGridSrcAccount.Width;
            if (dbGridSrcAccount.Columns.Count >= 2)
                dbGridSrcAccount.Columns[1].Width = dbGridSrcAccount.Width;
            dtPickerMadeTime.Width = dbGridSrcAccount.Width;
            dtPickerMadeTime.Left = dbGridSrcAccount.Left - 6 - dtPickerMadeTime.Width;
            dtPickerMadeDate.Width = dtPickerMadeTime.Width;
            dtPickerMadeDate.Left = dtPickerMadeTime.Left - 6 - dtPickerMadeDate.Width;
            labelTransactionName.Top = dbGridSrcAccount.Top;
            txtTransactionName.Top = labelTransactionName.Top;
            txtTransactionName.Left = dtPickerMadeDate.Left;
            labelTransactionName.Width = txtTransactionName.Left - 6 - labelTransactionName.Left;
            txtTransactionName.Width = dbGridSrcAccount.Left - 6 - txtTransactionName.Left;
            labelDstAmount.Top = this.Height - 12 - labelDstAmount.Height;
            labelDstAmount.Width = labelTransactionName.Width;
            txtDstAmount.Top = labelDstAmount.Top;
            txtDstAmount.Left = txtTransactionName.Left;
            txtDstAmount.Width = txtTransactionName.Width;
            labelSrcAmount.Top = labelDstAmount.Top - 6 - labelSrcAmount.Height;
            labelSrcAmount.Width = labelTransactionName.Width; 
            txtSrcAmount.Top = labelSrcAmount.Top;
            txtSrcAmount.Left = txtTransactionName.Left;
            txtSrcAmount.Width = txtTransactionName.Width;
            chkSetTime.Top = labelSrcAmount.Top - 6 - chkSetTime.Height;
            chkSetTime.Width = labelTransactionName.Width;
            dtPickerMadeDate.Top = chkSetTime.Top;
            dtPickerMadeTime.Top = dtPickerMadeDate.Top;
            labelTransactionDesc.Top = txtTransactionName.Top + txtTransactionName.Height + 6;
            labelTransactionDesc.Width = labelTransactionName.Width;
            txtTransactionDesc.Top = labelTransactionDesc.Top;
            txtTransactionDesc.Left = txtTransactionName.Left;
            txtTransactionDesc.Width = txtTransactionName.Width;
            txtTransactionDesc.Height = chkSetTime.Top - 6 - txtTransactionDesc.Top;
        }

        private void InitDbGridTransaction()
        {
            dbGridTransaction.Columns[0].Visible = false;
            dbGridTransaction.Columns[1].Visible = false;
            dbGridTransaction.Columns[2].Visible = false;
            dbGridTransaction.Columns[3].Visible = false;
            dbGridTransaction.Columns[4].Visible = false;
            dbGridTransaction.Columns[5].Visible = false;
            dbGridTransaction.Columns[6].Visible = false;
            dbGridTransaction.Columns[7].Visible = false;
            dbGridTransaction.Columns[8].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtNameTransaction;
            dbGridTransaction.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[9].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtDescTransaction;
            dbGridTransaction.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[10].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtCategory;
            dbGridTransaction.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[11].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtMadeTime;
            dbGridTransaction.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[12].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtSrcAccount;
            dbGridTransaction.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[13].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtAmountOut;
            dbGridTransaction.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridTransaction.Columns[14].Visible = false;
            dbGridTransaction.Columns[15].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtDstAccount;
            dbGridTransaction.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[16].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtAmountIn;
            dbGridTransaction.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridTransaction.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridTransaction.Columns[17].Visible = false;
        }
        private void RefreshTransactions()
        {
            if (cmdGetTransaction == null)
            {
                cmdGetTransaction = new SqlCommand(@"SELECT * FROM [dbo].[GetTransactions](@AccID,@CurID,@StTime,@EdTime,@Count)", dbConn);
                cmdGetTransaction.Parameters.Add(new SqlParameter("@AccID", SqlDbType.BigInt));
                cmdGetTransaction.Parameters.Add(new SqlParameter("@CurID", SqlDbType.BigInt));
                cmdGetTransaction.Parameters.Add(new SqlParameter("@StTime", SqlDbType.DateTime2));
                cmdGetTransaction.Parameters.Add(new SqlParameter("@EdTime", SqlDbType.DateTime2));
                cmdGetTransaction.Parameters.Add(new SqlParameter("@Count", SqlDbType.BigInt));
            }
            cmdGetTransaction.Parameters["@AccID"].Value = 0;
            cmdGetTransaction.Parameters["@CurID"].Value = DBNull.Value;
            cmdGetTransaction.Parameters["@StTime"].Value = DBNull.Value;
            cmdGetTransaction.Parameters["@EdTime"].Value = DBNull.Value;
            cmdGetTransaction.Parameters["@Count"].Value = 0;
            DataTable dtTransaction = new DataTable();
            SqlDataReader dr4GetTransaction = cmdGetTransaction.ExecuteReader();
            dtTransaction.Load(dr4GetTransaction);
            dbGridTransaction.DataSource = dtTransaction;
            dbGridTransaction.ClearSelection();
        }

        private void RefreshCategories()
        {
            SqlCommand cmdGetCategory = new SqlCommand(@"SELECT A.[ID],A.[NAME],A.[FLOW_DIRECT] FROM [dbo].[CATEGORY] A WHERE NOT EXISTS (SELECT 1 FROM [dbo].[CATEGORY] B WHERE B.[PARENT_ID]=A.[ID]);", dbConn);
            DataTable dtCategory = new DataTable();
            SqlDataReader dr4GetCategory = cmdGetCategory.ExecuteReader();
            dtCategory.Load(dr4GetCategory);
            dbGridCategory.DataSource = dtCategory;
            dbGridCategory.Columns[0].Visible = false;
            dbGridCategory.Columns[1].Width = dbGridCategory.Width;
            dbGridCategory.Columns[2].Visible = false;
            dbGridCategory.ClearSelection();
        }

        private void RefreshAccounts()
        {
            SqlCommand cmdGetAccount = new SqlCommand(@"SELECT A.[ID],A.[NAME],B.[TYPE_FLAG],A.[CURRENCY_ID] FROM ([dbo].[ACCOUNT] A LEFT JOIN [dbo].[TYPE] B ON A.[TYPE_ID]=B.[ID]) LEFT JOIN [dbo].[CURRENCY] C ON A.[CURRENCY_ID]=C.[ID] ORDER BY C.[IS_MAIN] DESC,C.[ID]", dbConn);
            DataTable dtSrcAccount = new DataTable(), dtDstAccount = new DataTable();
            SqlDataReader dr4GetAccount = cmdGetAccount.ExecuteReader();
            dtSrcAccount.Load(dr4GetAccount);
            dtDstAccount = dtSrcAccount.Copy();
            dbGridSrcAccount.DataSource = dtSrcAccount;
            dbGridSrcAccount.Columns[0].Visible = false;
            dbGridSrcAccount.Columns[1].Width = dbGridSrcAccount.Width;
            dbGridSrcAccount.Columns[2].Visible = false;
            dbGridSrcAccount.Columns[3].Visible = false;
            dbGridSrcAccount.ClearSelection();
            dbGridDstAccount.DataSource = dtDstAccount;
            dbGridDstAccount.Columns[0].Visible = false;
            dbGridDstAccount.Columns[1].Width = dbGridDstAccount.Width;
            dbGridDstAccount.Columns[2].Visible = false;
            dbGridDstAccount.Columns[3].Visible = false;
            dbGridDstAccount.ClearSelection();
        }

        private void SetEditAll(bool bEdit)
        {
            txtTransactionName.ReadOnly = !bEdit;
            txtTransactionDesc.ReadOnly = !bEdit;
            chkSetTime.Enabled = bEdit;
            dtPickerMadeDate.Enabled = bEdit && chkSetTime.Checked;
            dtPickerMadeTime.Enabled = bEdit && chkSetTime.Checked;
            dbGridCategory.Enabled = bEdit;
            dbGridSrcAccount.Enabled = bEdit && (dbGridCategory.SelectedRows.Count != 0);
            dbGridDstAccount.Enabled = bEdit && (dbGridCategory.SelectedRows.Count != 0);
            txtSrcAmount.ReadOnly = !(bEdit && (dbGridSrcAccount.SelectedRows.Count != 0));
            txtDstAmount.ReadOnly = !(bEdit && (dbGridDstAccount.SelectedRows.Count != 0));
            btnSchedule.Enabled = !bEdit;
            dbGridTransaction.Enabled = !bEdit;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;            
            if (bOK)
            {
                if (txtTransactionName.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNameTransactionBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (dbGridCategory.SelectedRows.Count == 0)
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoCategoryAssigned4Transaction, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                } 
            }
            if (bOK)
            {
                if (sFlowDirect >= 0) 
                {
                    if (dbGridDstAccount.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoDstAccount, PersonalBookKeeper.Properties.Resources.strErrTitle);
                        bOK = false;
                    }
                    else if (txtDstAmount.Text == "")
                    {
                        MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrAmountInBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                        bOK = false;
                    }
                }
            }
            if (bOK)
            {
                if (sFlowDirect <= 0)
                {
                    if (dbGridSrcAccount.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoSrcAccount, PersonalBookKeeper.Properties.Resources.strErrTitle);
                        bOK = false;
                    }
                    else if (txtSrcAmount.Text == "")
                    {
                        MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrAmountOutBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                        bOK = false;
                    }
                }
            }
            return bOK;
        }

        private void UpdateEditForm()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = "";
            txtID.Text = dbGridTransaction.SelectedRows[0].Cells[0].Value.ToString();
            txtTransactionName.Text = dbGridTransaction.SelectedRows[0].Cells[8].Value.ToString();
            txtTransactionDesc.Text = dbGridTransaction.SelectedRows[0].Cells[9].Value.ToString();
            dtPickerMadeDate.Value = Convert.ToDateTime(dbGridTransaction.SelectedRows[0].Cells[11].Value);
            dtPickerMadeTime.Value = Convert.ToDateTime(dbGridTransaction.SelectedRows[0].Cells[11].Value);
            if (dbGridTransaction.SelectedRows[0].Cells[13].Value != DBNull.Value)
            {
                short sDecPoint = 0;
                if (dbGridTransaction.SelectedRows[0].Cells[14].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dbGridTransaction.SelectedRows[0].Cells[14].Value);
                Decimal decAccountBalance = Convert.ToDecimal(dbGridTransaction.SelectedRows[0].Cells[13].Value);
                txtSrcAmount.Text = decAccountBalance.ToString(String.Format("N{0}", sDecPoint), nfi);
                for (int i = 0; i < dbGridSrcAccount.Rows.Count; i++)
                {
                    if (dbGridSrcAccount.Rows[i].Cells[0].Value.ToString() == dbGridTransaction.SelectedRows[0].Cells[3].Value.ToString())
                    {
                        dbGridSrcAccount.Rows[i].Selected = true;
                        dbGridSrcAccount.CurrentCell = dbGridSrcAccount.Rows[i].Cells[1];
                        break;
                    }
                }
            }
            else
            {
                txtSrcAmount.Text = "";
                dbGridSrcAccount.ClearSelection();
            }
            if (dbGridTransaction.SelectedRows[0].Cells[16].Value != DBNull.Value)
            {
                short sDecPoint = 0;
                if (dbGridTransaction.SelectedRows[0].Cells[17].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dbGridTransaction.SelectedRows[0].Cells[17].Value);
                Decimal decAccountBalance = Convert.ToDecimal(dbGridTransaction.SelectedRows[0].Cells[16].Value);
                txtDstAmount.Text = decAccountBalance.ToString(String.Format("N{0}", sDecPoint), nfi);
                for (int i = 0; i < dbGridDstAccount.Rows.Count; i++)
                {
                    if (dbGridDstAccount.Rows[i].Cells[0].Value.ToString() == dbGridTransaction.SelectedRows[0].Cells[5].Value.ToString())
                    {
                        dbGridDstAccount.Rows[i].Selected = true;
                        dbGridDstAccount.CurrentCell = dbGridDstAccount.Rows[i].Cells[1];
                        break;
                    }
                }
            }
            else
            {
                txtDstAmount.Text = "";
                dbGridDstAccount.ClearSelection();
            }
            for (int i = 0; i < dbGridCategory.Rows.Count; i++)
            {
                if (dbGridCategory.Rows[i].Cells[0].Value.ToString() == dbGridTransaction.SelectedRows[0].Cells[1].Value.ToString())
                {
                    dbGridCategory.Rows[i].Selected = true;
                    dbGridCategory.CurrentCell = dbGridCategory.Rows[i].Cells[1];
                    break;
                }
            }
        }

        private void ClearEditForm()
        {
            txtID.Text = "";
            txtTransactionName.Text = "";
            txtTransactionDesc.Text = "";
            chkSetTime.Checked = false;
            dtPickerMadeDate.Value = DateTime.Now;
            dtPickerMadeTime.Value = DateTime.Now;
            txtSrcAmount.Text = "";
            txtDstAmount.Text = "";
            dbGridCategory.ClearSelection();
            dbGridSrcAccount.ClearSelection();
            dbGridDstAccount.ClearSelection();
        }

        private void CommitChange()
        {

            if (chkSetTime.Checked)
            {
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[TRANSACTION]([CATEGORY_ID],[NAME],[DESCRIPTION],[MADE_TIME],[SRC_ACC_ID],[SRC_AMOUNT],[DST_ACC_ID],[DST_AMOUNT]) " +
                    @"VALUES(@CatID,@TransName,@TransDesc,@MadeTime,@SrcAccID,@SrcAmount,@DstAccID,@DstAmount)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@CatID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@TransDesc", SqlDbType.NVarChar, 4000));
                cmdInsert.Parameters.Add(new SqlParameter("@MadeTime", SqlDbType.DateTime2));
                cmdInsert.Parameters.Add(new SqlParameter("@SrcAccID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@SrcAmount", SqlDbType.Decimal));
                cmdInsert.Parameters.Add(new SqlParameter("@DstAccID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@DstAmount", SqlDbType.Decimal));
                cmdInsert.Parameters["@CatID"].Value = dbGridCategory.SelectedRows[0].Cells[0].Value;
                cmdInsert.Parameters["@TransName"].Value = txtTransactionName.Text;
                cmdInsert.Parameters["@TransDesc"].Value = txtTransactionDesc.Text;
                cmdInsert.Parameters["@MadeTime"].Value = (dtPickerMadeDate.Value.Date + dtPickerMadeTime.Value.TimeOfDay).ToUniversalTime();
                if (dbGridSrcAccount.SelectedRows.Count > 0)
                {
                    cmdInsert.Parameters["@SrcAccID"].Value = dbGridSrcAccount.SelectedRows[0].Cells[0].Value;
                    cmdInsert.Parameters["@SrcAmount"].Value = txtSrcAmount.Text;
                }
                else
                {
                    cmdInsert.Parameters["@SrcAccID"].Value = DBNull.Value;
                    cmdInsert.Parameters["@SrcAmount"].Value = DBNull.Value;
                }
                if (dbGridDstAccount.SelectedRows.Count > 0)
                {
                    cmdInsert.Parameters["@DstAccID"].Value = dbGridDstAccount.SelectedRows[0].Cells[0].Value;
                    cmdInsert.Parameters["@DstAmount"].Value = txtDstAmount.Text;
                }
                else
                {
                    cmdInsert.Parameters["@DstAccID"].Value = DBNull.Value;
                    cmdInsert.Parameters["@DstAmount"].Value = DBNull.Value;
                }
                cmdInsert.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[TRANSACTION]([CATEGORY_ID],[NAME],[DESCRIPTION],[SRC_ACC_ID],[SRC_AMOUNT],[DST_ACC_ID],[DST_AMOUNT]) " +
                    @"VALUES(@CatID,@TransName,@TransDesc,@SrcAccID,@SrcAmount,@DstAccID,@DstAmount)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@CatID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@TransDesc", SqlDbType.NVarChar, 4000));
                cmdInsert.Parameters.Add(new SqlParameter("@SrcAccID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@SrcAmount", SqlDbType.Decimal));
                cmdInsert.Parameters.Add(new SqlParameter("@DstAccID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@DstAmount", SqlDbType.Decimal));
                cmdInsert.Parameters["@CatID"].Value = dbGridCategory.SelectedRows[0].Cells[0].Value;
                cmdInsert.Parameters["@TransName"].Value = txtTransactionName.Text;
                cmdInsert.Parameters["@TransDesc"].Value = txtTransactionDesc.Text;
                if (dbGridSrcAccount.SelectedRows.Count > 0)
                {
                    cmdInsert.Parameters["@SrcAccID"].Value = dbGridSrcAccount.SelectedRows[0].Cells[0].Value;
                    cmdInsert.Parameters["@SrcAmount"].Value = txtSrcAmount.Text;
                }
                else
                {
                    cmdInsert.Parameters["@SrcAccID"].Value = DBNull.Value;
                    cmdInsert.Parameters["@SrcAmount"].Value = DBNull.Value;
                }
                if (dbGridDstAccount.SelectedRows.Count > 0)
                {
                    cmdInsert.Parameters["@DstAccID"].Value = dbGridDstAccount.SelectedRows[0].Cells[0].Value;
                    cmdInsert.Parameters["@DstAmount"].Value = txtDstAmount.Text;
                }
                else
                {
                    cmdInsert.Parameters["@DstAccID"].Value = DBNull.Value;
                    cmdInsert.Parameters["@DstAmount"].Value = DBNull.Value;
                }
                cmdInsert.ExecuteNonQuery();
            }
        }

        private void Add2Schedule()
        {
            SqlCommand cmdInsertSchedule = new SqlCommand(@"INSERT INTO [dbo].[SCHEDULE]([CATEGORY_ID],[NAME],[DESCRIPTION],[LAST_MADE_TIME],[SRC_ACC_ID],[SRC_AMOUNT],[DST_ACC_ID],[DST_AMOUNT]) "
                + @"VALUES(@CatID,@SchedName,@SchedDesc,@LastMadeTime,@SrcAccID,@SrcAmount,@DstAccID,@DstAmount)", dbConn);
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@CatID", SqlDbType.BigInt));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@SchedName", SqlDbType.NVarChar, 50));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@SchedDesc", SqlDbType.NVarChar, 4000));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@LastMadeTime", SqlDbType.DateTime2));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@SrcAccID", SqlDbType.BigInt));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@SrcAmount", SqlDbType.Decimal));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@DstAccID", SqlDbType.BigInt));
            cmdInsertSchedule.Parameters.Add(new SqlParameter("@DstAmount", SqlDbType.Decimal));
            cmdInsertSchedule.Parameters["@CatID"].Value = dbGridTransaction.SelectedRows[0].Cells[1].Value;
            cmdInsertSchedule.Parameters["@SchedName"].Value = dbGridTransaction.SelectedRows[0].Cells[8].Value;
            cmdInsertSchedule.Parameters["@SchedDesc"].Value = dbGridTransaction.SelectedRows[0].Cells[9].Value;
            cmdInsertSchedule.Parameters["@LastMadeTime"].Value = dbGridTransaction.SelectedRows[0].Cells[11].Value;
            cmdInsertSchedule.Parameters["@SrcAccID"].Value = dbGridTransaction.SelectedRows[0].Cells[3].Value;
            cmdInsertSchedule.Parameters["@SrcAmount"].Value = dbGridTransaction.SelectedRows[0].Cells[13].Value;
            cmdInsertSchedule.Parameters["@DstAccID"].Value = dbGridTransaction.SelectedRows[0].Cells[5].Value;
            cmdInsertSchedule.Parameters["@DstAmount"].Value = dbGridTransaction.SelectedRows[0].Cells[15].Value;
            cmdInsertSchedule.ExecuteNonQuery();
        }
        
        private void DeleteFromTransaction()
        {
            SqlCommand cmdDeleteTransaction = new SqlCommand(@"UPDATE [dbo].[TRANSACTION] SET [DELETED]=1 WHERE ID=@TransID", dbConn);
            cmdDeleteTransaction.Parameters.Add(new SqlParameter("@TransID", SqlDbType.BigInt));
            cmdDeleteTransaction.Parameters["@TransID"].Value = txtID.Text;
            cmdDeleteTransaction.ExecuteNonQuery();
        }
    }
}
