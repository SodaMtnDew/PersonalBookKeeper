namespace PersonalBookKeeper
{
    partial class ScheduleForm
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
            this.btnRun = new System.Windows.Forms.Button();
            this.labelDstAmount = new System.Windows.Forms.Label();
            this.labelSrcAmount = new System.Windows.Forms.Label();
            this.txtSrcAmount = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDstAmount = new System.Windows.Forms.TextBox();
            this.txtScheduleDesc = new System.Windows.Forms.TextBox();
            this.txtScheduleName = new System.Windows.Forms.TextBox();
            this.labelScheduleDesc = new System.Windows.Forms.Label();
            this.labelScheduleName = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelDstAccount = new System.Windows.Forms.Label();
            this.labelSrcAccount = new System.Windows.Forms.Label();
            this.dbGridCategory = new System.Windows.Forms.DataGridView();
            this.dbGridDstAccount = new System.Windows.Forms.DataGridView();
            this.dbGridSrcAccount = new System.Windows.Forms.DataGridView();
            this.dbGridSchedule = new System.Windows.Forms.DataGridView();
            this.labelDbSchedules = new System.Windows.Forms.Label();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.txtLastUpdate = new System.Windows.Forms.TextBox();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.rBtnAll = new System.Windows.Forms.RadioButton();
            this.rBtnDue = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridDstAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridSrcAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(448, 215);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(150, 34);
            this.btnRun.TabIndex = 9;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // labelDstAmount
            // 
            this.labelDstAmount.Location = new System.Drawing.Point(26, 543);
            this.labelDstAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDstAmount.Name = "labelDstAmount";
            this.labelDstAmount.Size = new System.Drawing.Size(155, 34);
            this.labelDstAmount.TabIndex = 26;
            this.labelDstAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSrcAmount
            // 
            this.labelSrcAmount.Location = new System.Drawing.Point(26, 500);
            this.labelSrcAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSrcAmount.Name = "labelSrcAmount";
            this.labelSrcAmount.Size = new System.Drawing.Size(155, 34);
            this.labelSrcAmount.TabIndex = 22;
            this.labelSrcAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSrcAmount
            // 
            this.txtSrcAmount.Location = new System.Drawing.Point(189, 500);
            this.txtSrcAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtSrcAmount.Name = "txtSrcAmount";
            this.txtSrcAmount.ReadOnly = true;
            this.txtSrcAmount.Size = new System.Drawing.Size(382, 29);
            this.txtSrcAmount.TabIndex = 23;
            this.txtSrcAmount.TextChanged += new System.EventHandler(this.txtSrcAmount_TextChanged);
            this.txtSrcAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSrcAmount_KeyPress);
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
            // txtDstAmount
            // 
            this.txtDstAmount.Location = new System.Drawing.Point(189, 543);
            this.txtDstAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDstAmount.Name = "txtDstAmount";
            this.txtDstAmount.ReadOnly = true;
            this.txtDstAmount.Size = new System.Drawing.Size(380, 29);
            this.txtDstAmount.TabIndex = 27;
            this.txtDstAmount.TextChanged += new System.EventHandler(this.txtDstAmount_TextChanged);
            this.txtDstAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDstAmount_KeyPress);
            // 
            // txtScheduleDesc
            // 
            this.txtScheduleDesc.Location = new System.Drawing.Point(191, 296);
            this.txtScheduleDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtScheduleDesc.Multiline = true;
            this.txtScheduleDesc.Name = "txtScheduleDesc";
            this.txtScheduleDesc.ReadOnly = true;
            this.txtScheduleDesc.Size = new System.Drawing.Size(380, 108);
            this.txtScheduleDesc.TabIndex = 13;
            // 
            // txtScheduleName
            // 
            this.txtScheduleName.Location = new System.Drawing.Point(191, 253);
            this.txtScheduleName.Margin = new System.Windows.Forms.Padding(4);
            this.txtScheduleName.Name = "txtScheduleName";
            this.txtScheduleName.ReadOnly = true;
            this.txtScheduleName.Size = new System.Drawing.Size(380, 29);
            this.txtScheduleName.TabIndex = 11;
            // 
            // labelScheduleDesc
            // 
            this.labelScheduleDesc.Location = new System.Drawing.Point(26, 287);
            this.labelScheduleDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScheduleDesc.Name = "labelScheduleDesc";
            this.labelScheduleDesc.Size = new System.Drawing.Size(155, 34);
            this.labelScheduleDesc.TabIndex = 12;
            this.labelScheduleDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelScheduleName
            // 
            this.labelScheduleName.Location = new System.Drawing.Point(26, 253);
            this.labelScheduleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScheduleName.Name = "labelScheduleName";
            this.labelScheduleName.Size = new System.Drawing.Size(155, 34);
            this.labelScheduleName.TabIndex = 10;
            this.labelScheduleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(302, 215);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(150, 34);
            this.btnDel.TabIndex = 8;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 215);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelCategory
            // 
            this.labelCategory.Location = new System.Drawing.Point(786, 215);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(205, 34);
            this.labelCategory.TabIndex = 18;
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDstAccount
            // 
            this.labelDstAccount.Location = new System.Drawing.Point(999, 215);
            this.labelDstAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDstAccount.Name = "labelDstAccount";
            this.labelDstAccount.Size = new System.Drawing.Size(202, 34);
            this.labelDstAccount.TabIndex = 24;
            this.labelDstAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSrcAccount
            // 
            this.labelSrcAccount.Location = new System.Drawing.Point(576, 215);
            this.labelSrcAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSrcAccount.Name = "labelSrcAccount";
            this.labelSrcAccount.Size = new System.Drawing.Size(205, 34);
            this.labelSrcAccount.TabIndex = 20;
            this.labelSrcAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dbGridCategory.Location = new System.Drawing.Point(789, 253);
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
            this.dbGridCategory.Size = new System.Drawing.Size(202, 330);
            this.dbGridCategory.TabIndex = 19;
            this.dbGridCategory.SelectionChanged += new System.EventHandler(this.dbGridCategory_SelectionChanged);
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
            this.dbGridDstAccount.Location = new System.Drawing.Point(999, 253);
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
            this.dbGridDstAccount.Size = new System.Drawing.Size(202, 330);
            this.dbGridDstAccount.TabIndex = 25;
            this.dbGridDstAccount.SelectionChanged += new System.EventHandler(this.dbGridDstAccount_SelectionChanged);
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
            this.dbGridSrcAccount.Location = new System.Drawing.Point(579, 253);
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
            this.dbGridSrcAccount.Size = new System.Drawing.Size(202, 330);
            this.dbGridSrcAccount.TabIndex = 21;
            this.dbGridSrcAccount.SelectionChanged += new System.EventHandler(this.dbGridSrcAccount_SelectionChanged);
            // 
            // dbGridSchedule
            // 
            this.dbGridSchedule.AllowUserToAddRows = false;
            this.dbGridSchedule.AllowUserToDeleteRows = false;
            this.dbGridSchedule.AllowUserToResizeRows = false;
            this.dbGridSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridSchedule.Location = new System.Drawing.Point(18, 62);
            this.dbGridSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridSchedule.MultiSelect = false;
            this.dbGridSchedule.Name = "dbGridSchedule";
            this.dbGridSchedule.ReadOnly = true;
            this.dbGridSchedule.RowHeadersVisible = false;
            this.dbGridSchedule.RowHeadersWidth = 62;
            this.dbGridSchedule.RowTemplate.Height = 24;
            this.dbGridSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridSchedule.ShowCellErrors = false;
            this.dbGridSchedule.ShowCellToolTips = false;
            this.dbGridSchedule.ShowEditingIcon = false;
            this.dbGridSchedule.ShowRowErrors = false;
            this.dbGridSchedule.Size = new System.Drawing.Size(1183, 149);
            this.dbGridSchedule.TabIndex = 5;
            this.dbGridSchedule.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dbGridSchedule_RowsAdded);
            this.dbGridSchedule.SelectionChanged += new System.EventHandler(this.dbGridSchedule_SelectionChanged);
            // 
            // labelDbSchedules
            // 
            this.labelDbSchedules.Location = new System.Drawing.Point(18, 18);
            this.labelDbSchedules.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbSchedules.Name = "labelDbSchedules";
            this.labelDbSchedules.Size = new System.Drawing.Size(514, 34);
            this.labelDbSchedules.TabIndex = 0;
            this.labelDbSchedules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.Location = new System.Drawing.Point(26, 456);
            this.labelLastUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(155, 34);
            this.labelLastUpdate.TabIndex = 16;
            this.labelLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPeriod
            // 
            this.labelPeriod.Location = new System.Drawing.Point(26, 412);
            this.labelPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(155, 34);
            this.labelPeriod.TabIndex = 14;
            this.labelPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.Location = new System.Drawing.Point(189, 456);
            this.txtLastUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(382, 29);
            this.txtLastUpdate.TabIndex = 17;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(189, 412);
            this.txtPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(382, 29);
            this.txtPeriod.TabIndex = 15;
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriod_KeyPress);
            // 
            // rBtnAll
            // 
            this.rBtnAll.Location = new System.Drawing.Point(775, 20);
            this.rBtnAll.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnAll.Name = "rBtnAll";
            this.rBtnAll.Size = new System.Drawing.Size(150, 34);
            this.rBtnAll.TabIndex = 2;
            this.rBtnAll.TabStop = true;
            this.rBtnAll.UseVisualStyleBackColor = true;
            // 
            // rBtnDue
            // 
            this.rBtnDue.Location = new System.Drawing.Point(931, 18);
            this.rBtnDue.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnDue.Name = "rBtnDue";
            this.rBtnDue.Size = new System.Drawing.Size(150, 34);
            this.rBtnDue.TabIndex = 3;
            this.rBtnDue.TabStop = true;
            this.rBtnDue.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1089, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(161, 215);
            this.btnMod.Margin = new System.Windows.Forms.Padding(4);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(150, 34);
            this.btnMod.TabIndex = 7;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.rBtnDue);
            this.Controls.Add(this.rBtnAll);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.txtLastUpdate);
            this.Controls.Add(this.labelPeriod);
            this.Controls.Add(this.labelLastUpdate);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.labelDstAmount);
            this.Controls.Add(this.labelSrcAmount);
            this.Controls.Add(this.txtSrcAmount);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtDstAmount);
            this.Controls.Add(this.txtScheduleDesc);
            this.Controls.Add(this.txtScheduleName);
            this.Controls.Add(this.labelScheduleDesc);
            this.Controls.Add(this.labelScheduleName);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelDstAccount);
            this.Controls.Add(this.labelSrcAccount);
            this.Controls.Add(this.dbGridCategory);
            this.Controls.Add(this.dbGridDstAccount);
            this.Controls.Add(this.dbGridSrcAccount);
            this.Controls.Add(this.dbGridSchedule);
            this.Controls.Add(this.labelDbSchedules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.SizeChanged += new System.EventHandler(this.ScheduleForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridDstAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridSrcAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label labelDstAmount;
        private System.Windows.Forms.Label labelSrcAmount;
        private System.Windows.Forms.TextBox txtSrcAmount;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDstAmount;
        private System.Windows.Forms.TextBox txtScheduleDesc;
        private System.Windows.Forms.TextBox txtScheduleName;
        private System.Windows.Forms.Label labelScheduleDesc;
        private System.Windows.Forms.Label labelScheduleName;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelDstAccount;
        private System.Windows.Forms.Label labelSrcAccount;
        private System.Windows.Forms.DataGridView dbGridCategory;
        private System.Windows.Forms.DataGridView dbGridDstAccount;
        private System.Windows.Forms.DataGridView dbGridSrcAccount;
        private System.Windows.Forms.DataGridView dbGridSchedule;
        private System.Windows.Forms.Label labelDbSchedules;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.TextBox txtLastUpdate;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.RadioButton rBtnAll;
        private System.Windows.Forms.RadioButton rBtnDue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMod;
    }
}