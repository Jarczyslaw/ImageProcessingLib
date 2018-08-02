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

        public TestForm(ImageWrapper imageWrapper) : this()
        {
            this.imageWrapper = imageWrapper;
            if (imageWrapper != null)
                pbImage.Image = imageWrapper.Bitmap;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (imageWrapper == null)
                return;

            var sfd = new SaveFileDialog();
            sfd.FileName = "image";
            sfd.DefaultExt = ".bmp";
            sfd.Filter = "Bitmap images (.bmp)|*.bmp";

            var result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    imageWrapper.ToFile(sfd.FileName);
                    MessageBox.Show("Image saved", "Information");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Can not save file: " + exc.Message, "Exception");
                }
            }
        }

        private void miLoad_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ofd.Filter = "Bitmap images (.bmp)|*.bmp";

            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    imageWrapper?.Dispose();
                    var tempWrapper = new ImageWrapper(ofd.FileName);
                    imageWrapper = new ImageWrapper(tempWrapper.Image32);
                    pbImage.Image = imageWrapper.Bitmap;
                    MessageBox.Show("Image loaded", "Information");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Can not load file: " + exc.Message, "Exception");
                }
            }
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageWrapper?.Dispose();
        }
    }
}
