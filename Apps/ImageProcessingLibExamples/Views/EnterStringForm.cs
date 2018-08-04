using Commons.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Views
{
    public partial class EnterStringForm : Form
    {
        public EnterStringForm()
        {
            InitializeComponent();
        }

        public DialogResult GetString(string caption, string defaultValue, ref string enteredString)
        {
            tbEnteredString.Text = defaultValue;
            MoveCursorToEnd();

            ShowDialog();
            if (DialogResult == DialogResult.OK)
                enteredString = tbEnteredString.Text;
            return DialogResult;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (StringValidate())
                DialogResult = DialogResult.OK;
            else
                MessageBoxEx.ShowError("Entered string is invalid");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool StringValidate()
        {
            return !string.IsNullOrEmpty(tbEnteredString.Text.Trim());
        }

        private void MoveCursorToEnd()
        {
            if (string.IsNullOrEmpty(tbEnteredString.Text.Trim()))
                return;

            tbEnteredString.SelectionStart = tbEnteredString.Text.Length;
            tbEnteredString.SelectionLength = 0;
        }
    }
}
