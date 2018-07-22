using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
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
   
            using (var g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Aqua, new Rectangle(0, 0, 32, 64));
            }
            pbImage.Image = bitmap;
        }
    }
}
