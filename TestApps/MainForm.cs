using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApps.Utils;

namespace TestApps.Apps
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var loader = new FormsLoader();
            var forms = loader.GetAllForms(typeof(MainForm));
            FillButtonsPanel(forms);
        }

        private void FillButtonsPanel(List<Type> forms)
        {
            foreach (var form in forms)
            {
                var button = CreateButton(form);
                plButtons.Controls.Add(button);
            }
        }

        private Button CreateButton(Type childForm)
        {
            var button = new Button()
            {
                Tag = childForm,
                Name = "btn" + childForm.Name,
                Dock = DockStyle.Top,
                Height = 40,
                Text = childForm.GetCustomAttribute<AppAttribute>().Title
            };
            button.Click += (sender, args) =>
            {
                try
                {
                    var form = (Form)Activator.CreateInstance(childForm);
                    form.ShowDialog();
                }
                catch (Exception e)
                {
                    MessageBoxEx.ShowError(e.ToString());
                }
            };
            return button;
        }
    }
}
