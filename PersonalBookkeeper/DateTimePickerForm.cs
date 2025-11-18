using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalBookKeeper
{
    public partial class DateTimePickerForm : Form
    {
        private DateTime _date2Return;
        public DateTimePickerForm()
        {
            InitializeComponent();
        }

        private void DateTimePickerForm_Load(object sender, EventArgs e)
        {
            this.Text = PersonalBookKeeper.Properties.Resources.strTxtPickTransactionTime;
            dtPickerMadeDate.Value = DateTime.Now;
            dtPickerMadeTime.Value = DateTime.Now;
            //this.Text = "";"Please Pick the Date & Time the Scheduled Transaction Happens!"
            btnOK.Text = PersonalBookKeeper.Properties.Resources.strTxtConfirm;
            btnCancel.Text = PersonalBookKeeper.Properties.Resources.strTxtCancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _date2Return = (dtPickerMadeDate.Value.Date + dtPickerMadeTime.Value.TimeOfDay).ToUniversalTime();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _date2Return = DateTime.UtcNow;
            Close();
        }

        public DateTime GetPickedUTC()
        {
            return _date2Return;
        }
    }
}
