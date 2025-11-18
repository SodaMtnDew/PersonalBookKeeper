namespace PersonalBookKeeper
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dbGridAccount = new System.Windows.Forms.DataGridView();
            this.labelDbAccounts = new System.Windows.Forms.Label();
            this.labelAccountName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.labelAccountDesc = new System.Windows.Forms.Label();
            this.labelAccountBalance = new System.Windows.Forms.Label();
            this.labelAccountType = new System.Windows.Forms.Label();
            this.labelAccountCurrency = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtAccountDesc = new System.Windows.Forms.TextBox();
            this.txtAccountBalance = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dbGridType = new System.Windows.Forms.DataGridView();
            this.dbGridCurrency = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // dbGridAccount
            // 
            this.dbGridAccount.AllowUserToAddRows = false;
            this.dbGridAccount.AllowUserToDeleteRows = false;
            this.dbGridAccount.AllowUserToResizeRows = false;
            this.dbGridAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridAccount.Location = new System.Drawing.Point(18, 62);
            this.dbGridAccount.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridAccount.MultiSelect = false;
            this.dbGridAccount.Name = "dbGridAccount";
            this.dbGridAccount.ReadOnly = true;
            this.dbGridAccount.RowHeadersVisible = false;
            this.dbGridAccount.RowHeadersWidth = 62;
            this.dbGridAccount.RowTemplate.Height = 24;
            this.dbGridAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridAccount.ShowCellErrors = false;
            this.dbGridAccount.ShowCellToolTips = false;
            this.dbGridAccount.ShowEditingIcon = false;
            this.dbGridAccount.ShowRowErrors = false;
            this.dbGridAccount.Size = new System.Drawing.Size(1183, 198);
            this.dbGridAccount.TabIndex = 2;
            this.dbGridAccount.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dbGridAccount_RowsAdded);
            this.dbGridAccount.SelectionChanged += new System.EventHandler(this.dbGridAccount_SelectionChanged);
            // 
            // labelDbAccounts
            // 
            this.labelDbAccounts.Location = new System.Drawing.Point(18, 18);
            this.labelDbAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbAccounts.Name = "labelDbAccounts";
            this.labelDbAccounts.Size = new System.Drawing.Size(571, 34);
            this.labelDbAccounts.TabIndex = 0;
            this.labelDbAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAccountName
            // 
            this.labelAccountName.Location = new System.Drawing.Point(18, 312);
            this.labelAccountName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(186, 34);
            this.labelAccountName.TabIndex = 7;
            this.labelAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 274);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(177, 274);
            this.btnMod.Margin = new System.Windows.Forms.Padding(4);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(150, 34);
            this.btnMod.TabIndex = 4;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(336, 274);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(150, 34);
            this.btnDel.TabIndex = 5;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // labelAccountDesc
            // 
            this.labelAccountDesc.Location = new System.Drawing.Point(18, 352);
            this.labelAccountDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccountDesc.Name = "labelAccountDesc";
            this.labelAccountDesc.Size = new System.Drawing.Size(186, 34);
            this.labelAccountDesc.TabIndex = 9;
            this.labelAccountDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAccountBalance
            // 
            this.labelAccountBalance.Location = new System.Drawing.Point(18, 549);
            this.labelAccountBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccountBalance.Name = "labelAccountBalance";
            this.labelAccountBalance.Size = new System.Drawing.Size(186, 34);
            this.labelAccountBalance.TabIndex = 15;
            this.labelAccountBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAccountType
            // 
            this.labelAccountType.Location = new System.Drawing.Point(707, 269);
            this.labelAccountType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccountType.Name = "labelAccountType";
            this.labelAccountType.Size = new System.Drawing.Size(245, 34);
            this.labelAccountType.TabIndex = 11;
            this.labelAccountType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAccountCurrency
            // 
            this.labelAccountCurrency.Location = new System.Drawing.Point(956, 269);
            this.labelAccountCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccountCurrency.Name = "labelAccountCurrency";
            this.labelAccountCurrency.Size = new System.Drawing.Size(245, 34);
            this.labelAccountCurrency.TabIndex = 13;
            this.labelAccountCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(212, 311);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(490, 29);
            this.txtAccountName.TabIndex = 8;
            // 
            // txtAccountDesc
            // 
            this.txtAccountDesc.Location = new System.Drawing.Point(212, 348);
            this.txtAccountDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountDesc.Multiline = true;
            this.txtAccountDesc.Name = "txtAccountDesc";
            this.txtAccountDesc.ReadOnly = true;
            this.txtAccountDesc.Size = new System.Drawing.Size(490, 198);
            this.txtAccountDesc.TabIndex = 10;
            // 
            // txtAccountBalance
            // 
            this.txtAccountBalance.Location = new System.Drawing.Point(212, 554);
            this.txtAccountBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountBalance.Name = "txtAccountBalance";
            this.txtAccountBalance.ReadOnly = true;
            this.txtAccountBalance.Size = new System.Drawing.Size(490, 29);
            this.txtAccountBalance.TabIndex = 16;
            this.txtAccountBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountBalance_KeyPress);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(495, 274);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(94, 29);
            this.txtID.TabIndex = 6;
            this.txtID.Visible = false;
            // 
            // dbGridType
            // 
            this.dbGridType.AllowUserToAddRows = false;
            this.dbGridType.AllowUserToDeleteRows = false;
            this.dbGridType.AllowUserToResizeColumns = false;
            this.dbGridType.AllowUserToResizeRows = false;
            this.dbGridType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridType.ColumnHeadersVisible = false;
            this.dbGridType.Enabled = false;
            this.dbGridType.Location = new System.Drawing.Point(710, 307);
            this.dbGridType.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridType.MultiSelect = false;
            this.dbGridType.Name = "dbGridType";
            this.dbGridType.ReadOnly = true;
            this.dbGridType.RowHeadersVisible = false;
            this.dbGridType.RowHeadersWidth = 62;
            this.dbGridType.RowTemplate.Height = 24;
            this.dbGridType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridType.ShowCellErrors = false;
            this.dbGridType.ShowCellToolTips = false;
            this.dbGridType.ShowEditingIcon = false;
            this.dbGridType.ShowRowErrors = false;
            this.dbGridType.Size = new System.Drawing.Size(242, 276);
            this.dbGridType.TabIndex = 12;
            // 
            // dbGridCurrency
            // 
            this.dbGridCurrency.AllowUserToAddRows = false;
            this.dbGridCurrency.AllowUserToDeleteRows = false;
            this.dbGridCurrency.AllowUserToResizeColumns = false;
            this.dbGridCurrency.AllowUserToResizeRows = false;
            this.dbGridCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridCurrency.ColumnHeadersVisible = false;
            this.dbGridCurrency.Enabled = false;
            this.dbGridCurrency.Location = new System.Drawing.Point(959, 307);
            this.dbGridCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridCurrency.MultiSelect = false;
            this.dbGridCurrency.Name = "dbGridCurrency";
            this.dbGridCurrency.ReadOnly = true;
            this.dbGridCurrency.RowHeadersVisible = false;
            this.dbGridCurrency.RowHeadersWidth = 62;
            this.dbGridCurrency.RowTemplate.Height = 24;
            this.dbGridCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridCurrency.ShowCellErrors = false;
            this.dbGridCurrency.ShowCellToolTips = false;
            this.dbGridCurrency.ShowEditingIcon = false;
            this.dbGridCurrency.ShowRowErrors = false;
            this.dbGridCurrency.Size = new System.Drawing.Size(242, 276);
            this.dbGridCurrency.TabIndex = 14;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1089, 13);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 34);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dbGridCurrency);
            this.Controls.Add(this.dbGridType);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtAccountBalance);
            this.Controls.Add(this.txtAccountDesc);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.labelAccountCurrency);
            this.Controls.Add(this.labelAccountType);
            this.Controls.Add(this.labelAccountBalance);
            this.Controls.Add(this.labelAccountDesc);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelAccountName);
            this.Controls.Add(this.labelDbAccounts);
            this.Controls.Add(this.dbGridAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.SizeChanged += new System.EventHandler(this.AccountForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridAccount;
        private System.Windows.Forms.Label labelDbAccounts;
        private System.Windows.Forms.Label labelAccountName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label labelAccountDesc;
        private System.Windows.Forms.Label labelAccountBalance;
        private System.Windows.Forms.Label labelAccountType;
        private System.Windows.Forms.Label labelAccountCurrency;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtAccountDesc;
        private System.Windows.Forms.TextBox txtAccountBalance;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridView dbGridType;
        private System.Windows.Forms.DataGridView dbGridCurrency;
        private System.Windows.Forms.Button btnRefresh;
    }
}