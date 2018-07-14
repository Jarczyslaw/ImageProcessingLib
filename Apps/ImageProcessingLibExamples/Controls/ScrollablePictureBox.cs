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
        public new event Action<int, int> OnMouseClick;
        public new event Action<int, int> OnMouseDoubleClick;
        public new event Action<int, int> OnMouseMove;

        public Bitmap Image
        {
            set { pbImage.Image = value; }
            get { return pbImage.Image as Bitmap; }
        }

        public ScrollablePictureBox()
        {
            InitializeComponent();
        }

        private bool CheckImageBoundaries(Point location)
        {
            if (Image == null)
                return false;

            if (location.X < 0 || location.X > Image.Width)
                return false;
            if (location.Y < 0 || location.Y > Image.Height)
                return false;

            return true;
        }

        private void FireMouseEvent(MouseEventArgs e, Action<int, int> mouseEvent)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!CheckImageBoundaries(e.Location))
                return;

            mouseEvent?.Invoke(e.Location.X, e.Location.Y);
        }

        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            FireMouseEvent(e, OnMouseClick);
        }

        private void pbImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FireMouseEvent(e, OnMouseDoubleClick);
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            FireMouseEvent(e, OnMouseMove);
        }
    }
}
