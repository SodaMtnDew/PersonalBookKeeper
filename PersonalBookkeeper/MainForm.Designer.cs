namespace PersonalBookKeeper
{
    partial class MainForm
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
            this.dbGridBalance = new System.Windows.Forms.DataGridView();
            this.labelBalance = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dbGridCashflow = new System.Windows.Forms.DataGridView();
            this.labelCashflow = new System.Windows.Forms.Label();
            this.cmbOptions = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.labelMonth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCashflow)).BeginInit();
            this.SuspendLayout();
            // 
            // dbGridBalance
            // 
            this.dbGridBalance.AllowUserToAddRows = false;
            this.dbGridBalance.AllowUserToDeleteRows = false;
            this.dbGridBalance.AllowUserToResizeColumns = false;
            this.dbGridBalance.AllowUserToResizeRows = false;
            this.dbGridBalance.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbGridBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dbGridBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridBalance.ColumnHeadersVisible = false;
            this.dbGridBalance.Location = new System.Drawing.Point(18, 62);
            this.dbGridBalance.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridBalance.MultiSelect = false;
            this.dbGridBalance.Name = "dbGridBalance";
            this.dbGridBalance.ReadOnly = true;
            this.dbGridBalance.RowHeadersVisible = false;
            this.dbGridBalance.RowHeadersWidth = 62;
            this.dbGridBalance.RowTemplate.Height = 24;
            this.dbGridBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridBalance.ShowCellErrors = false;
            this.dbGridBalance.ShowCellToolTips = false;
            this.dbGridBalance.ShowEditingIcon = false;
            this.dbGridBalance.ShowRowErrors = false;
            this.dbGridBalance.Size = new System.Drawing.Size(590, 521);
            this.dbGridBalance.TabIndex = 8;
            this.dbGridBalance.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dbGridBalance_RowsAdded);
            // 
            // labelBalance
            // 
            this.labelBalance.Location = new System.Drawing.Point(18, 18);
            this.labelBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(404, 34);
            this.labelBalance.TabIndex = 0;
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(496, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 34);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dbGridCashflow
            // 
            this.dbGridCashflow.AllowUserToAddRows = false;
            this.dbGridCashflow.AllowUserToDeleteRows = false;
            this.dbGridCashflow.AllowUserToResizeColumns = false;
            this.dbGridCashflow.AllowUserToResizeRows = false;
            this.dbGridCashflow.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbGridCashflow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dbGridCashflow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridCashflow.ColumnHeadersVisible = false;
            this.dbGridCashflow.Location = new System.Drawing.Point(616, 62);
            this.dbGridCashflow.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridCashflow.MultiSelect = false;
            this.dbGridCashflow.Name = "dbGridCashflow";
            this.dbGridCashflow.ReadOnly = true;
            this.dbGridCashflow.RowHeadersVisible = false;
            this.dbGridCashflow.RowHeadersWidth = 62;
            this.dbGridCashflow.RowTemplate.Height = 24;
            this.dbGridCashflow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridCashflow.ShowCellErrors = false;
            this.dbGridCashflow.ShowCellToolTips = false;
            this.dbGridCashflow.ShowEditingIcon = false;
            this.dbGridCashflow.ShowRowErrors = false;
            this.dbGridCashflow.Size = new System.Drawing.Size(585, 521);
            this.dbGridCashflow.TabIndex = 9;
            this.dbGridCashflow.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dbGridCashflow_RowsAdded);
            // 
            // labelCashflow
            // 
            this.labelCashflow.Location = new System.Drawing.Point(616, 18);
            this.labelCashflow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCashflow.Name = "labelCashflow";
            this.labelCashflow.Size = new System.Drawing.Size(108, 34);
            this.labelCashflow.TabIndex = 2;
            this.labelCashflow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOptions
            // 
            this.cmbOptions.FormattingEnabled = true;
            this.cmbOptions.ItemHeight = 18;
            this.cmbOptions.Location = new System.Drawing.Point(732, 22);
            this.cmbOptions.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOptions.Name = "cmbOptions";
            this.cmbOptions.Size = new System.Drawing.Size(184, 26);
            this.cmbOptions.TabIndex = 3;
            this.cmbOptions.SelectedIndexChanged += new System.EventHandler(this.cmbOptions_SelectedIndexChanged);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(1049, 21);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(62, 29);
            this.txtYear.TabIndex = 5;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // labelYear
            // 
            this.labelYear.Location = new System.Drawing.Point(939, 18);
            this.labelYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(51, 34);
            this.labelYear.TabIndex = 4;
            this.labelYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(1167, 21);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(34, 29);
            this.txtMonth.TabIndex = 7;
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonth_KeyPress);
            // 
            // labelMonth
            // 
            this.labelMonth.Location = new System.Drawing.Point(1094, 18);
            this.labelMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(65, 34);
            this.labelMonth.TabIndex = 6;
            this.labelMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.cmbOptions);
            this.Controls.Add(this.labelCashflow);
            this.Controls.Add(this.dbGridCashflow);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.dbGridBalance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCashflow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridBalance;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dbGridCashflow;
        private System.Windows.Forms.Label labelCashflow;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label labelMonth;
    }
}