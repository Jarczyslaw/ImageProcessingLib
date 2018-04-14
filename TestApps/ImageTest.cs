using ImageProcessingLib;
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
    public partial class ImageTest : Form
    {
        public ImageTest()
        {
            InitializeComponent();
            var image = GetImage();
            ResizeTo(image.Width, image.Height);
        }

        private ImageBase GetImage()
        {
            throw new NotImplementedException();
        }

        private void ResizeTo(int width, int height)
        {
            int x = Width - width;
            int y = Height - height;
            Width = pbImage.Width + x;
            Height = pbImage.Height + y;
        }
    }
}
