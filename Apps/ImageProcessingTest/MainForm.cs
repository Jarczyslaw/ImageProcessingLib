using Commons;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;
using ImageProcessingTest.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingTest
{
    public partial class MainForm : Form
    {
        private Dictionary<string, OperationBase> operations = new Dictionary<string, OperationBase>();
        private Dictionary<string, GDImage32> resultImages = null;

        public MainForm()
        {
            InitializeComponent();

            var images = ImagesFolder.Images.AllBitmaps;
            cbImages.BindDictionary(images);
            cbImages.SelectedIndex = -1;
            LoadOperations();
            cbOperations.BindDictionary(operations);
            cbOperations.SelectedIndex = -1;
        }

        private void LoadOperations()
        {
            operations = new Dictionary<string, OperationBase>()
            {
                { "Resize", new ResizeOperation() },
                { "Rotate", new RotateOperation() },
                { "NaiveQuantization", new NaiveQuantizationOperation() }
            };
        }

        private void cbImages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void cbOperations_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void cbResults_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadImage();
        }

        private async void LoadResults()
        {
            var image = cbImages.SelectedValue as Bitmap;
            var operation = cbOperations.SelectedValue as OperationBase;
            if (image == null || operation == null)
                return;

            bool needsInitialization = false;
            TimeSpan initializationTime = TimeSpan.Zero;
            await Task.Run(() =>
            {
                initializationTime = ExecTime.Run(() =>
                {
                    resultImages = operation.ApplyOperation(image, out needsInitialization);
                });
            });
            cbResults.BindDictionary(resultImages);
            LoadImage();
            if (needsInitialization)
                MessageBoxEx.ShowInfo(string.Format("{0} initialized in {1} ms", operation.GetType().Name, initializationTime.TotalMilliseconds));
        }

        private void LoadImage()
        {
            var image = cbResults.SelectedValue as GDImage32;
            pbImage.Image = image.Bitmap;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SelectComboBoxItem(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SelectComboBoxItem(1);
        }

        private void SelectComboBoxItem(int dir)
        {
            var nextIndex = cbResults.SelectedIndex;
            if (nextIndex == -1)
                return;

            nextIndex += dir;
            if (nextIndex >= cbResults.Items.Count)
                nextIndex = 0;
            else if (nextIndex < 0)
                nextIndex = cbResults.Items.Count - 1;
            cbResults.SelectedIndex = nextIndex;
            cbResults_SelectionChangeCommitted(null, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var operation in operations.Values)
                operation.Dispose();
        }

        private void btnSaveCurrent_Click(object sender, EventArgs e)
        {
            if (pbImage.Image == null)
                return;

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
                    pbImage.Image.Save(sfd.FileName, ImageFormat.Bmp);
                    MessageBoxEx.ShowInfo("Image saved as: " + sfd.FileName);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowError(exc.ToString());
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (resultImages == null)
                return;

            var fbd = new FolderBrowserDialog()
            {
                SelectedPath = Environment.SpecialFolder.DesktopDirectory.ToString()
            };
            var dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    foreach (var entry in resultImages)
                    {
                        var fileName = entry.Key;
                        var image = entry.Value;
                        var filePath = Path.Combine(fbd.SelectedPath, fileName + ".bmp");
                        image.Bitmap.Save(filePath, ImageFormat.Bmp);
                    }
                    MessageBoxEx.ShowInfo("Saved all images in " + fbd.SelectedPath);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowError(exc.ToString());
                }
            }
        }
    }
}
