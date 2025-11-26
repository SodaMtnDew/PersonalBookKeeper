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
    public partial class ScheduleForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        SqlCommand cmdGetSchedule;
        short sFlowDirect;

        public ScheduleForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            parentForm = parent2Set;
            cmdGetSchedule = null;
            sFlowDirect = 0;
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            labelDbSchedules.Text = PersonalBookKeeper.Properties.Resources.strTxtSchedules;
            rBtnAll.Text = PersonalBookKeeper.Properties.Resources.strTxtAllSchedules;
            rBtnDue.Text = PersonalBookKeeper.Properties.Resources.strTxtDueSchedules;
            btnRefresh.Text = PersonalBookKeeper.Properties.Resources.strBtnRefresh;
            btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddSchedule;
            btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModSchedule;
            btnDel.Text = PersonalBookKeeper.Properties.Resources.strBtnDelSchedule;
            btnRun.Text = PersonalBookKeeper.Properties.Resources.strBtnRunSchedule;
            labelSrcAccount.Text = PersonalBookKeeper.Properties.Resources.strTxtSrcAccount;
            labelCategory.Text = PersonalBookKeeper.Properties.Resources.strTxtCategory;
            labelDstAccount.Text = PersonalBookKeeper.Properties.Resources.strTxtDstAccount;
            labelScheduleName.Text = PersonalBookKeeper.Properties.Resources.strTxtNameSchedule;
            labelScheduleDesc.Text = PersonalBookKeeper.Properties.Resources.strTxtDescSchedule;
            labelPeriod.Text = PersonalBookKeeper.Properties.Resources.strTxtPeriodInDay;
            labelLastUpdate.Text = PersonalBookKeeper.Properties.Resources.strTxtLastMade;
            labelSrcAmount.Text = PersonalBookKeeper.Properties.Resources.strTxtAmountOut;
            labelDstAmount.Text = PersonalBookKeeper.Properties.Resources.strTxtAmountIn;
            rBtnAll.Checked = true;
            RefreshSchedules();
            InitDbGridSchedule();
            RefreshCategories();
            RefreshAccounts();
            dbGridSchedule.ClearSelection();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddSchedule)
            {
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmAdd;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelAdd;
                ClearEditForm();
                SetEditAll(true);
                parentForm.LockTab();
            }
            else
            {
                if (ChkEditForm())
                {
                    SetEditAll(false);
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddSchedule;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModSchedule;
                    CommitChange();
                    ClearEditForm();
                    RefreshSchedules();
                    parentForm.UnlockTab();
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == PersonalBookKeeper.Properties.Resources.strBtnAddSchedule)
            {
                if (dbGridSchedule.SelectedRows.Count == 0)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoSchedule2Modify, PersonalBookKeeper.Properties.Resources.strErrTitle);
                else
                {
                    btnAdd.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirmMod;
                    btnMod.Text = PersonalBookKeeper.Properties.Resources.strTxtCancelMod;
                    SetEditAll(true);
                    parentForm.LockTab();
                }
            }
            else
            {
                SetEditAll(false);
                btnAdd.Text = PersonalBookKeeper.Properties.Resources.strBtnAddSchedule;
                btnMod.Text = PersonalBookKeeper.Properties.Resources.strBtnModSchedule;
                if (dbGridSchedule.SelectedRows.Count > 0)
                    UpdateEditForm();
                else
                    ClearEditForm();
                parentForm.UnlockTab();               
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dbGridSchedule.SelectedRows.Count == 0)
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoSchedule2Delete, PersonalBookKeeper.Properties.Resources.strErrTitle);
            else
            {
                DeleteFromSchedule();
                RefreshSchedules();
                dbGridSchedule.ClearSelection();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (dbGridSchedule.SelectedRows.Count == 0)
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoSchedule2MakeTransaction, PersonalBookKeeper.Properties.Resources.strErrTitle);
            else
            {
                if (MessageBox.Show(PersonalBookKeeper.Properties.Resources.strHintTransactionFromSchedule, PersonalBookKeeper.Properties.Resources.strHintTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Add2Transaction();
                    RefreshSchedules();
                    dbGridSchedule.ClearSelection();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshSchedules();
        }

        private void dbGridSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dbGridSchedule.SelectedRows.Count > 0)
                UpdateEditForm();
            else
                ClearEditForm();
        }

        private void txtPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false))
                e.Handled = true;
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

        private void dbGridCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (!dbGridSchedule.Enabled)
            { 
                if (dbGridCategory.SelectedRows.Count > 0)
                {
                    sFlowDirect = Convert.ToInt16(dbGridCategory.SelectedRows[0].Cells[2].Value);
                    dbGridSrcAccount.Enabled = true;
                    txtSrcAmount.ReadOnly = false;
                    dbGridDstAccount.Enabled = true;
                    txtDstAmount.ReadOnly = false;
                    if (sFlowDirect > 0)
                    {
                        dbGridSrcAccount.ClearSelection();
                        dbGridSrcAccount.Enabled = false;
                        txtSrcAmount.Text = "";
                        txtSrcAmount.ReadOnly = true;
                    }
                    if (sFlowDirect < 0)
                    {
                        dbGridDstAccount.ClearSelection();
                        dbGridDstAccount.Enabled = false;
                        txtDstAmount.Text = "";
                        txtDstAmount.ReadOnly = true;
                    }

                }
            }
        }

        private void dbGridSchedule_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int idx1st = e.RowIndex;
            int num2Add = e.RowCount;
            for (int i = idx1st; i < idx1st + num2Add; i++)
            {
                short sSrcDecPoint = -1, sDstDecPoint = -1;
                dgv.Rows[i].Cells[14].Style.ForeColor = Color.Red;
                if (dgv.Rows[i].Cells[15].Value != DBNull.Value)
                    sSrcDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[15].Value);
                if (sSrcDecPoint >= 0)
                    dgv.Rows[i].Cells[14].Style.Format = String.Format("N{0}", sSrcDecPoint);
                if (dgv.Rows[i].Cells[18].Value != DBNull.Value)
                    sDstDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[18].Value);
                if (sDstDecPoint >= 0)
                    dgv.Rows[i].Cells[17].Style.Format = String.Format("N{0}", sDstDecPoint);
            }
        }

        private void dbGridSrcAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (!dbGridSchedule.Enabled)
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
            if (!dbGridSchedule.Enabled)
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
            if (!dbGridSchedule.Enabled)
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
            if (!dbGridSchedule.Enabled)
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

        private void ScheduleForm_SizeChanged(object sender, EventArgs e)
        {
            dbGridSchedule.Height = this.Height / 4;
            dbGridSchedule.Width = this.Width - 24;
            if (dbGridSchedule.ColumnCount > 0)
            {
                dbGridSchedule.Columns[8].Width = (dbGridSchedule.Width - 20) / 9;
                dbGridSchedule.Columns[9].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[10].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[11].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[12].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[13].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[14].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[16].Width = dbGridSchedule.Columns[8].Width;
                dbGridSchedule.Columns[17].Width = dbGridSchedule.Width - 20 - dbGridSchedule.Columns[8].Width * 8;
            }
            btnRefresh.Left = this.Width - 12 - btnRefresh.Width;
            rBtnDue.Left = btnRefresh.Left - 12 - rBtnDue.Width;
            rBtnAll.Left = rBtnDue.Left - 12 - rBtnAll.Width;
            btnAdd.Top = dbGridSchedule.Top + dbGridSchedule.Height + 6;
            btnMod.Top = btnAdd.Top;
            btnMod.Left = btnAdd.Left + btnAdd.Width + 6;
            btnDel.Top = btnMod.Top;
            btnDel.Left = btnMod.Left + btnDel.Width + 6;
            btnRun.Top = btnDel.Top;
            btnRun.Left = btnDel.Left + btnRun.Width + 6;
            labelDstAccount.Top = btnRun.Top;
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
            labelScheduleName.Top = dbGridSrcAccount.Top;
            txtScheduleName.Top = labelScheduleName.Top;
            txtScheduleName.Width = dbGridSrcAccount.Width * 2 + 6;
            txtScheduleName.Left = dbGridSrcAccount.Left - 6 - txtScheduleName.Width;
            labelDstAmount.Top = this.Height - 12 - labelDstAmount.Height;
            txtDstAmount.Top = labelDstAmount.Top;
            txtDstAmount.Left = txtScheduleName.Left;
            txtDstAmount.Width = txtScheduleName.Width;
            labelSrcAmount.Top = labelDstAmount.Top - 6 - labelSrcAmount.Height;
            txtSrcAmount.Top = labelSrcAmount.Top;
            txtSrcAmount.Left = txtScheduleName.Left;
            txtSrcAmount.Width = txtScheduleName.Width;
            labelLastUpdate.Top = labelSrcAmount.Top - 6 - labelLastUpdate.Height;
            txtLastUpdate.Top = labelLastUpdate.Top;
            txtLastUpdate.Left = txtScheduleName.Left;
            txtLastUpdate.Width = txtScheduleName.Width;
            labelPeriod.Top = labelLastUpdate.Top - 6 - labelPeriod.Height;
            txtPeriod.Top = labelPeriod.Top;
            txtPeriod.Left = txtScheduleName.Left;
            txtPeriod.Width = txtScheduleName.Width;
            labelScheduleDesc.Top = txtScheduleName.Top + txtScheduleName.Height + 6;
            txtScheduleDesc.Top = labelScheduleDesc.Top;
            txtScheduleDesc.Left = txtScheduleName.Left;
            txtScheduleDesc.Width = txtScheduleName.Width;
            txtScheduleDesc.Height = labelPeriod.Top - 6 - txtScheduleDesc.Top;
        }

        private void InitDbGridSchedule()
        {
            dbGridSchedule.Columns[0].Visible = false;
            dbGridSchedule.Columns[1].Visible = false;
            dbGridSchedule.Columns[2].Visible = false;
            dbGridSchedule.Columns[3].Visible = false;
            dbGridSchedule.Columns[4].Visible = false;
            dbGridSchedule.Columns[5].Visible = false;
            dbGridSchedule.Columns[6].Visible = false;
            dbGridSchedule.Columns[7].Visible = false;
            dbGridSchedule.Columns[8].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtNameSchedule;
            dbGridSchedule.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[9].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtDescSchedule;
            dbGridSchedule.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[10].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtCategory;
            dbGridSchedule.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[11].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtPeriodInDay;
            dbGridSchedule.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[12].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtLastMade;
            dbGridSchedule.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[13].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtSrcAccount;
            dbGridSchedule.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[14].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtAmountOut;
            dbGridSchedule.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridSchedule.Columns[15].Visible = false;
            dbGridSchedule.Columns[16].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtDstAccount;
            dbGridSchedule.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[17].HeaderText = PersonalBookKeeper.Properties.Resources.strTxtAmountIn;
            dbGridSchedule.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridSchedule.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridSchedule.Columns[18].Visible = false;
        }

        private void RefreshSchedules()
        {
            if (cmdGetSchedule == null)
            {
                cmdGetSchedule = new SqlCommand(@"SELECT * FROM [dbo].[GetSchedules](@Filtered)", dbConn);
                cmdGetSchedule.Parameters.Add(new SqlParameter("@Filtered", SqlDbType.Bit));
            }
            if(rBtnAll.Checked)
                cmdGetSchedule.Parameters["@Filtered"].Value = 0;
            else
                cmdGetSchedule.Parameters["@Filtered"].Value = 1;
            DataTable dtSchedule = new DataTable();
            SqlDataReader dr4GetSchedule = cmdGetSchedule.ExecuteReader();
            dtSchedule.Load(dr4GetSchedule);
            dbGridSchedule.DataSource = dtSchedule;
            dbGridSchedule.ClearSelection();
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
            txtScheduleName.ReadOnly = !bEdit;
            txtScheduleDesc.ReadOnly = !bEdit;
            txtPeriod.ReadOnly = !bEdit;
            dbGridCategory.Enabled = bEdit;
            dbGridSrcAccount.Enabled = bEdit && (dbGridCategory.SelectedRows.Count != 0);
            dbGridDstAccount.Enabled = bEdit && (dbGridCategory.SelectedRows.Count != 0);
            txtSrcAmount.ReadOnly = !(bEdit && (dbGridSrcAccount.SelectedRows.Count != 0));
            txtDstAmount.ReadOnly = !(bEdit && (dbGridDstAccount.SelectedRows.Count != 0));
            btnDel.Enabled = !bEdit;
            btnRun.Enabled = !bEdit;
            dbGridSchedule.Enabled = !bEdit;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;
            if (bOK)
            {
                if (txtScheduleName.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNameScheduleBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (dbGridCategory.SelectedRows.Count == 0)
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoCategoryAssigned4Schedule, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
            }
            if (bOK)
            {
                if (txtPeriod.Text == "")
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrPeriodBlank, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
                else
                {
                    short sDays = Convert.ToInt16(txtPeriod.Text);
                    if ((sDays < 7) || (sDays > 365))
                    {
                        MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrPeriodInvalid, PersonalBookKeeper.Properties.Resources.strErrTitle);
                        bOK = false;
                    }
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
            txtID.Text = dbGridSchedule.SelectedRows[0].Cells[0].Value.ToString();
            txtScheduleName.Text = dbGridSchedule.SelectedRows[0].Cells[8].Value.ToString();
            txtScheduleDesc.Text = dbGridSchedule.SelectedRows[0].Cells[9].Value.ToString();
            txtPeriod.Text = dbGridSchedule.SelectedRows[0].Cells[11].Value.ToString();
            txtLastUpdate.Text = dbGridSchedule.SelectedRows[0].Cells[12].Value.ToString();
            txtSrcAmount.Text = "";
            dbGridSrcAccount.ClearSelection();
            if (dbGridSchedule.SelectedRows[0].Cells[3].Value != DBNull.Value)
            {
                short sDecPoint = 0;
                if (dbGridSchedule.SelectedRows[0].Cells[15].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dbGridSchedule.SelectedRows[0].Cells[15].Value);
                Decimal decAccountBalance = Convert.ToDecimal(dbGridSchedule.SelectedRows[0].Cells[14].Value);
                txtSrcAmount.Text = decAccountBalance.ToString(String.Format("N{0}", sDecPoint), nfi);
                for (int i = 0; i < dbGridSrcAccount.Rows.Count; i++)
                {
                    if (dbGridSrcAccount.Rows[i].Cells[0].Value.ToString() == dbGridSchedule.SelectedRows[0].Cells[3].Value.ToString())
                    {
                        dbGridSrcAccount.Rows[i].Selected = true;
                        dbGridSrcAccount.CurrentCell = dbGridSrcAccount.Rows[i].Cells[1];
                        break;
                    }
                }
            }
            txtDstAmount.Text = "";
            dbGridDstAccount.ClearSelection();
            if (dbGridSchedule.SelectedRows[0].Cells[5].Value != DBNull.Value)
            {
                short sDecPoint = 0;
                if (dbGridSchedule.SelectedRows[0].Cells[18].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dbGridSchedule.SelectedRows[0].Cells[18].Value);
                Decimal decAccountBalance = Convert.ToDecimal(dbGridSchedule.SelectedRows[0].Cells[17].Value);
                txtDstAmount.Text = decAccountBalance.ToString(String.Format("N{0}", sDecPoint), nfi);
                for (int i = 0; i < dbGridDstAccount.Rows.Count; i++)
                {
                    if (dbGridDstAccount.Rows[i].Cells[0].Value.ToString() == dbGridSchedule.SelectedRows[0].Cells[5].Value.ToString())
                    {
                        dbGridDstAccount.Rows[i].Selected = true;
                        dbGridDstAccount.CurrentCell = dbGridDstAccount.Rows[i].Cells[1];
                        break;
                    }
                }
            }
            for (int i = 0; i < dbGridCategory.Rows.Count; i++)
            {
                if (dbGridCategory.Rows[i].Cells[0].Value.ToString() == dbGridSchedule.SelectedRows[0].Cells[1].Value.ToString())
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
            txtScheduleName.Text = "";
            txtScheduleDesc.Text = "";
            txtPeriod.Text = "";
            txtLastUpdate.Text = "";
            txtSrcAmount.Text = "";
            txtDstAmount.Text = "";
            dbGridCategory.ClearSelection();
            dbGridSrcAccount.ClearSelection();
            dbGridDstAccount.ClearSelection();
        }

        private void CommitChange()
        {
            if (txtID.Text != "")
            {
                SqlCommand cmdUpdate = new SqlCommand(@"UPDATE [dbo].[SCHEDULE] SET [CATEGORY_ID]=@CatID,[NAME]=@SchedName,[DESCRIPTION]=@SchedDesc," +
                    @"[PERIOD_IN_DAYS]=@PeriodInDays,[SRC_ACC_ID]=@SrcAccID,[SRC_AMOUNT]=@SrcAmount,[DST_ACC_ID]=@DstAccID,[DST_AMOUNT]=@DstAmount " +
                    @"WHERE [ID]=@SchedID", dbConn);
                cmdUpdate.Parameters.Add(new SqlParameter("@SchedID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@CatID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@SchedName", SqlDbType.NVarChar, 50));
                cmdUpdate.Parameters.Add(new SqlParameter("@SchedDesc", SqlDbType.NVarChar, 4000));
                cmdUpdate.Parameters.Add(new SqlParameter("@PeriodInDays", SqlDbType.SmallInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@SrcAccID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@SrcAmount", SqlDbType.Decimal));
                cmdUpdate.Parameters.Add(new SqlParameter("@DstAccID", SqlDbType.BigInt));
                cmdUpdate.Parameters.Add(new SqlParameter("@DstAmount", SqlDbType.Decimal));
                cmdUpdate.Parameters["@CatID"].Value = dbGridCategory.SelectedRows[0].Cells[0].Value;
                cmdUpdate.Parameters["@SchedID"].Value = txtID.Text;
                cmdUpdate.Parameters["@SchedName"].Value = txtScheduleName.Text;
                cmdUpdate.Parameters["@SchedDesc"].Value = txtScheduleDesc.Text;
                cmdUpdate.Parameters["@PeriodInDays"].Value = txtPeriod.Text;
                if (dbGridSrcAccount.SelectedRows.Count > 0)
                {
                    cmdUpdate.Parameters["@SrcAccID"].Value = dbGridSrcAccount.SelectedRows[0].Cells[0].Value;
                    cmdUpdate.Parameters["@SrcAmount"].Value = txtSrcAmount.Text;
                }
                else
                {
                    cmdUpdate.Parameters["@SrcAccID"].Value = DBNull.Value;
                    cmdUpdate.Parameters["@SrcAmount"].Value = DBNull.Value;
                }
                if (dbGridDstAccount.SelectedRows.Count > 0)
                {
                    cmdUpdate.Parameters["@DstAccID"].Value = dbGridDstAccount.SelectedRows[0].Cells[0].Value;
                    cmdUpdate.Parameters["@DstAmount"].Value = txtDstAmount.Text;
                }
                else
                {
                    cmdUpdate.Parameters["@DstAccID"].Value = DBNull.Value;
                    cmdUpdate.Parameters["@DstAmount"].Value = DBNull.Value;
                }
                cmdUpdate.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO [dbo].[SCHEDULE]([CATEGORY_ID],[NAME],[DESCRIPTION],[PERIOD_IN_DAYS],[SRC_ACC_ID],[SRC_AMOUNT],[DST_ACC_ID],[DST_AMOUNT]) " +
                    @"VALUES(@CatID,@SchedName,@SchedDesc,@PeriodInDays,@SrcAccID,@SrcAmount,@DstAccID,@DstAmount)", dbConn);
                cmdInsert.Parameters.Add(new SqlParameter("@CatID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@SchedName", SqlDbType.NVarChar, 50));
                cmdInsert.Parameters.Add(new SqlParameter("@SchedDesc", SqlDbType.NVarChar, 4000));
                cmdInsert.Parameters.Add(new SqlParameter("@PeriodInDays", SqlDbType.SmallInt));
                cmdInsert.Parameters.Add(new SqlParameter("@SrcAccID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@SrcAmount", SqlDbType.Decimal));
                cmdInsert.Parameters.Add(new SqlParameter("@DstAccID", SqlDbType.BigInt));
                cmdInsert.Parameters.Add(new SqlParameter("@DstAmount", SqlDbType.Decimal));
                cmdInsert.Parameters["@CatID"].Value = dbGridCategory.SelectedRows[0].Cells[0].Value;
                cmdInsert.Parameters["@SchedName"].Value = txtScheduleName.Text;
                cmdInsert.Parameters["@SchedDesc"].Value = txtScheduleDesc.Text;
                cmdInsert.Parameters["@PeriodInDays"].Value = txtPeriod.Text;
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

        private void Add2Transaction()
        {
            DateTime dt2Set = DateTime.UtcNow;
            DateTimePickerForm dtPickForm = new DateTimePickerForm();
            if (dtPickForm.ShowDialog() == DialogResult.OK)
                dt2Set = dtPickForm.GetPickedUTC();
            SqlCommand cmdInsertTransaction = new SqlCommand(@"INSERT INTO [dbo].[TRANSACTION]([CATEGORY_ID],[NAME],[DESCRIPTION],[MADE_TIME],[SRC_ACC_ID],[SRC_AMOUNT],[DST_ACC_ID],[DST_AMOUNT]) "
                + @"VALUES(@CatID,@TransName,@TransDesc,@MadeTime,@SrcAccID,@SrcAmount,@DstAccID,@DstAmount)", dbConn),
                cmdUpdateSchedule = new SqlCommand(@"UPDATE [dbo].[SCHEDULE] SET [LAST_MADE_TIME]=@LastMadeTime WHERE [ID]=@SchedID", dbConn);
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@CatID", SqlDbType.BigInt));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar, 50));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@TransDesc", SqlDbType.NVarChar, 4000));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@MadeTime", SqlDbType.DateTime2));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@SrcAccID", SqlDbType.BigInt));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@SrcAmount", SqlDbType.Decimal));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@DstAccID", SqlDbType.BigInt));
            cmdInsertTransaction.Parameters.Add(new SqlParameter("@DstAmount", SqlDbType.Decimal));
            cmdUpdateSchedule.Parameters.Add(new SqlParameter("@SchedID", SqlDbType.BigInt));
            cmdUpdateSchedule.Parameters.Add(new SqlParameter("@LastMadeTime", SqlDbType.DateTime2));
            cmdInsertTransaction.Parameters["@CatID"].Value = dbGridSchedule.SelectedRows[0].Cells[1].Value;
            cmdInsertTransaction.Parameters["@TransName"].Value = dbGridSchedule.SelectedRows[0].Cells[8].Value;
            cmdInsertTransaction.Parameters["@TransDesc"].Value = dbGridSchedule.SelectedRows[0].Cells[9].Value;
            cmdInsertTransaction.Parameters["@MadeTime"].Value = dt2Set;
            cmdInsertTransaction.Parameters["@SrcAccID"].Value = dbGridSchedule.SelectedRows[0].Cells[3].Value;
            cmdInsertTransaction.Parameters["@SrcAmount"].Value = dbGridSchedule.SelectedRows[0].Cells[14].Value;
            cmdInsertTransaction.Parameters["@DstAccID"].Value = dbGridSchedule.SelectedRows[0].Cells[5].Value;
            cmdInsertTransaction.Parameters["@DstAmount"].Value = dbGridSchedule.SelectedRows[0].Cells[17].Value;
            cmdUpdateSchedule.Parameters["@SchedID"].Value = dbGridSchedule.SelectedRows[0].Cells[0].Value;
            cmdUpdateSchedule.Parameters["@LastMadeTime"].Value = dt2Set;
            cmdInsertTransaction.ExecuteNonQuery();
            cmdUpdateSchedule.ExecuteNonQuery();
        }

        private void DeleteFromSchedule()
        {
            SqlCommand cmdDeleteSchedule = new SqlCommand(@"UPDATE [dbo].[SCHEDULE] SET [DELETED]=1 WHERE ID=@SchedID", dbConn);
            cmdDeleteSchedule.Parameters.Add(new SqlParameter("@SchedID", SqlDbType.BigInt));
            cmdDeleteSchedule.Parameters["@SchedID"].Value = dbGridSchedule.SelectedRows[0].Cells[0].Value;
            cmdDeleteSchedule.ExecuteNonQuery();
        }
    }
}
