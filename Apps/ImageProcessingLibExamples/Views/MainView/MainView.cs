﻿using Commons;
using Commons.Utils;
using ImageProcessingLib;
using ImageProcessingLibExamples.Examples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Views
{
    public partial class MainView : BaseView, IMainView
    {
        public event Action OnExampleRun;
        public event Action<string> OnCurrentImageSave;
        public event Action<string> OnImagesSave;
        public event Action<string, string> OnFileOpen;
        public event Action OnMetricsShow;
        public event Action<IHistogramView> OnHistogramShow;
        public event Action<IColorCalculatorView> OnColorCalculatorShow;
        public event Action<int, int> OnColorSelect;

        public Bitmap SelectedSourceImage
        {
            get { return cbImages.SelectedValue as Bitmap; }
        }

        public ExampleBase SelectedExample
        {
            get { return cbExamples.SelectedValue as ExampleBase; }
        }

        public ImageWrapper SelectedResultImage
        {
            get { return cbResults.SelectedValue as ImageWrapper; }
            set
            {
                var resultImage = value;
                if (resultImage != null)
                {
                    cbResults.SelectedValue = resultImage;
                    spbImage.Image = resultImage.Bitmap;
                }
                else
                    spbImage.Image = null;
            }
        }

        public string SelectedResultImageTitle
        {
            get
            {
                if (cbResults.SelectedValue == null)
                    return null;

                var imageTitle = (KeyValuePair<string, ImageWrapper>)cbResults.SelectedItem;
                return imageTitle.Key;
            }
        }

        private bool busy = false;
        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                Application.UseWaitCursor = busy;
                if (busy)
                    this.DisableControls();
                else
                    this.EnableControls();
            }
        }

        public bool ColorCalculatorEnabled
        {
            get
            {
                if (colorCalculatorView == null)
                    return false;
                if (colorCalculatorView.IsDisposed)
                    return false;
                return true;
            }
        }

        private ColorCalculatorView colorCalculatorView;

        public MainView()
        {
            InitializeComponent();
            MinimumSize = Size;
        }

        public void SetImages(Dictionary<string, Bitmap> images)
        {
            cbImages.SelectionChangeCommitted -= cbImages_SelectionChangeCommitted;
            var currentValue = cbImages.SelectedValue;
            cbImages.BindDictionary(images);
            if (currentValue != null)
                cbImages.SelectedValue = currentValue;
            else
                cbImages.SelectedIndex = -1;
            cbImages.SelectionChangeCommitted += cbImages_SelectionChangeCommitted;
        }

        public void SetExamples(Dictionary<string, ExampleBase> examples)
        {
            cbExamples.BindDictionary(examples);
            cbExamples.SelectedIndex = -1;
        }

        public void ShowMetrics(double mse, double psnr)
        {
            var message = new StringBuilder();
            message.AppendLine("Current image metrics:");
            message.AppendLine(string.Format("MSE: {0:0.00}", mse));
            message.AppendLine(string.Format("PSNR: {0:0.00}", psnr));
            ShowInfo(message.ToString());
        }

        public void AllImagesSaveInfo(int count, string path)
        {
            ShowInfo(string.Format("Saved {0} images in {1}", count, path));
        }

        public void CurrentImageSaveInfo(string path)
        {
            ShowInfo("Image saved as: " + path);
        }

        public void ShowInfo(string info)
        {
            MessageBoxEx.ShowInfo(info);
        }

        public void ShowException(Exception exception)
        {
            MessageBoxEx.ShowException(exception);
        }

        public void SetResultImages(Dictionary<string, ImageWrapper> resultImages)
        {
            cbResults.Enabled = true;
            cbResults.BindDictionary(resultImages);
        }

        public void SetSummary(string exampleName, double elapsedMilliseconds)
        {
            slSummary.Text = string.Format("Example: {0}, execution time: {1:0}ms", exampleName, elapsedMilliseconds);
        }

        private void cbImages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnExampleRun?.Invoke();
        }

        private void cbExamples_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnExampleRun?.Invoke();
        }

        private void cbResults_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SwitchImage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SwitchComboBoxItem(cbResults, -1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SwitchComboBoxItem(cbResults, 1);
        }

        private void miCurrentImage_Click(object sender, EventArgs e)
        {
            if (SelectedResultImage == null)
            {
                ShowNoImageInfo();
                return;
            }
                
            var sfd = new SaveFileDialog
            {
                Filter = "Bitmap Image (.bmp)|*.bmp",
                FileName = SelectedResultImageTitle
            };
            var dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
                OnCurrentImageSave?.Invoke(sfd.FileName);
        }

        private void miAllImages_Click(object sender, EventArgs e)
        {
            if (SelectedResultImage == null)
            {
                ShowInfo("No images created");
                return;
            }
                
            var fbd = new FolderBrowserDialog()
            {
                SelectedPath = Environment.SpecialFolder.DesktopDirectory.ToString()
            };
            var dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
                OnImagesSave?.Invoke(fbd.SelectedPath);
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
            SwitchImage();
        }

        private void SwitchImage()
        {
            var image = cbResults.SelectedValue as ImageWrapper;
            if (image != null)
                spbImage.Image = image.Bitmap;
        }

        private void ShowColorCalculator()
        {
            if (!ColorCalculatorEnabled)
                colorCalculatorView = new ColorCalculatorView();

            if (!colorCalculatorView.Visible)
                colorCalculatorView.ShowView(this);
            else
                colorCalculatorView.BringToFront();

            OnColorCalculatorShow?.Invoke(colorCalculatorView);
        }

        private void miMetrics_Click(object sender, EventArgs e)
        {
            if (SelectedResultImage == null)
            {
                ShowNoImageInfo();
                return;
            }

            OnMetricsShow?.Invoke();
        }

        private void miHistogram_Click(object sender, EventArgs e)
        {
            if (SelectedResultImage == null)
            {
                ShowNoImageInfo();
                return;
            }

            var histogramView = new HistogramView();
            OnHistogramShow?.Invoke(histogramView);
        }

        private void miColorCalculator_Click(object sender, EventArgs e)
        {
            ShowColorCalculator();
        }

        private void spbImage_OnMouseDoubleClick(int x, int y)
        {
            ShowColorCalculator();
            OnColorSelect?.Invoke(x, y);
        }

        private void spbImage_OnMouseClickOrMove(int x, int y)
        {
            if (!ColorCalculatorEnabled)
                return;

            OnColorSelect?.Invoke(x, y);
        }

        private void ShowNoImageInfo()
        {
            ShowInfo("No image created");
        }

        private void miClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image files (*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png"
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var filePath = ofd.FileName;
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var imageName = string.Empty;
            var enterForm = new EnterStringForm();
            if (enterForm.GetString("Enter image's name:", fileName, ref imageName) != DialogResult.OK)
                return;

            OnFileOpen?.Invoke(filePath, imageName);
        }
    }
}
