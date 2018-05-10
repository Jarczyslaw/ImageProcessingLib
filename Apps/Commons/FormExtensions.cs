using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons
{
    public static class FormExtensions
    {
        public static void SetControlsEnabled(this Control control, bool enabled)
        {
            foreach (Control childControl in control.Controls)
                childControl.SetControlsEnabled(enabled);
            control.Enabled = enabled;
        }

        public static void DisableControls(this Control control)
        {
            control.SetControlsEnabled(false);
        }

        public static void EnableControls(this Control control)
        {
            control.SetControlsEnabled(true);
        }
    }
}
