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
using ImageProcessingLib;
using ImageProcessingLib.GDI;
using IPLvsFIP.Comparisons;

namespace IPLvsFIP
{
    public partial class MainForm : Form
    {
        private Bitmap sourceImage;
        private List<GDImage32> images;

        private string title = "IPL vs FIP";
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
                    Text = comparison.Name.Replace("Comparison", string.Empty),
                    Tag = (IComparison)Activator.CreateInstance(comparison)
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

                var originalImage1 = new GDImage32(sourceImage);
                var originalImage2 = new GDImage32(sourceImage);

                Bitmap fipBitmap = null;
                var fipTime = ExecTime.Run(() =>
                {
                    fipBitmap = comparison.GetFIPResults(new FIP.FIP(), originalImage1.Bitmap);
                });
                var fipResult = new GDImage32(fipBitmap);

                Image<Pixel32> iplImage = null;
                var iplTime = ExecTime.Run(() =>
                {
                    iplImage = comparison.GetIPLResult(originalImage2.Image);
                });
                var iplResult = new GDImage32(iplImage);

                pbFIP.Image = fipResult.Bitmap;
                pbIPL.Image = iplResult.Bitmap;

                tsslInfo.Text = string.Format("MSE: {0:0.00}, IPL: {1:0}ms, FIP: {2:0}ms",
                    GetMetrics(fipResult.Image, iplResult.Image),
                    iplTime.TotalMilliseconds, fipTime.TotalMilliseconds);

                images = new List<GDImage32>() { fipResult, iplResult, originalImage1, originalImage2 };
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
