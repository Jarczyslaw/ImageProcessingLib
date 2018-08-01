using ImageProcessingLib.Wrappers.WF;
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
        private ImageWrapper imageWrapper;

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

        private void miSave_Click(object sender, EventArgs e)
        {

        }

        private void miLoad_Click(object sender, EventArgs e)
        {

        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
