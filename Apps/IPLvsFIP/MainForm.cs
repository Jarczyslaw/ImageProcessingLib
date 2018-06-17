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
        private IComparison comparison;
        private Bitmap sourceImage;
        private List<GDImage32> images;

        public MainForm(Bitmap sourceImage, IComparison comparison)
        {
            this.sourceImage = sourceImage;
            this.comparison = comparison;

            InitializeComponent();
            Text = "IPL vs FIP: " + comparison.GetType().Name.Replace("Comparison", string.Empty);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            await LoadResultsAsync();
            Application.UseWaitCursor = false;
        }

        private void LoadResults()
        {
            try
            {
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

        private async Task LoadResultsAsync()
        {
            await Task.Run(() => LoadResults());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (images != null)
            {
                foreach (var image in images)
                    image.Dispose();
            }
        }
    }
}
