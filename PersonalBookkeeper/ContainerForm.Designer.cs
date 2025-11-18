namespace PersonalBookKeeper
{
    partial class ContainerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerForm));
            this.tabOfForms = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabTransaction = new System.Windows.Forms.TabPage();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.tabType = new System.Windows.Forms.TabPage();
            this.tabCurrency = new System.Windows.Forms.TabPage();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.tabOfForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOfForms
            // 
            this.tabOfForms.Controls.Add(this.tabMain);
            this.tabOfForms.Controls.Add(this.tabTransaction);
            this.tabOfForms.Controls.Add(this.tabCategory);
            this.tabOfForms.Controls.Add(this.tabAccount);
            this.tabOfForms.Controls.Add(this.tabType);
            this.tabOfForms.Controls.Add(this.tabCurrency);
            this.tabOfForms.Controls.Add(this.tabSchedule);
            this.tabOfForms.Location = new System.Drawing.Point(18, 18);
            this.tabOfForms.Margin = new System.Windows.Forms.Padding(4);
            this.tabOfForms.Name = "tabOfForms";
            this.tabOfForms.SelectedIndex = 0;
            this.tabOfForms.Size = new System.Drawing.Size(1222, 628);
            this.tabOfForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabOfForms.TabIndex = 0;
            this.tabOfForms.SelectedIndexChanged += new System.EventHandler(this.tabOfForms_SelectedIndexChanged);
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(4, 28);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(4);
            this.tabMain.Size = new System.Drawing.Size(1214, 596);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = " ";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabTransaction
            // 
            this.tabTransaction.Location = new System.Drawing.Point(4, 28);
            this.tabTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.tabTransaction.Name = "tabTransaction";
            this.tabTransaction.Padding = new System.Windows.Forms.Padding(4);
            this.tabTransaction.Size = new System.Drawing.Size(1132, 548);
            this.tabTransaction.TabIndex = 2;
            this.tabTransaction.Text = " ";
            this.tabTransaction.UseVisualStyleBackColor = true;
            // 
            // tabCategory
            // 
            this.tabCategory.Location = new System.Drawing.Point(4, 28);
            this.tabCategory.Margin = new System.Windows.Forms.Padding(4);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Padding = new System.Windows.Forms.Padding(4);
            this.tabCategory.Size = new System.Drawing.Size(1132, 548);
            this.tabCategory.TabIndex = 3;
            this.tabCategory.Text = " ";
            this.tabCategory.UseVisualStyleBackColor = true;
            // 
            // tabAccount
            // 
            this.tabAccount.Location = new System.Drawing.Point(4, 28);
            this.tabAccount.Margin = new System.Windows.Forms.Padding(4);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(4);
            this.tabAccount.Size = new System.Drawing.Size(1132, 548);
            this.tabAccount.TabIndex = 1;
            this.tabAccount.Text = " ";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // tabType
            // 
            this.tabType.Location = new System.Drawing.Point(4, 28);
            this.tabType.Margin = new System.Windows.Forms.Padding(4);
            this.tabType.Name = "tabType";
            this.tabType.Padding = new System.Windows.Forms.Padding(4);
            this.tabType.Size = new System.Drawing.Size(1132, 548);
            this.tabType.TabIndex = 6;
            this.tabType.Text = " ";
            this.tabType.UseVisualStyleBackColor = true;
            // 
            // tabCurrency
            // 
            this.tabCurrency.Location = new System.Drawing.Point(4, 28);
            this.tabCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.tabCurrency.Name = "tabCurrency";
            this.tabCurrency.Padding = new System.Windows.Forms.Padding(4);
            this.tabCurrency.Size = new System.Drawing.Size(1132, 548);
            this.tabCurrency.TabIndex = 5;
            this.tabCurrency.Text = " ";
            this.tabCurrency.UseVisualStyleBackColor = true;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Location = new System.Drawing.Point(4, 28);
            this.tabSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Padding = new System.Windows.Forms.Padding(4);
            this.tabSchedule.Size = new System.Drawing.Size(1132, 548);
            this.tabSchedule.TabIndex = 4;
            this.tabSchedule.Text = " ";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // ContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.tabOfForms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ContainerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContainerForm_FormClosing);
            this.Load += new System.EventHandler(this.ContainerForm_Load);
            this.SizeChanged += new System.EventHandler(this.ContainerForm_SizeChanged);
            this.tabOfForms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.TabPage tabTransaction;
        private System.Windows.Forms.TabPage tabCategory;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabCurrency;
        private System.Windows.Forms.TabPage tabType;
        private System.Windows.Forms.TabControl tabOfForms;
    }
}

