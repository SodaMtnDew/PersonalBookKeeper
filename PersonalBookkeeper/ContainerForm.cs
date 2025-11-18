using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalBookKeeper
{
    public partial class ContainerForm : Form
    {
        SqlConnection dbConn = new SqlConnection(@"Data Source=(local);Initial Catalog=FinanceDB;Integrated Security=SSPI");
        SqlCommand cmdGetPermission;
        int oldTabIdx;
        bool bTabLocked;
        //DataTable lstUrlTable, lstFltTable, lstScanTable;
        MainForm mainForm;
        TransactionForm transactionForm;
        CategoryForm categoryForm;
        AccountForm accountForm;
        TypeForm typeForm;
        CurrencyForm currencyForm;
        ScheduleForm scheduleForm;
        string[] strTabs;
        string strPermission;

        public void LockTab()
        {
            bTabLocked = true;
        }
        public void UnlockTab()
        {
            bTabLocked = false;
        }
        public ContainerForm()
        {
            InitializeComponent();
        }

        private void ContainerForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 1280)
                this.Width = 1280;
            if (this.Height < 720)
                this.Height = 720;
            tabOfForms.Width = this.Width - 40;
            tabOfForms.Height = this.Height - 63;
            if (mainForm != null)
            {
                mainForm.Width = tabOfForms.Width - 8;
                mainForm.Height = tabOfForms.Height - 26;
            }
            if (transactionForm != null)
            {
                transactionForm.Width = tabOfForms.Width - 8;
                transactionForm.Height = tabOfForms.Height - 26;
            }
            if (categoryForm != null)
            {
                categoryForm.Width = tabOfForms.Width - 8;
                categoryForm.Height = tabOfForms.Height - 26;
            }
            if (accountForm != null)
            {
                accountForm.Width = tabOfForms.Width - 8;
                accountForm.Height = tabOfForms.Height - 26;
            }
            if (typeForm != null)
            {
                typeForm.Width = tabOfForms.Width - 8;
                typeForm.Height = tabOfForms.Height - 26;
            }
            if (currencyForm != null)
            {
                currencyForm.Width = tabOfForms.Width - 8;
                currencyForm.Height = tabOfForms.Height - 26;
            }
            if (scheduleForm != null)
            {
                scheduleForm.Width = tabOfForms.Width - 8;
                scheduleForm.Height = tabOfForms.Height - 26;
            }
        }

        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbConn.State == ConnectionState.Open)
                dbConn.Close();
        }

        private void ContainerForm_Load(object sender, EventArgs e)
        {
            if (ChkSystemReady())
            {
                AddFormAndBindTab();
                setTabControl(strPermission);
            }
            else
                Close();
            this.Text = PersonalBookKeeper.Properties.Resources.strAppTitle;
            strTabs = new string[7];
            strTabs[0] = PersonalBookKeeper.Properties.Resources.strTabMain;
            strTabs[1] = PersonalBookKeeper.Properties.Resources.strTabTransaction;
            strTabs[2] = PersonalBookKeeper.Properties.Resources.strTabCategory;
            strTabs[3] = PersonalBookKeeper.Properties.Resources.strTabAccount;
            strTabs[4] = PersonalBookKeeper.Properties.Resources.strTabType;
            strTabs[5] = PersonalBookKeeper.Properties.Resources.strTabCurrency;
            strTabs[6] = PersonalBookKeeper.Properties.Resources.strTabSchedule;
            for (int i = 0; i < 7; i++)
                tabOfForms.TabPages[i].Text = strTabs[i];
            bTabLocked = false;
            oldTabIdx = 0;
            this.Width = 800;
            this.Height = 450;
            tabOfForms.SelectedIndex = oldTabIdx;
            this.OnSizeChanged(EventArgs.Empty);
        }

        private string getPermissionStr()
        {
            string str2Ret = null;
            if (cmdGetPermission == null)
                cmdGetPermission = new SqlCommand(@"SELECT [dbo].[GetPermission]()", dbConn);
            var objPermission = cmdGetPermission.ExecuteScalar();
            if (objPermission != null)
                str2Ret = objPermission.ToString();
            return str2Ret;
        }

        private void setTabControl(string str2Chk)
        {
            int lenStr = str2Chk.Length;
            for (int i = 0; i < lenStr; i++)
            {
                char chrPermission = str2Chk.ElementAt(i);
                if (chrPermission == '1')
                    tabOfForms.TabPages[i].Enabled = true;
                else
                    tabOfForms.TabPages[i].Enabled = false;
            }
        }

        private void AddFormAndBindTab()
        {
            mainForm = new MainForm(dbConn, this);
            mainForm.TopLevel = false;
            mainForm.Parent = tabMain;
            mainForm.Visible = true;
            transactionForm = new TransactionForm(dbConn, this);
            transactionForm.TopLevel = false;
            transactionForm.Parent = tabTransaction;
            transactionForm.Visible = true;
            categoryForm = new CategoryForm(dbConn, this);
            categoryForm.TopLevel = false;
            categoryForm.Parent = tabCategory;
            categoryForm.Visible = true;
            accountForm = new AccountForm(dbConn, this);
            accountForm.TopLevel = false;
            accountForm.Parent = tabAccount;
            accountForm.Visible = true;
            typeForm = new TypeForm(dbConn, this);
            typeForm.TopLevel = false;
            typeForm.Parent = tabType;
            typeForm.Visible = true;
            currencyForm = new CurrencyForm(dbConn, this);
            currencyForm.TopLevel = false;
            currencyForm.Parent = tabCurrency;
            currencyForm.Visible = true;
            scheduleForm = new ScheduleForm(dbConn, this);
            scheduleForm.TopLevel = false;
            scheduleForm.Parent = tabSchedule;
            scheduleForm.Visible = true;
        }

        private void tabOfForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bTabLocked)
            {  
                if (tabOfForms.SelectedIndex != oldTabIdx)
                    MessageBox.Show(PersonalBookKeeper.Properties.Resources.StrErrTabLock, PersonalBookKeeper.Properties.Resources.strErrTitle);
                tabOfForms.SelectedIndex = oldTabIdx;
            }
            else
            {
                strPermission = getPermissionStr();
                setTabControl(strPermission);
                if (tabOfForms.TabPages[tabOfForms.SelectedIndex].Enabled == false)
                {
                    if (tabOfForms.SelectedIndex == 3)
                        MessageBox.Show(String.Format(PersonalBookKeeper.Properties.Resources.strHintForTabs, strTabs[4], strTabs[5], strTabs[3]), PersonalBookKeeper.Properties.Resources.strHintTitle);
                    else if (tabOfForms.SelectedIndex == 1)
                        MessageBox.Show(String.Format(PersonalBookKeeper.Properties.Resources.strHintForTabs, strTabs[3], strTabs[2], strTabs[1]), PersonalBookKeeper.Properties.Resources.strHintTitle);
                    else
                        MessageBox.Show(String.Format(PersonalBookKeeper.Properties.Resources.strHintForTabs, strTabs[3], strTabs[2], strTabs[6]), PersonalBookKeeper.Properties.Resources.strHintTitle);
                    tabOfForms.SelectedIndex = oldTabIdx;
                }
                else
                    oldTabIdx = tabOfForms.SelectedIndex;
            }
        }

        private bool ChkSystemReady()
        {
            bool bRet = true;
            try
            {
                dbConn.Open();
            }
            catch
            {
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrNoDb, PersonalBookKeeper.Properties.Resources.strErrTitle);
                bRet = false;
            }
            strPermission = getPermissionStr();
            if (strPermission == null)
            {
                MessageBox.Show(PersonalBookKeeper.Properties.Resources.strErrDbSchema, PersonalBookKeeper.Properties.Resources.strErrTitle);
                dbConn.Close();
                bRet = false;
            }
            return bRet;
        }
    }
}
