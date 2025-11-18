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
    public partial class MainForm : Form
    {
        ContainerForm parentForm;
        SqlConnection dbConn;
        SqlCommand cmdGetBalance, cmdGetCashflow;
        public MainForm(SqlConnection dbConn2Set, ContainerForm parent2Set)
        {
            InitializeComponent();
            dbConn = dbConn2Set;
            parentForm = parent2Set;
            cmdGetBalance = null;
            cmdGetCashflow = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelBalance.Text = PersonalBookKeeper.Properties.Resources.strTxtTitleBalance;
            labelCashflow.Text = PersonalBookKeeper.Properties.Resources.strTxtTitleCashflow;
            labelYear.Text = PersonalBookKeeper.Properties.Resources.strTxtYear;
            labelMonth.Text = PersonalBookKeeper.Properties.Resources.strTxtMonth;
            btnRefresh.Text = PersonalBookKeeper.Properties.Resources.strBtnRefresh;
            cmbOptions.Items.Add(PersonalBookKeeper.Properties.Resources.strTxtThisMonth);
            cmbOptions.Items.Add(PersonalBookKeeper.Properties.Resources.strTxtLastMonth);
            cmbOptions.Items.Add(PersonalBookKeeper.Properties.Resources.strTxtThisYear);
            cmbOptions.Items.Add(PersonalBookKeeper.Properties.Resources.strTxtLastYear);
            cmbOptions.Items.Add(PersonalBookKeeper.Properties.Resources.strTxtCustomize);
            cmbOptions.SelectedIndex = 0;
            RefreshBalance();
            RefreshCashflow();
            dbGridBalance.ClearSelection();
            dbGridCashflow.ClearSelection();
            this.OnSizeChanged(EventArgs.Empty);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        { 
            if (ChkEditForm())
            {
                RefreshBalance();
                RefreshCashflow();
            }
        }

        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOptions.SelectedIndex == 4)
            {
                txtYear.ReadOnly = false;
                txtMonth.ReadOnly = false;
            }
            else
            {
                txtYear.ReadOnly = true;
                txtMonth.ReadOnly = true;
            }
        }

        private void dbGridBalance_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int idx1st = e.RowIndex;
            int num2Add = e.RowCount;
            for (int i = idx1st; i < idx1st + num2Add; i++)
            {
                short sDecPoint = -1, 
                    sTypeFlag = Convert.ToInt16(dgv.Rows[i].Cells[2].Value);
                if (sTypeFlag >= 0)
                    dgv.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                else
                    dgv.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                if (dgv.Rows[i].Cells[3].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[3].Value);
                if (sDecPoint >= 0)
                    dgv.Rows[i].Cells[1].Style.Format = String.Format("N{0}", sDecPoint);
            }
        }

        private void dbGridCashflow_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int idx1st = e.RowIndex;
            int num2Add = e.RowCount;
            for (int i = idx1st; i < idx1st + num2Add; i++)
            {
                short sDecPoint = -1,
                    sFlowDirect = Convert.ToInt16(dgv.Rows[i].Cells[2].Value);
                if (sFlowDirect >= 0)
                    dgv.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                else
                    dgv.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                if(dgv.Rows[i].Cells[3].Value != DBNull.Value)
                    sDecPoint = Convert.ToInt16(dgv.Rows[i].Cells[3].Value);
                if (sDecPoint >= 0)
                        dgv.Rows[i].Cells[1].Style.Format = String.Format("N{0}", sDecPoint);
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false))
                e.Handled = true;
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) == false) && (Char.IsControl(e.KeyChar) == false))
                e.Handled = true;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            dbGridBalance.Width = (this.Width - 30) / 2;
            dbGridBalance.Height = this.Height - 12 - dbGridBalance.Top;
            if (dbGridBalance.Columns.Count > 2)
                dbGridBalance.Columns[1].Width = dbGridBalance.Width - dbGridBalance.Columns[0].Width - 20;
            btnRefresh.Left = dbGridBalance.Left + dbGridBalance.Width - btnRefresh.Width;
            dbGridCashflow.Width = dbGridBalance.Width;
            dbGridCashflow.Height = dbGridBalance.Height;
            if (dbGridCashflow.Columns.Count > 2)
                dbGridCashflow.Columns[1].Width = dbGridCashflow.Width - dbGridCashflow.Columns[0].Width - 20;
            dbGridCashflow.Left = this.Width - 12 -  dbGridCashflow.Width;
            labelCashflow.Left = dbGridCashflow.Left;
            cmbOptions.Left = labelCashflow.Left + labelCashflow.Width+ 6;
            txtMonth.Left = this.Width - 12 - txtMonth.Width;
            labelMonth.Left = txtMonth.Left - labelMonth.Width;
            txtYear.Left = labelMonth.Left - txtYear.Width;
            labelYear.Left = txtYear.Left - labelYear.Width;
        }

        private bool ChkEditForm()
        {
            bool bOK = true;
            if (cmbOptions.SelectedIndex == 4)
            {
                if (txtYear.Text.Length == 0)
                {
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrYearNotSet, PersonalBookKeeper.Properties.Resources.strErrTitle);
                    bOK = false;
                }
                if (bOK)
                {
                    short sYear = Convert.ToInt16(txtYear.Text);
                    if ((sYear < 2000) || (sYear > 2099))
                    {
                        MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrYearInvalid, PersonalBookKeeper.Properties.Resources.strErrTitle);
                        bOK = false;
                    }
                }
                if (bOK)
                {
                    if (txtMonth.Text.Length > 0)
                    {
                        short sMonth = Convert.ToInt16(txtMonth.Text);
                        if ((sMonth < 1) || (sMonth > 12))
                        {
                            MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrMonthInvalid, PersonalBookKeeper.Properties.Resources.strErrTitle);
                            bOK = false;
                        }
                    }
                }
            }
            return bOK;
        }

        private void RefreshBalance()
        {
            string[] strTitles = new string[5];
            strTitles[0] = PersonalBookKeeper.Properties.Resources.strTxtAssets;
            strTitles[1] = PersonalBookKeeper.Properties.Resources.strTxtChangeAssets;
            strTitles[2] = PersonalBookKeeper.Properties.Resources.strTxtLiabilities;
            strTitles[3] = PersonalBookKeeper.Properties.Resources.strTxtChangeLiabilities;
            strTitles[4] = PersonalBookKeeper.Properties.Resources.strTxtEquity;
            if (cmdGetBalance == null)
            {
                cmdGetBalance = new SqlCommand(@"SELECT * FROM [dbo].[GetBalanceSheet](@StTime,@EdTime)", dbConn);
                cmdGetBalance.Parameters.Add(new SqlParameter("@StTime", SqlDbType.DateTime2));
                cmdGetBalance.Parameters.Add(new SqlParameter("@EdTime", SqlDbType.DateTime2));
            }
            DateTime stTime, edTime;
            int iYear = 0, iMonth = 0;
            switch (cmbOptions.SelectedIndex)
            {
                case 0:
                    stTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    cmdGetBalance.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetBalance.Parameters["@EdTime"].Value = DBNull.Value;
                    break;
                case 1:
                    edTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    stTime = edTime.AddMonths(-1);
                    cmdGetBalance.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetBalance.Parameters["@EdTime"].Value = edTime.ToUniversalTime();
                    break;
                case 2:
                    stTime = new DateTime(DateTime.Now.Year, 1, 1);
                    cmdGetBalance.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetBalance.Parameters["@EdTime"].Value = DBNull.Value;
                    break;
                case 3:
                    edTime = new DateTime(DateTime.Now.Year, 1, 1);
                    stTime = edTime.AddYears(-1);
                    cmdGetBalance.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetBalance.Parameters["@EdTime"].Value = edTime.ToUniversalTime();
                    break;
                default:
                    iYear = Convert.ToInt32(txtYear.Text);
                    if (txtMonth.Text.Length > 0)
                        iMonth = Convert.ToInt32(txtMonth.Text);
                    if (iMonth > 0)
                    {
                        stTime = new DateTime(iYear, iMonth, 1);
                        edTime = stTime.AddMonths(1);
                    }
                    else
                    {
                        stTime = new DateTime(iYear, 1, 1);
                        edTime = stTime.AddYears(1);
                    }
                    cmdGetBalance.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetBalance.Parameters["@EdTime"].Value = edTime.ToUniversalTime();
                    break;
            }
            DataTable dtBalance = new DataTable();
            SqlDataReader dr4GetBalance = cmdGetBalance.ExecuteReader();
            dtBalance.Load(dr4GetBalance);
            for (int i = 0, j=0; i < dtBalance.Rows.Count; i++)
            {
                if (dtBalance.Rows[i][0].ToString().Contains("{0}"))
                {
                    dtBalance.Rows[i][0] = String.Format(dtBalance.Rows[i][0].ToString(), strTitles[j % 5]);
                    j += 1;
                }
            }
            dbGridBalance.DataSource = dtBalance;
            dbGridBalance.Columns[0].Width = dbGridBalance.Width * 3 / 5;
            dbGridBalance.Columns[1].Width = dbGridBalance.Width - dbGridBalance.Columns[0].Width - 20;
            dbGridBalance.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridBalance.Columns[2].Visible = false;
            dbGridBalance.Columns[3].Visible = false;
            dbGridBalance.ClearSelection();
        }

        private void RefreshCashflow()
        {
            string[] strTitles = new string[3];
            strTitles[0] = PersonalBookKeeper.Properties.Resources.strTxtTotalInflows;
            strTitles[1] = PersonalBookKeeper.Properties.Resources.strTxtTotalOutflows;
            strTitles[2] = PersonalBookKeeper.Properties.Resources.strTxtNetCashflow;
            if (cmdGetCashflow == null)
            {
                cmdGetCashflow = new SqlCommand(@"SELECT * FROM [dbo].[GetCashflowSheet](@StTime,@EdTime)", dbConn);
                cmdGetCashflow.Parameters.Add(new SqlParameter("@StTime", SqlDbType.DateTime2));
                cmdGetCashflow.Parameters.Add(new SqlParameter("@EdTime", SqlDbType.DateTime2));
            }
            DateTime stTime, edTime;
            int iYear = 0, iMonth = 0;
            switch (cmbOptions.SelectedIndex)
            {
                case 0:
                    stTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    cmdGetCashflow.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetCashflow.Parameters["@EdTime"].Value = DBNull.Value;
                    break;
                case 1:
                    edTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    stTime = edTime.AddMonths(-1);
                    cmdGetCashflow.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetCashflow.Parameters["@EdTime"].Value = edTime.ToUniversalTime();
                    break;
                case 2:
                    stTime = new DateTime(DateTime.Now.Year, 1, 1);
                    cmdGetCashflow.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetCashflow.Parameters["@EdTime"].Value = DBNull.Value;
                    break;
                case 3:
                    edTime = new DateTime(DateTime.Now.Year, 1, 1);
                    stTime = edTime.AddYears(-1);
                    cmdGetCashflow.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetCashflow.Parameters["@EdTime"].Value = edTime.ToUniversalTime();
                    break;
                default:
                    iYear = Convert.ToInt32(txtYear.Text);
                    if (txtMonth.Text.Length > 0)
                        iMonth = Convert.ToInt32(txtMonth.Text);
                    if (iMonth > 0)
                    {
                        stTime = new DateTime(iYear, iMonth, 1);
                        edTime = stTime.AddMonths(1);
                    }
                    else
                    {
                        stTime = new DateTime(iYear, 1, 1);
                        edTime = stTime.AddYears(1);
                    }
                    cmdGetCashflow.Parameters["@StTime"].Value = stTime.ToUniversalTime();
                    cmdGetCashflow.Parameters["@EdTime"].Value = edTime.ToUniversalTime();
                    break;
            }
            DataTable dtCashflow = new DataTable();
            SqlDataReader dr4GetCashflow = cmdGetCashflow.ExecuteReader();
            dtCashflow.Load(dr4GetCashflow);
            for (int i = 0, j = 0; i < dtCashflow.Rows.Count; i++)
            {
                if (dtCashflow.Rows[i][0].ToString().Contains("{0}"))
                {
                    dtCashflow.Rows[i][0] = String.Format(dtCashflow.Rows[i][0].ToString(), strTitles[j % 3]);
                    j += 1;
                }
            }
            dbGridCashflow.DataSource = dtCashflow;
            dbGridCashflow.Columns[0].Width = dbGridCashflow.Width * 3 / 5;
            dbGridCashflow.Columns[1].Width = dbGridCashflow.Width - dbGridCashflow.Columns[0].Width - 20;
            dbGridCashflow.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridCashflow.Columns[2].Visible = false;
            dbGridCashflow.Columns[3].Visible = false;
            dbGridCashflow.ClearSelection();
        }
    }
}
