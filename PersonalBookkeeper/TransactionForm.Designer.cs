namespace PersonalBookKeeper
{
    partial class TransactionForm
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
            this.labelDbTransactions = new System.Windows.Forms.Label();
            this.dbGridTransaction = new System.Windows.Forms.DataGridView();
            this.dbGridSrcAccount = new System.Windows.Forms.DataGridView();
            this.dbGridDstAccount = new System.Windows.Forms.DataGridView();
            this.dbGridCategory = new System.Windows.Forms.DataGridView();
            this.labelSrcAccount = new System.Windows.Forms.Label();
            this.labelDstAccount = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelTransactionDesc = new System.Windows.Forms.Label();
            this.labelTransactionName = new System.Windows.Forms.Label();
            this.txtDstAmount = new System.Windows.Forms.TextBox();
            this.txtTransactionDesc = new System.Windows.Forms.TextBox();
            this.txtTransactionName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSrcAmount = new System.Windows.Forms.TextBox();
            this.labelSrcAmount = new System.Windows.Forms.Label();
            this.labelDstAmount = new System.Windows.Forms.Label();
            this.chkSetTime = new System.Windows.Forms.CheckBox();
            this.dtPickerMadeTime = new System.Windows.Forms.DateTimePicker();
            this.dtPickerMadeDate = new System.Windows.Forms.DateTimePicker();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridSrcAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridDstAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDbTransactions
            // 
            this.labelDbTransactions.Location = new System.Drawing.Point(18, 18);
            this.labelDbTransactions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbTransactions.Name = "labelDbTransactions";
            this.labelDbTransactions.Size = new System.Drawing.Size(502, 34);
            this.labelDbTransactions.TabIndex = 0;
            this.labelDbTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dbGridTransaction
            // 
            this.dbGridTransaction.AllowUserToAddRows = false;
            this.dbGridTransaction.AllowUserToDeleteRows = false;
            this.dbGridTransaction.AllowUserToResizeRows = false;
            this.dbGridTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridTransaction.Location = new System.Drawing.Point(18, 62);
            this.dbGridTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridTransaction.MultiSelect = false;
            this.dbGridTransaction.Name = "dbGridTransaction";
            this.dbGridTransaction.ReadOnly = true;
            this.dbGridTransaction.RowHeadersVisible = false;
            this.dbGridTransaction.RowHeadersWidth = 62;
            this.dbGridTransaction.RowTemplate.Height = 24;
            this.dbGridTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridTransaction.ShowCellErrors = false;
            this.dbGridTransaction.ShowCellToolTips = false;
            this.dbGridTransaction.ShowEditingIcon = false;
            this.dbGridTransaction.ShowRowErrors = false;
            this.dbGridTransaction.Size = new System.Drawing.Size(1173, 149);
            this.dbGridTransaction.TabIndex = 3;
            this.dbGridTransaction.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dbGridTransaction_RowsAdded);
            this.dbGridTransaction.SelectionChanged += new System.EventHandler(this.dbGridTransaction_SelectionChanged);
            // 
            // dbGridSrcAccount
            // 
            this.dbGridSrcAccount.AllowUserToAddRows = false;
            this.dbGridSrcAccount.AllowUserToDeleteRows = false;
            this.dbGridSrcAccount.AllowUserToResizeColumns = false;
            this.dbGridSrcAccount.AllowUserToResizeRows = false;
            this.dbGridSrcAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridSrcAccount.ColumnHeadersVisible = false;
            this.dbGridSrcAccount.Enabled = false;
            this.dbGridSrcAccount.Location = new System.Drawing.Point(569, 261);
            this.dbGridSrcAccount.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridSrcAccount.MultiSelect = false;
            this.dbGridSrcAccount.Name = "dbGridSrcAccount";
            this.dbGridSrcAccount.ReadOnly = true;
            this.dbGridSrcAccount.RowHeadersVisible = false;
            this.dbGridSrcAccount.RowHeadersWidth = 62;
            this.dbGridSrcAccount.RowTemplate.Height = 24;
            this.dbGridSrcAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridSrcAccount.ShowCellErrors = false;
            this.dbGridSrcAccount.ShowCellToolTips = false;
            this.dbGridSrcAccount.ShowEditingIcon = false;
            this.dbGridSrcAccount.ShowRowErrors = false;
            this.dbGridSrcAccount.Size = new System.Drawing.Size(202, 322);
            this.dbGridSrcAccount.TabIndex = 17;
            this.dbGridSrcAccount.SelectionChanged += new System.EventHandler(this.dbGridSrcAccount_SelectionChanged);
            // 
            // dbGridDstAccount
            // 
            this.dbGridDstAccount.AllowUserToAddRows = false;
            this.dbGridDstAccount.AllowUserToDeleteRows = false;
            this.dbGridDstAccount.AllowUserToResizeColumns = false;
            this.dbGridDstAccount.AllowUserToResizeRows = false;
            this.dbGridDstAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridDstAccount.ColumnHeadersVisible = false;
            this.dbGridDstAccount.Enabled = false;
            this.dbGridDstAccount.Location = new System.Drawing.Point(989, 261);
            this.dbGridDstAccount.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridDstAccount.MultiSelect = false;
            this.dbGridDstAccount.Name = "dbGridDstAccount";
            this.dbGridDstAccount.ReadOnly = true;
            this.dbGridDstAccount.RowHeadersVisible = false;
            this.dbGridDstAccount.RowHeadersWidth = 62;
            this.dbGridDstAccount.RowTemplate.Height = 24;
            this.dbGridDstAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridDstAccount.ShowCellErrors = false;
            this.dbGridDstAccount.ShowCellToolTips = false;
            this.dbGridDstAccount.ShowEditingIcon = false;
            this.dbGridDstAccount.ShowRowErrors = false;
            this.dbGridDstAccount.Size = new System.Drawing.Size(202, 322);
            this.dbGridDstAccount.TabIndex = 21;
            this.dbGridDstAccount.SelectionChanged += new System.EventHandler(this.dbGridDstAccount_SelectionChanged);
            // 
            // dbGridCategory
            // 
            this.dbGridCategory.AllowUserToAddRows = false;
            this.dbGridCategory.AllowUserToDeleteRows = false;
            this.dbGridCategory.AllowUserToResizeColumns = false;
            this.dbGridCategory.AllowUserToResizeRows = false;
            this.dbGridCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridCategory.ColumnHeadersVisible = false;
            this.dbGridCategory.Enabled = false;
            this.dbGridCategory.Location = new System.Drawing.Point(779, 261);
            this.dbGridCategory.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridCategory.MultiSelect = false;
            this.dbGridCategory.Name = "dbGridCategory";
            this.dbGridCategory.ReadOnly = true;
            this.dbGridCategory.RowHeadersVisible = false;
            this.dbGridCategory.RowHeadersWidth = 62;
            this.dbGridCategory.RowTemplate.Height = 24;
            this.dbGridCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridCategory.ShowCellErrors = false;
            this.dbGridCategory.ShowCellToolTips = false;
            this.dbGridCategory.ShowEditingIcon = false;
            this.dbGridCategory.ShowRowErrors = false;
            this.dbGridCategory.Size = new System.Drawing.Size(202, 322);
            this.dbGridCategory.TabIndex = 15;
            this.dbGridCategory.SelectionChanged += new System.EventHandler(this.dbGridCategory_SelectionChanged);
            // 
            // labelSrcAccount
            // 
            this.labelSrcAccount.Location = new System.Drawing.Point(566, 219);
            this.labelSrcAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSrcAccount.Name = "labelSrcAccount";
            this.labelSrcAccount.Size = new System.Drawing.Size(205, 34);
            this.labelSrcAccount.TabIndex = 16;
            this.labelSrcAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDstAccount
            // 
            this.labelDstAccount.Location = new System.Drawing.Point(986, 219);
            this.labelDstAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDstAccount.Name = "labelDstAccount";
            this.labelDstAccount.Size = new System.Drawing.Size(205, 34);
            this.labelDstAccount.TabIndex = 20;
            this.labelDstAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCategory
            // 
            this.labelCategory.Location = new System.Drawing.Point(776, 218);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(205, 34);
            this.labelCategory.TabIndex = 14;
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(174, 219);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(150, 34);
            this.btnDel.TabIndex = 5;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 218);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 34);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelTransactionDesc
            // 
            this.labelTransactionDesc.Location = new System.Drawing.Point(18, 304);
            this.labelTransactionDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTransactionDesc.Name = "labelTransactionDesc";
            this.labelTransactionDesc.Size = new System.Drawing.Size(123, 34);
            this.labelTransactionDesc.TabIndex = 9;
            this.labelTransactionDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTransactionName
            // 
            this.labelTransactionName.Location = new System.Drawing.Point(18, 261);
            this.labelTransactionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTransactionName.Name = "labelTransactionName";
            this.labelTransactionName.Size = new System.Drawing.Size(123, 34);
            this.labelTransactionName.TabIndex = 7;
            this.labelTransactionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDstAmount
            // 
            this.txtDstAmount.Location = new System.Drawing.Point(149, 554);
            this.txtDstAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDstAmount.Name = "txtDstAmount";
            this.txtDstAmount.ReadOnly = true;
            this.txtDstAmount.Size = new System.Drawing.Size(412, 29);
            this.txtDstAmount.TabIndex = 23;
            this.txtDstAmount.TextChanged += new System.EventHandler(this.txtDstAmount_TextChanged);
            this.txtDstAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDstAmount_KeyPress);
            // 
            // txtTransactionDesc
            // 
            this.txtTransactionDesc.Location = new System.Drawing.Point(149, 298);
            this.txtTransactionDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionDesc.Multiline = true;
            this.txtTransactionDesc.Name = "txtTransactionDesc";
            this.txtTransactionDesc.ReadOnly = true;
            this.txtTransactionDesc.Size = new System.Drawing.Size(412, 174);
            this.txtTransactionDesc.TabIndex = 10;
            // 
            // txtTransactionName
            // 
            this.txtTransactionName.Location = new System.Drawing.Point(149, 261);
            this.txtTransactionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionName.Name = "txtTransactionName";
            this.txtTransactionName.ReadOnly = true;
            this.txtTransactionName.Size = new System.Drawing.Size(412, 29);
            this.txtTransactionName.TabIndex = 8;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(540, 18);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(48, 29);
            this.txtID.TabIndex = 1;
            this.txtID.Visible = false;
            // 
            // txtSrcAmount
            // 
            this.txtSrcAmount.Location = new System.Drawing.Point(149, 517);
            this.txtSrcAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtSrcAmount.Name = "txtSrcAmount";
            this.txtSrcAmount.ReadOnly = true;
            this.txtSrcAmount.Size = new System.Drawing.Size(412, 29);
            this.txtSrcAmount.TabIndex = 19;
            this.txtSrcAmount.TextChanged += new System.EventHandler(this.txtSrcAmount_TextChanged);
            this.txtSrcAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSrcAmount_KeyPress);
            // 
            // labelSrcAmount
            // 
            this.labelSrcAmount.Location = new System.Drawing.Point(18, 512);
            this.labelSrcAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSrcAmount.Name = "labelSrcAmount";
            this.labelSrcAmount.Size = new System.Drawing.Size(123, 34);
            this.labelSrcAmount.TabIndex = 18;
            this.labelSrcAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDstAmount
            // 
            this.labelDstAmount.Location = new System.Drawing.Point(18, 549);
            this.labelDstAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDstAmount.Name = "labelDstAmount";
            this.labelDstAmount.Size = new System.Drawing.Size(123, 34);
            this.labelDstAmount.TabIndex = 22;
            this.labelDstAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSetTime
            // 
            this.chkSetTime.Enabled = false;
            this.chkSetTime.Location = new System.Drawing.Point(18, 475);
            this.chkSetTime.Margin = new System.Windows.Forms.Padding(4);
            this.chkSetTime.Name = "chkSetTime";
            this.chkSetTime.Size = new System.Drawing.Size(123, 34);
            this.chkSetTime.TabIndex = 11;
            this.chkSetTime.UseVisualStyleBackColor = true;
            this.chkSetTime.CheckedChanged += new System.EventHandler(this.chkSetTime_CheckedChanged);
            // 
            // dtPickerMadeTime
            // 
            this.dtPickerMadeTime.CustomFormat = "HH:mm:ss";
            this.dtPickerMadeTime.Enabled = false;
            this.dtPickerMadeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerMadeTime.Location = new System.Drawing.Point(359, 480);
            this.dtPickerMadeTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtPickerMadeTime.Name = "dtPickerMadeTime";
            this.dtPickerMadeTime.ShowUpDown = true;
            this.dtPickerMadeTime.Size = new System.Drawing.Size(202, 29);
            this.dtPickerMadeTime.TabIndex = 13;
            // 
            // dtPickerMadeDate
            // 
            this.dtPickerMadeDate.Enabled = false;
            this.dtPickerMadeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerMadeDate.Location = new System.Drawing.Point(149, 480);
            this.dtPickerMadeDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtPickerMadeDate.Name = "dtPickerMadeDate";
            this.dtPickerMadeDate.Size = new System.Drawing.Size(202, 29);
            this.dtPickerMadeDate.TabIndex = 12;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(332, 219);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(150, 34);
            this.btnSchedule.TabIndex = 6;
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1079, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 34);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.dtPickerMadeTime);
            this.Controls.Add(this.chkSetTime);
            this.Controls.Add(this.dtPickerMadeDate);
            this.Controls.Add(this.labelDstAmount);
            this.Controls.Add(this.labelSrcAmount);
            this.Controls.Add(this.txtSrcAmount);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtDstAmount);
            this.Controls.Add(this.txtTransactionDesc);
            this.Controls.Add(this.txtTransactionName);
            this.Controls.Add(this.labelTransactionDesc);
            this.Controls.Add(this.labelTransactionName);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelDstAccount);
            this.Controls.Add(this.labelSrcAccount);
            this.Controls.Add(this.dbGridCategory);
            this.Controls.Add(this.dbGridDstAccount);
            this.Controls.Add(this.dbGridSrcAccount);
            this.Controls.Add(this.dbGridTransaction);
            this.Controls.Add(this.labelDbTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            this.SizeChanged += new System.EventHandler(this.TransactionForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridSrcAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridDstAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDbTransactions;
        private System.Windows.Forms.DataGridView dbGridTransaction;
        private System.Windows.Forms.DataGridView dbGridSrcAccount;
        private System.Windows.Forms.DataGridView dbGridDstAccount;
        private System.Windows.Forms.DataGridView dbGridCategory;
        private System.Windows.Forms.Label labelSrcAccount;
        private System.Windows.Forms.Label labelDstAccount;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelTransactionDesc;
        private System.Windows.Forms.Label labelTransactionName;
        private System.Windows.Forms.TextBox txtDstAmount;
        private System.Windows.Forms.TextBox txtTransactionDesc;
        private System.Windows.Forms.TextBox txtTransactionName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSrcAmount;
        private System.Windows.Forms.Label labelSrcAmount;
        private System.Windows.Forms.Label labelDstAmount;
        private System.Windows.Forms.CheckBox chkSetTime;
        private System.Windows.Forms.DateTimePicker dtPickerMadeTime;
        private System.Windows.Forms.DateTimePicker dtPickerMadeDate;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnRefresh;
    }
}