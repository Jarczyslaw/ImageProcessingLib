using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TestApps
{
    public class AppAttribute : Attribute
    {
        public string Title { get; set; }

        public AppAttribute(string title)
        {
            Title = title;
        }

        public static void ApplyTitle(Form form)
        {
            var attr = form.GetType().GetCustomAttribute<AppAttribute>();
            if (attr != null)
                form.Text = attr.Title; 
        }
    }
}
