using Commons;
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingTest.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingTest
{
    public partial class MainForm : Form
    {
        private Dictionary<string, OperationBase> operations = new Dictionary<string, OperationBase>();
        private OperationBase currentOperation = null;
        private Bitmap currentBitmap = null;

        public MainForm()
        {
            InitializeComponent();

            var images = ImagesFolder.Images.AllBitmaps;
            cbImages.BindDictionary(images);
            cbImages.SelectedIndex = -1;

            operations = OperationsLoader.CreateOperationsDictionary();
            cbOperations.BindDictionary(operations);
            cbOperations.SelectedIndex = -1;
        }

        private void cbImages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PerformOperation();
        }

        private void cbOperations_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PerformOperation();
        }

        private void cbResults_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowCurrentImage();
        }

        private async void PerformOperation()
        {
            var image = cbImages.SelectedValue as Bitmap;
            var operation = cbOperations.SelectedValue as OperationBase;
            if (image == null || operation == null)
                return;
            if (image == currentBitmap && currentOperation == operation)
                return;

            currentBitmap = image;
            currentOperation = operation;

            this.DisableControls();
            Application.UseWaitCursor = true;
            await LaunchOperation(image, operation);
            LoadResults();
            this.EnableControls();
            Application.UseWaitCursor = false;
        }

        private void LoadResults()
        {
            cbResults.BindDictionary(currentOperation.Images);
            ShowCurrentImage();
        }

        private async Task LaunchOperation(Bitmap bitmap, OperationBase operation)
        {
            currentOperation?.CleanUp();
            currentOperation = operation;
            try
            {
                TimeSpan initializationTime = TimeSpan.Zero;
                await Task.Run(() =>
                {
                    initializationTime = ExecTime.Run(() => operation.ApplyOperation(bitmap));
                });
                MessageBoxEx.ShowInfo(string.Format("{0} initialized in {1:0} ms", operation.GetType().Name, initializationTime.TotalMilliseconds));
            }
            catch(Exception e)
            {
                MessageBoxEx.ShowError(e);
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
            currentOperation?.CleanUp();
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
                    MessageBoxEx.ShowError(exc);
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (currentOperation == null)
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
                    foreach (var operationResult in currentOperation.Images)
                    {
                        var fileName = operationResult.Key;
                        var image = operationResult.Value;
                        var filePath = Path.Combine(fbd.SelectedPath, fileName + ".bmp");
                        image.ToFile(filePath, ImageFormat.Bmp);
                    }
                    MessageBoxEx.ShowInfo("Saved all images in " + fbd.SelectedPath);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowError(exc);
                }
            }
        }

        private void btnShowMetrics_Click(object sender, EventArgs e)
        {
            if (currentOperation == null)
                return;

            var originalImage = currentOperation.OriginalImage.Image;
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
                MessageBoxEx.ShowError(exc);
            }
        }
    }
}
