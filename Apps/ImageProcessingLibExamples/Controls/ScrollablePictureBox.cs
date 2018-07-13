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
        public event Action<int, int> OnMouseAction;

        public Bitmap Image
        {
            set { pbImage.Image = value; }
            get { return pbImage.Image as Bitmap; }
        }

        public ScrollablePictureBox()
        {
            InitializeComponent();
        }

        private void pbImage_MouseAction(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Image == null)
                    return;

                var x = e.Location.X;
                var y = e.Location.Y;
                if (x < 0 || x > Image.Width)
                    return;
                if (y < 0 || y > Image.Height)
                    return;

                OnMouseAction?.Invoke(x, y);
            } 
        }
    }
}
