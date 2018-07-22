using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;
using Commons.Utils;
using ImageProcessingLib;
using ImageProcessingLib.Wrappers.WF;
using ImageProcessingLibToFIPComparison.Comparisons;

namespace ImageProcessingLibToFIPComparison
{
    public partial class MainForm : Form
    {
        private Bitmap sourceImage;
        private List<ImageWrapper> images;

        private string title = "ImageProcessingLibToFIPComparison";
        private string selectedComparisonName;

        public MainForm(Bitmap sourceImage)
        {
            this.sourceImage = sourceImage;

            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            PopulateComparisonsItems();
            tsslInfo.Text = string.Empty;
            ProgressBarState(false);
            Text = title;
        }

        private void PopulateComparisonsItems()
        {
            var comparisons = AssemblyUtils.GetTypesImplements<IComparison>()
                .OrderBy(t => t.Name).ToList();

            foreach (var comparison in comparisons)
            {
                var item = new ToolStripMenuItem()
                {
                    Tag = (IComparison)Activator.CreateInstance(comparison),
                    Text = comparison.Name
                };
                item.Click += Item_Click;
                tssdComparisons.DropDownItems.Add(item);
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var selectedMenuItem = sender as ToolStripMenuItem;
            selectedComparisonName = selectedMenuItem.Text;
            var comparison = selectedMenuItem.Tag as IComparison;
            RunComparison(comparison);
        }

        private async void RunComparison(IComparison comparison)
        {
            StartProcessing();
            await LoadResultsAsync(comparison);
            StopProcessing();
        }

        private void LoadResults(IComparison comparison)
        {
            try
            {
                DisposeImages();

                var fipOriginalImage = new ImageWrapper(sourceImage);
                var iplOriginalImage = new ImageWrapper(sourceImage);

                Bitmap fipBitmap = null;
                var fipTime = ExecTime.Run(() =>
                {
                    fipBitmap = comparison.GetFIPResults(new FIP.FIP(), fipOriginalImage.Bitmap);
                });
                var fipResult = new ImageWrapper(fipBitmap);

                Image<Pixel32> iplImage = null;
                var iplTime = ExecTime.Run(() =>
                {
                    iplImage = comparison.GetIPLResult(iplOriginalImage.Image32);
                });
                var iplResult = new ImageWrapper(iplImage);

                ThreadSafeInvoke.Invoke(this, () =>
                {
                    pbFIP.Image = fipResult.Bitmap;
                    pbIPL.Image = iplResult.Bitmap;

                    tsslInfo.Text = string.Format("MSE: {0:0.00}, IPL: {1:0}ms, FIP: {2:0}ms",
                        GetMetrics(fipResult.Image32, iplResult.Image32),
                        iplTime.TotalMilliseconds, fipTime.TotalMilliseconds);
                });
                
                images = new List<ImageWrapper>() { fipResult, iplResult, fipOriginalImage, iplOriginalImage };
            }
            catch (Exception e)
            {
                MessageBoxEx.ShowException(e);
            }
        }

        private double GetMetrics(Image<Pixel32> fipImage, Image<Pixel32> iplImage)
        {
            int margin = 2;
            int marginWidth = fipImage.Width - 2 * margin;
            int marginHeight = fipImage.Width - 2 * margin;
            return ErrorMetrics.MSE(fipImage, iplImage, margin, margin, marginWidth, marginHeight);
        }

        private async Task LoadResultsAsync(IComparison comparison)
        {
            await Task.Run(() => LoadResults(comparison));
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
            if (images != null)
            {
                foreach (var image in images)
                    image.Dispose();
            }
        }

        private void ProgressBarState(bool enabled)
        {
            tspbProgress.Enabled = enabled;
            tspbProgress.Visible = enabled;
        }

        private void StartProcessing()
        {
            Text = string.Format("{0}: {1}", title, selectedComparisonName);
            UnloadImages();
            Application.UseWaitCursor = true;
            ProgressBarState(true);
            tssdComparisons.Enabled = false;
        }

        private void StopProcessing()
        {
            Application.UseWaitCursor = false;
            ProgressBarState(false);
            tssdComparisons.Enabled = true;
        }
    }
}
