namespace PersonalBookKeeper
{
    partial class TypeForm
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
            this.rBtnLiability = new System.Windows.Forms.RadioButton();
            this.rBtnAsset = new System.Windows.Forms.RadioButton();
            this.labelTypeFlag = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtParentID = new System.Windows.Forms.TextBox();
            this.txtTypeDesc = new System.Windows.Forms.TextBox();
            this.labelTypeDesc = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.labelTypeName = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelDbGridView = new System.Windows.Forms.Label();
            this.trViewTypes = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // rBtnLiability
            // 
            this.rBtnLiability.Enabled = false;
            this.rBtnLiability.Location = new System.Drawing.Point(968, 370);
            this.rBtnLiability.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnLiability.Name = "rBtnLiability";
            this.rBtnLiability.Size = new System.Drawing.Size(104, 22);
            this.rBtnLiability.TabIndex = 12;
            this.rBtnLiability.TabStop = true;
            this.rBtnLiability.UseVisualStyleBackColor = true;
            // 
            // rBtnAsset
            // 
            this.rBtnAsset.Enabled = false;
            this.rBtnAsset.Location = new System.Drawing.Point(856, 370);
            this.rBtnAsset.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnAsset.Name = "rBtnAsset";
            this.rBtnAsset.Size = new System.Drawing.Size(104, 22);
            this.rBtnAsset.TabIndex = 11;
            this.rBtnAsset.TabStop = true;
            this.rBtnAsset.UseVisualStyleBackColor = true;
            // 
            // labelTypeFlag
            // 
            this.labelTypeFlag.Location = new System.Drawing.Point(697, 364);
            this.labelTypeFlag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTypeFlag.Name = "labelTypeFlag";
            this.labelTypeFlag.Size = new System.Drawing.Size(150, 34);
            this.labelTypeFlag.TabIndex = 10;
            this.labelTypeFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1074, 55);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(48, 29);
            this.txtID.TabIndex = 5;
            this.txtID.Visible = false;
            // 
            // txtParentID
            // 
            this.txtParentID.Location = new System.Drawing.Point(1015, 55);
            this.txtParentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.ReadOnly = true;
            this.txtParentID.Size = new System.Drawing.Size(48, 29);
            this.txtParentID.TabIndex = 4;
            this.txtParentID.Visible = false;
            // 
            // txtTypeDesc
            // 
            this.txtTypeDesc.Location = new System.Drawing.Point(856, 137);
            this.txtTypeDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtTypeDesc.Multiline = true;
            this.txtTypeDesc.Name = "txtTypeDesc";
            this.txtTypeDesc.ReadOnly = true;
            this.txtTypeDesc.Size = new System.Drawing.Size(345, 216);
            this.txtTypeDesc.TabIndex = 9;
            // 
            // labelTypeDesc
            // 
            this.labelTypeDesc.Location = new System.Drawing.Point(697, 137);
            this.labelTypeDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTypeDesc.Name = "labelTypeDesc";
            this.labelTypeDesc.Size = new System.Drawing.Size(150, 34);
            this.labelTypeDesc.TabIndex = 8;
            this.labelTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(856, 94);
            this.txtTypeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(345, 29);
            this.txtTypeName.TabIndex = 7;
            // 
            // labelTypeName
            // 
            this.labelTypeName.Location = new System.Drawing.Point(697, 94);
            this.labelTypeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTypeName.Name = "labelTypeName";
            this.labelTypeName.Size = new System.Drawing.Size(151, 34);
            this.labelTypeName.TabIndex = 6;
            this.labelTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(857, 50);
            this.btnMod.Margin = new System.Windows.Forms.Padding(4);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(150, 34);
            this.btnMod.TabIndex = 3;
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(697, 50);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelDbGridView
            // 
            this.labelDbGridView.Location = new System.Drawing.Point(12, 12);
            this.labelDbGridView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDbGridView.Name = "labelDbGridView";
            this.labelDbGridView.Size = new System.Drawing.Size(624, 34);
            this.labelDbGridView.TabIndex = 0;
            this.labelDbGridView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trViewTypes
            // 
            this.trViewTypes.FullRowSelect = true;
            this.trViewTypes.HideSelection = false;
            this.trViewTypes.Location = new System.Drawing.Point(15, 50);
            this.trViewTypes.Margin = new System.Windows.Forms.Padding(4);
            this.trViewTypes.Name = "trViewTypes";
            this.trViewTypes.Size = new System.Drawing.Size(674, 533);
            this.trViewTypes.TabIndex = 1;
            this.trViewTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trViewTypes_AfterSelect);
            // 
            // TypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 596);
            this.ControlBox = false;
            this.Controls.Add(this.rBtnLiability);
            this.Controls.Add(this.rBtnAsset);
            this.Controls.Add(this.labelTypeFlag);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtParentID);
            this.Controls.Add(this.txtTypeDesc);
            this.Controls.Add(this.labelTypeDesc);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.labelTypeName);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelDbGridView);
            this.Controls.Add(this.trViewTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.TypeForm_Load);
            this.SizeChanged += new System.EventHandler(this.TypeForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rBtnLiability;
        private System.Windows.Forms.RadioButton rBtnAsset;
        private System.Windows.Forms.Label labelTypeFlag;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtParentID;
        private System.Windows.Forms.TextBox txtTypeDesc;
        private System.Windows.Forms.Label labelTypeDesc;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label labelTypeName;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelDbGridView;
        private System.Windows.Forms.TreeView trViewTypes;
    }
}