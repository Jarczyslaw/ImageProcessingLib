using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons.Utils
{
    public static class ControlExtensions
    {
        public static void SetControlsEnabled(this Control control, bool enabled, IList<Control> exclusionList = null)
        {
            foreach (Control childControl in control.Controls)
            {
                if (exclusionList == null || (exclusionList != null && !exclusionList.Contains(childControl)))
                    childControl.Enabled = enabled;
                childControl.SetControlsEnabled(enabled, exclusionList);
            }
        }

        public static void DisableControls(this Control control, IList<Control> exclusionList = null)
        {
            control.SetControlsEnabled(false, exclusionList);
        }

        public static void EnableControls(this Control control, IList<Control> exclusionList = null)
        {
            control.SetControlsEnabled(true, exclusionList);
        }
    }
}
