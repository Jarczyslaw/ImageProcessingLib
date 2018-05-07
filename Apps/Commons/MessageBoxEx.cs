using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons
{
    public class MessageBoxEx
    {
        public static DialogResult ShowInfo(string content)
        {
            return MessageBox.Show(content, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowError(Exception exception)
        {
            return MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestion(string content, MessageBoxButtons buttons)
        {
            return MessageBox.Show(content, "Question", buttons, MessageBoxIcon.Question);
        }
    }
}
