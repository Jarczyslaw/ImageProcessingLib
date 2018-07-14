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
    public partial class BaseForm : Form, IView
    {
        public event Action OnViewLoad;
        public event Func<bool> OnViewClosing;

        public BaseForm()
        {
            InitializeComponent();
            MinimumSize = new Size(200, 200);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnViewLoad?.Invoke();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (OnViewClosing != null)
                e.Cancel = OnViewClosing();
        }

        public void CloseView()
        {
            Close();
        }

        public void ShowView()
        {
            Show();
        }

        public void ShowView<T>(T owner)
        {
            Show(GetOwner(owner));
        }

        public void ShowViewAsDialog()
        {
            ShowDialog();
        }

        public void ShowViewAsDialog<T>(T owner)
        {
            ShowDialog(GetOwner(owner));
        }

        private Form GetOwner<T>(T owner)
        {
            var ownerView = owner as Form;
            if (ownerView == null)
                throw new ArgumentException("Owner must be a form");
            return ownerView;
        }
    }
}
