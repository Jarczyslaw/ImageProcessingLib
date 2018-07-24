using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp.WF
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        public TestForm(Bitmap bitmap) : this()
        {
            if (bitmap == null)
                return;
   
            pbImage.Image = bitmap;
        }
    }
}
