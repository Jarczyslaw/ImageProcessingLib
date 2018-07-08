using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Controls
{
    public partial class ScrollablePictureBox : UserControl
    {
        public Bitmap Image
        {
            set { pbImage.Image = value; }
            get { return pbImage.Image as Bitmap; }
        }

        public ScrollablePictureBox()
        {
            InitializeComponent();
        }
    }
}
