using Commons;
using Commons.Utils;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLibExamples.Examples;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Forms
{
    public partial class MainForm : Form
    {
        private Dictionary<string, ExampleBase> examples = new Dictionary<string, ExampleBase>();
        private ExampleBase currentExample = null;
        private Bitmap currentBitmap = null;

        public MainForm()
        {
            InitializeComponent();

            var images = ImagesFolder.Images.AllBitmaps;
            cbImages.BindDictionary(images);
            cbImages.SelectedIndex = -1;

            examples = ExamplesLoader.CreateExamplesDictionary();
            cbExamples.BindDictionary(examples);
            cbExamples.SelectedIndex = -1;
        }

        private void cbImages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PerformExample();
        }

        private void cbExamples_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PerformExample();
        }

        private void cbResults_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowCurrentImage();
        }

        private async void PerformExample()
        {
            var image = cbImages.SelectedValue as Bitmap;
            var example = cbExamples.SelectedValue as ExampleBase;
            if (image == null || example == null)
                return;
            if (image == currentBitmap && currentExample == example)
                return;

            currentBitmap = image;
            currentExample = example;

            this.DisableControls();
            Application.UseWaitCursor = true;
            await LaunchExample(image, example);
            LoadResults();
            this.EnableControls();
            Application.UseWaitCursor = false;
        }

        private void LoadResults()
        {
            cbResults.BindDictionary(currentExample.Images);
            ShowCurrentImage();
        }

        private async Task LaunchExample(Bitmap bitmap, ExampleBase example)
        {
            currentExample?.CleanUp();
            currentExample = example;
            try
            {
                TimeSpan initializationTime = TimeSpan.Zero;
                await Task.Run(() =>
                {
                    initializationTime = ExecTime.Run(() => example.ApplyExample(bitmap));
                });
                MessageBoxEx.ShowInfo(string.Format("{0} initialized in {1:0} ms", example.GetType().Name, initializationTime.TotalMilliseconds));
            }
            catch(Exception e)
            {
                MessageBoxEx.ShowException(e);
            }
        }

        private void ShowCurrentImage()
        {
            if (cbResults.SelectedValue == null)
                return;

            var image = cbResults.SelectedValue as GDImage32;
            pbImage.Image = image.Bitmap;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SwitchComboBoxItem(cbResults, -1);
            ShowCurrentImage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SwitchComboBoxItem(cbResults, 1);
            ShowCurrentImage();
        }

        private void SwitchComboBoxItem(ComboBox comboBox, int dir)
        {
            var nextIndex = comboBox.SelectedIndex;
            if (nextIndex == -1)
                return;

            nextIndex += dir;
            if (nextIndex >= comboBox.Items.Count)
                nextIndex = 0;
            else if (nextIndex < 0)
                nextIndex = comboBox.Items.Count - 1;
            comboBox.SelectedIndex = nextIndex;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentExample?.CleanUp();
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
                    MessageBoxEx.ShowException(exc);
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (currentExample == null)
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
                    foreach (var exampleResult in currentExample.Images)
                    {
                        var fileName = exampleResult.Key;
                        var image = exampleResult.Value;
                        var filePath = Path.Combine(fbd.SelectedPath, fileName + ".bmp");
                        image.ToFile(filePath, ImageFormat.Bmp);
                    }
                    MessageBoxEx.ShowInfo("Saved all images in " + fbd.SelectedPath);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowException(exc);
                }
            }
        }

        private void btnShowMetrics_Click(object sender, EventArgs e)
        {
            if (currentExample == null)
                return;

            var originalImage = currentExample.OriginalImage.Image;
            var currentImage = (cbResults.SelectedValue as GDImage32).Image;
            try
            {
                var mse = ErrorMetrics.MSE(originalImage, currentImage);
                var psnr = ErrorMetrics.PSNR(originalImage, currentImage);
                var message = new StringBuilder();
                message.AppendLine("Current image metrics:");
                message.AppendLine(string.Format("MSE: {0:0.00}", mse));
                message.AppendLine(string.Format("PSNR: {0:0.00}", psnr));
                MessageBoxEx.ShowInfo(message.ToString());
            }
            catch(Exception exc)
            {
                MessageBoxEx.ShowException(exc);
            }
        }
    }
}
