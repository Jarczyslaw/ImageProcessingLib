using Commons.Utils;
using ImageProcessingLib;
using ImageProcessingLib.Converter.WF;
using ImageProcessingLibToFIPComparison.Comparisons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibToFIPComparison
{
    public partial class MainForm : Form
    {
        private List<Bitmap> createdBitmaps;

        private string title = "ImageProcessingLibToFIPComparison";

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            PopulateComparisonsItems();
            PopulateImagesItems();
            tsslInfo.Text = string.Empty;
            ProgressBarState(false);
            Text = title;
        }

        private void PopulateComparisonsItems()
        {
            var comparisons = AssemblyUtils.GetTypesImplements<IComparison>()
                .OrderBy(t => t.Name).ToList();
            var dict = new Dictionary<string, IComparison>();
            foreach (var comparison in comparisons)
                dict.Add(comparison.Name, (IComparison)Activator.CreateInstance(comparison));

            tscbComparisons.ComboBox.BindDictionary(dict);
            tscbComparisons.ComboBox.SelectedIndex = -1;
        }

        private void PopulateImagesItems()
        {
            var images = ImagesFolder.Images.AllBitmaps;
            tscbImages.ComboBox.BindDictionary(images);
            tscbImages.ComboBox.SelectedIndex = -1;
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            var selectedImage = tscbImages.ComboBox.SelectedValue as Bitmap;
            if (selectedImage == null)
                return;

            if (tscbComparisons.ComboBox.SelectedValue == null)
                return;

            var selectedComparison = (KeyValuePair<string, IComparison>)tscbComparisons.ComboBox.SelectedItem;
            RunComparison(selectedImage, selectedComparison.Value, selectedComparison.Key);
        }

        private async void RunComparison(Bitmap image, IComparison comparison, string comparisonName)
        {
            StartProcessing(comparisonName);
            await LoadResultsAsync(image, comparison);
            StopProcessing();
        }

        private void LoadResults(Bitmap bitmap, IComparison comparison)
        {
            try
            {
                DisposeImages();

                var originalBitmap = bitmap;
                var originalImage = IPLConverter.CreateImageFromBitmap(originalBitmap);

                Bitmap fipBitmap = null;
                var fipTime = ExecTime.Run(() =>
                {
                    fipBitmap = comparison.GetFIPResults(new FIP.FIP(), originalBitmap);
                });
                var fipImage = IPLConverter.CreateImageFromBitmap(fipBitmap);

                Image<Pixel32> iplImage = null;
                var iplTime = ExecTime.Run(() =>
                {
                    iplImage = comparison.GetIPLResult(originalImage);
                });
                var iplBitmap = IPLConverter.CreateBitmapFromImage(iplImage);

                ThreadSafeInvoke.Invoke(this, () =>
                {
                    pbFIP.Image = fipBitmap;
                    pbIPL.Image = iplBitmap;

                    tsslInfo.Text = string.Format("MSE: {0:0.00}, IPL: {1:0}ms, FIP: {2:0}ms",
                        GetMetrics(fipImage, iplImage),
                        iplTime.TotalMilliseconds, fipTime.TotalMilliseconds);
                });

                createdBitmaps = new List<Bitmap>() { fipBitmap, iplBitmap };
            }
            catch (Exception e)
            {
                MessageBoxEx.ShowException(e);
            }
        }

        private double GetMetrics(Image<Pixel32> fipImage, Image<Pixel32> iplImage)
        {
            if (fipImage.Width != iplImage.Width || fipImage.Height != iplImage.Height)
                throw new Exception("Result images have different size. Something went really wrong");

            int margin = 2;
            int marginWidth = fipImage.Width - 2 * margin;
            int marginHeight = fipImage.Height - 2 * margin;
            return ErrorMetrics.MSE(fipImage, iplImage, margin, margin, marginWidth, marginHeight);
        }

        private async Task LoadResultsAsync(Bitmap image, IComparison comparison)
        {
            await Task.Run(() => LoadResults(image, comparison));
        }

        private void UnloadImages()
        {
            pbFIP.Image = null;
            pbIPL.Image = null;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeImages();
        }

        private void DisposeImages()
        {
            if (createdBitmaps != null)
            {
                foreach (var bitmap in createdBitmaps)
                    bitmap.Dispose();
                createdBitmaps.Clear();
            }
        }

        private void ProgressBarState(bool enabled)
        {
            tspbProgress.Enabled = enabled;
            tspbProgress.Visible = enabled;
        }

        private void StartProcessing(string selectedComparisonName)
        {
            Text = string.Format("{0}: {1}", title, selectedComparisonName);
            UnloadImages();
            SetProcessingControlsState(true);
            tsslInfo.Text = string.Empty;
        }

        private void StopProcessing()
        {
            SetProcessingControlsState(false);
        }

        private void SetProcessingControlsState(bool processing)
        {
            Application.UseWaitCursor = processing;
            ProgressBarState(processing);
            tscbComparisons.Enabled = !processing;
            tscbImages.Enabled = !processing;
            tsbRun.Enabled = !processing;
        }
    }
}
