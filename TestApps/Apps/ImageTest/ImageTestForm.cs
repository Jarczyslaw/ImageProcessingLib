using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApps.Utils;
using TestApps;
using TestApps.Apps.ImageTest.ImagesCollectionSources;

namespace TestApps.Apps.ImageTest
{
    [App("Images Test")]
    public partial class ImageTestForm : Form
    {
        private GDImage32 originalImage;
        private ImagesCollection imagesCollection;
        private IImageCollectionSource imageCollectionSource;

        public ImageTestForm()
        {
            InitializeComponent();
            AppAttribute.ApplyTitle(this);
            imageCollectionSource = new RotationCollectionSource();
        }

        private async void ImageTest_Load(object sender, EventArgs e)
        {
            originalImage = new GDImage32(ImagesFolder.Images.HalfLena);
            Enabled = false;
            await Task.Run(() =>
            {
                var execTime = ExecTime.Run(() =>
                {
                    imagesCollection = imageCollectionSource.GetCollection(originalImage.Image);
                });
                Debug.WriteLine(string.Format("Loaded images in {0} ms", execTime.TotalMilliseconds));
            });
            LoadImagesList();
            Enabled = true;
        }

        private void LoadImagesList()
        {
            cbImages.DataSource = new BindingSource(imagesCollection.Images, null);
            cbImages.DisplayMember = "Title";
            cbImages.ValueMember = "GDImage";
            LoadImage(imagesCollection.GetFirstImage());
        }

        private void ImageTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            originalImage.Dispose();
            imagesCollection.Dispose();
        }

        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var cm = new ContextMenu();
            cm.MenuItems.Add("Save", SaveImage);
            cm.MenuItems.Add("Save all", SaveAll);
            cm.Show(pbImage, e.Location);
        }

        private void SaveAll(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog()
            {
                SelectedPath = Environment.SpecialFolder.DesktopDirectory.ToString()
            };
            var dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    imagesCollection.Save(fbd.SelectedPath);
                    MessageBoxEx.ShowInfo("Saved all images in " + fbd.SelectedPath);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowError(exc.ToString());
                }
            }
        }

        private void SaveImage(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "Bitmap Image (.bmp)|*.bmp",
                FileName = "image"
            };
            var dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    originalImage.ToFile(sfd.FileName);
                    MessageBoxEx.ShowInfo("Image saved as: " + sfd.FileName);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowError(exc.ToString());
                }
            }
        }

        private void cbImages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var image = cbImages.SelectedValue as GDImage32;
            pbImage.Image = image.Bitmap;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            LoadImage(imagesCollection.PreviousImage());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadImage(imagesCollection.NextImage());
        }

        private void LoadImage(GDImage32 image)
        {
            pbImage.Image = image.Bitmap;
            cbImages.SelectedValue = image;
        }
    }
}
