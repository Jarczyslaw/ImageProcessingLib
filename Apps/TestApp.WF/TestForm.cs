using ImageProcessingLib.Converter.WF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp.WF
{
    public partial class TestForm : Form
    {
        private Bitmap bitmap;

        public TestForm()
        {
            InitializeComponent();
        }

        public TestForm(Bitmap bitmap) : this()
        {
            this.bitmap = bitmap;
            pbImage.Image = bitmap;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "image";
            sfd.DefaultExt = ".bmp";
            sfd.Filter = "Bitmap images (.bmp)|*.bmp";

            var result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    bitmap.Save(sfd.FileName, ImageFormat.Bmp);
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
                    bitmap.Dispose();
                    bitmap = new Bitmap(ofd.FileName);
                    var image = ImageProcessingLibConverter.CreateImageFromBitmap(bitmap);
                    var targetBitmap = ImageProcessingLibConverter.CreateBitmapFromImage(image);
                    pbImage.Image = targetBitmap;
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
            bitmap.Dispose();
        }
    }
}
