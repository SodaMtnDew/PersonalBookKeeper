namespace PersonalBookKeeper
{
    partial class DateTimePickerForm
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
            this.dtPickerMadeTime = new System.Windows.Forms.DateTimePicker();
            this.dtPickerMadeDate = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtPickerMadeTime
            // 
            this.dtPickerMadeTime.CustomFormat = "HH:mm:ss";
            this.dtPickerMadeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerMadeTime.Location = new System.Drawing.Point(214, 18);
            this.dtPickerMadeTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtPickerMadeTime.Name = "dtPickerMadeTime";
            this.dtPickerMadeTime.ShowUpDown = true;
            this.dtPickerMadeTime.Size = new System.Drawing.Size(186, 29);
            this.dtPickerMadeTime.TabIndex = 1;
            // 
            // dtPickerMadeDate
            // 
            this.dtPickerMadeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerMadeDate.Location = new System.Drawing.Point(18, 18);
            this.dtPickerMadeDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtPickerMadeDate.Name = "dtPickerMadeDate";
            this.dtPickerMadeDate.Size = new System.Drawing.Size(186, 29);
            this.dtPickerMadeDate.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(18, 60);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 60);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 34);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DateTimePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 101);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtPickerMadeTime);
            this.Controls.Add(this.dtPickerMadeDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateTimePickerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DateTimePickerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPickerMadeTime;
        private System.Windows.Forms.DateTimePicker dtPickerMadeDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}