using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons.Utils
{
    public class MessageBoxEx
    {
        public static DialogResult ShowInfo(string content)
        {
            return MessageBox.Show(content, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowException(Exception exception)
        {
            return MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowError(string error)
        {
            return MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestion(string content, MessageBoxButtons buttons)
        {
            return MessageBox.Show(content, "Question", buttons, MessageBoxIcon.Question);
        }
    }
}
