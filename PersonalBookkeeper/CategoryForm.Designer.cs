namespace PersonalBookKeeper
{
    partial class CategoryForm
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
            this.trViewCategories = new System.Windows.Forms.TreeView();
            this.labelTreeView = new System.Windows.Forms.Label();
            this.txtParentID = new System.Windows.Forms.TextBox();
            this.txtCategoryDesc = new System.Windows.Forms.TextBox();
            this.labelCategoryDesc = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.labelCategoryName = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.labelCategoryDirect = new System.Windows.Forms.Label();
            this.rBtnIncome = new System.Windows.Forms.RadioButton();
            this.rBtnTransfer = new System.Windows.Forms.RadioButton();
            this.rBtnOutcome = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // trViewCategories
            // 
            this.trViewCategories.FullRowSelect = true;
            this.trViewCategories.Location = new System.Drawing.Point(18, 62);
            this.trViewCategories.Margin = new System.Windows.Forms.Padding(4);
            this.trViewCategories.Name = "trViewCategories";
            this.trViewCategories.Size = new System.Drawing.Size(674, 521);
            this.trViewCategories.TabIndex = 1;
            this.trViewCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trViewCategories_AfterSelect);
            // 
            // labelTreeView
            // 
            this.labelTreeView.Location = new System.Drawing.Point(18, 18);
            this.labelTreeView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTreeView.Name = "labelTreeView";
            this.labelTreeView.Size = new System.Drawing.Size(624, 34);
            this.labelTreeView.TabIndex = 0;
            this.labelTreeView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParentID
            // 
            this.txtParentID.Location = new System.Drawing.Point(1016, 62);
            this.txtParentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.ReadOnly = true;
            this.txtParentID.Size = new System.Drawing.Size(48, 29);
            this.txtParentID.TabIndex = 4;
            this.txtParentID.Visible = false;
            // 
            // txtCategoryDesc
            // 
            this.txtCategoryDesc.Location = new System.Drawing.Point(856, 153);
            this.txtCategoryDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoryDesc.Multiline = true;
            this.txtCategoryDesc.Name = "txtCategoryDesc";
            this.txtCategoryDesc.ReadOnly = true;
            this.txtCategoryDesc.Size = new System.Drawing.Size(345, 216);
            this.txtCategoryDesc.TabIndex = 9;
            // 
            // labelCategoryDesc
            // 
            this.labelCategoryDesc.Location = new System.Drawing.Point(700, 148);
            this.labelCategoryDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategoryDesc.Name = "labelCategoryDesc";
            this.labelCategoryDesc.Size = new System.Drawing.Size(148, 34);
            this.labelCategoryDesc.TabIndex = 8;
            this.labelCategoryDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(856, 110);
            this.txtCategoryName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.ReadOnly = true;
            this.txtCategoryName.Size = new System.Drawing.Size(345, 29);
            this.txtCategoryName.TabIndex = 7;
            // 
            // labelCategoryName
            // 
            this.labelCategoryName.Location = new System.Drawing.Point(700, 105);
            this.labelCategoryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategoryName.Name = "labelCategoryName";
            this.labelCategoryName.Size = new System.Drawing.Size(148, 34);
            this.labelCategoryName.TabIndex = 6;
            this.labelCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(698, 62);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1075, 62);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(48, 29);
            this.txtID.TabIndex = 5;
            this.txtID.Visible = false;
            // 
            // labelCategoryDirect
            // 
            this.labelCategoryDirect.Location = new System.Drawing.Point(700, 375);
            this.labelCategoryDirect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategoryDirect.Name = "labelCategoryDirect";
            this.labelCategoryDirect.Size = new System.Drawing.Size(148, 34);
            this.labelCategoryDirect.TabIndex = 10;
            this.labelCategoryDirect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rBtnIncome
            // 
            this.rBtnIncome.Enabled = false;
            this.rBtnIncome.Location = new System.Drawing.Point(859, 385);
            this.rBtnIncome.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnIncome.Name = "rBtnIncome";
            this.rBtnIncome.Size = new System.Drawing.Size(100, 24);
            this.rBtnIncome.TabIndex = 11;
            this.rBtnIncome.TabStop = true;
            this.rBtnIncome.UseVisualStyleBackColor = true;
            // 
            // rBtnTransfer
            // 
            this.rBtnTransfer.Enabled = false;
            this.rBtnTransfer.Location = new System.Drawing.Point(967, 385);
            this.rBtnTransfer.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnTransfer.Name = "rBtnTransfer";
            this.rBtnTransfer.Size = new System.Drawing.Size(100, 24);
            this.rBtnTransfer.TabIndex = 12;
            this.rBtnTransfer.TabStop = true;
            this.rBtnTransfer.UseVisualStyleBackColor = true;
            // 
            // rBtnOutcome
            // 
            this.rBtnOutcome.Enabled = false;
            this.rBtnOutcome.Location = new System.Drawing.Point(1075, 385);
            this.rBtnOutcome.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnOutcome.Name = "rBtnOutcome";
            this.rBtnOutcome.Size = new System.Drawing.Size(100, 24);
            this.rBtnOutcome.TabIndex = 13;
            this.rBtnOutcome.TabStop = true;
            this.rBtnOutcome.UseVisualStyleBackColor = true;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.rBtnOutcome);
            this.Controls.Add(this.rBtnTransfer);
            this.Controls.Add(this.rBtnIncome);
            this.Controls.Add(this.labelCategoryDirect);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtParentID);
            this.Controls.Add(this.txtCategoryDesc);
            this.Controls.Add(this.labelCategoryDesc);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.labelCategoryName);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelTreeView);
            this.Controls.Add(this.trViewCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.SizeChanged += new System.EventHandler(this.CategoryForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trViewCategories;
        private System.Windows.Forms.Label labelTreeView;
        private System.Windows.Forms.TextBox txtParentID;
        private System.Windows.Forms.TextBox txtCategoryDesc;
        private System.Windows.Forms.Label labelCategoryDesc;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label labelCategoryName;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label labelCategoryDirect;
        private System.Windows.Forms.RadioButton rBtnIncome;
        private System.Windows.Forms.RadioButton rBtnTransfer;
        private System.Windows.Forms.RadioButton rBtnOutcome;
    }
}