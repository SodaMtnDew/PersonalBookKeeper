namespace PersonalBookKeeper
{
    partial class CurrencyForm
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
            this.labelDbGridView = new System.Windows.Forms.Label();
            this.dbGridCurrency = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.labelCurrencyName = new System.Windows.Forms.Label();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.labelCurrencyAcronym = new System.Windows.Forms.Label();
            this.txtCurrencyAcronym = new System.Windows.Forms.TextBox();
            this.chkIsMainCurrency = new System.Windows.Forms.CheckBox();
            this.labelCurrencyDecimalPoint = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCurrencyDecimalPoint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDbGridView
            // 
            this.labelDbGridView.Location = new System.Drawing.Point(18, 18);
            this.labelDbGridView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbGridView.Name = "labelDbGridView";
            this.labelDbGridView.Size = new System.Drawing.Size(674, 34);
            this.labelDbGridView.TabIndex = 0;
            this.labelDbGridView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dbGridCurrency
            // 
            this.dbGridCurrency.AllowUserToAddRows = false;
            this.dbGridCurrency.AllowUserToDeleteRows = false;
            this.dbGridCurrency.AllowUserToResizeColumns = false;
            this.dbGridCurrency.AllowUserToResizeRows = false;
            this.dbGridCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridCurrency.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dbGridCurrency.Location = new System.Drawing.Point(18, 62);
            this.dbGridCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.dbGridCurrency.MultiSelect = false;
            this.dbGridCurrency.Name = "dbGridCurrency";
            this.dbGridCurrency.ReadOnly = true;
            this.dbGridCurrency.RowHeadersVisible = false;
            this.dbGridCurrency.RowHeadersWidth = 62;
            this.dbGridCurrency.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dbGridCurrency.RowTemplate.Height = 24;
            this.dbGridCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbGridCurrency.ShowCellErrors = false;
            this.dbGridCurrency.ShowCellToolTips = false;
            this.dbGridCurrency.ShowEditingIcon = false;
            this.dbGridCurrency.ShowRowErrors = false;
            this.dbGridCurrency.Size = new System.Drawing.Size(674, 521);
            this.dbGridCurrency.TabIndex = 1;
            this.dbGridCurrency.SelectionChanged += new System.EventHandler(this.dbGridCurrency_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(700, 62);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(858, 62);
            this.btnMod.Margin = new System.Windows.Forms.Padding(4);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(150, 34);
            this.btnMod.TabIndex = 3;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // labelCurrencyName
            // 
            this.labelCurrencyName.Location = new System.Drawing.Point(700, 100);
            this.labelCurrencyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrencyName.Name = "labelCurrencyName";
            this.labelCurrencyName.Size = new System.Drawing.Size(167, 34);
            this.labelCurrencyName.TabIndex = 5;
            this.labelCurrencyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(875, 105);
            this.txtCurrencyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.ReadOnly = true;
            this.txtCurrencyName.Size = new System.Drawing.Size(326, 29);
            this.txtCurrencyName.TabIndex = 6;
            // 
            // labelCurrencyAcronym
            // 
            this.labelCurrencyAcronym.Location = new System.Drawing.Point(697, 142);
            this.labelCurrencyAcronym.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrencyAcronym.Name = "labelCurrencyAcronym";
            this.labelCurrencyAcronym.Size = new System.Drawing.Size(170, 34);
            this.labelCurrencyAcronym.TabIndex = 7;
            this.labelCurrencyAcronym.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrencyAcronym
            // 
            this.txtCurrencyAcronym.Location = new System.Drawing.Point(875, 142);
            this.txtCurrencyAcronym.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrencyAcronym.Name = "txtCurrencyAcronym";
            this.txtCurrencyAcronym.ReadOnly = true;
            this.txtCurrencyAcronym.Size = new System.Drawing.Size(326, 29);
            this.txtCurrencyAcronym.TabIndex = 8;
            // 
            // chkIsMainCurrency
            // 
            this.chkIsMainCurrency.Enabled = false;
            this.chkIsMainCurrency.Location = new System.Drawing.Point(700, 216);
            this.chkIsMainCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsMainCurrency.Name = "chkIsMainCurrency";
            this.chkIsMainCurrency.Size = new System.Drawing.Size(501, 34);
            this.chkIsMainCurrency.TabIndex = 11;
            this.chkIsMainCurrency.UseVisualStyleBackColor = true;
            // 
            // labelCurrencyDecimalPoint
            // 
            this.labelCurrencyDecimalPoint.Location = new System.Drawing.Point(700, 174);
            this.labelCurrencyDecimalPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrencyDecimalPoint.Name = "labelCurrencyDecimalPoint";
            this.labelCurrencyDecimalPoint.Size = new System.Drawing.Size(167, 34);
            this.labelCurrencyDecimalPoint.TabIndex = 9;
            this.labelCurrencyDecimalPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1016, 62);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(127, 29);
            this.txtID.TabIndex = 4;
            this.txtID.Visible = false;
            // 
            // txtCurrencyDecimalPoint
            // 
            this.txtCurrencyDecimalPoint.Location = new System.Drawing.Point(875, 179);
            this.txtCurrencyDecimalPoint.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrencyDecimalPoint.Name = "txtCurrencyDecimalPoint";
            this.txtCurrencyDecimalPoint.ReadOnly = true;
            this.txtCurrencyDecimalPoint.Size = new System.Drawing.Size(326, 29);
            this.txtCurrencyDecimalPoint.TabIndex = 10;
            this.txtCurrencyDecimalPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrencyDecimalPoint_KeyPress);
            // 
            // CurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtCurrencyDecimalPoint);
            this.Controls.Add(this.labelCurrencyDecimalPoint);
            this.Controls.Add(this.chkIsMainCurrency);
            this.Controls.Add(this.txtCurrencyAcronym);
            this.Controls.Add(this.labelCurrencyAcronym);
            this.Controls.Add(this.txtCurrencyName);
            this.Controls.Add(this.labelCurrencyName);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dbGridCurrency);
            this.Controls.Add(this.labelDbGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrencyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CurrencyForm_Load);
            this.SizeChanged += new System.EventHandler(this.CurrencyForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridCurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDbGridView;
        private System.Windows.Forms.DataGridView dbGridCurrency;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Label labelCurrencyName;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.Label labelCurrencyAcronym;
        private System.Windows.Forms.TextBox txtCurrencyAcronym;
        private System.Windows.Forms.CheckBox chkIsMainCurrency;
        private System.Windows.Forms.Label labelCurrencyDecimalPoint;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCurrencyDecimalPoint;
    }
}