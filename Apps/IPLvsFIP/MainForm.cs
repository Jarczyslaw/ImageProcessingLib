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
using IPLvsFIP.ResultSources;

namespace IPLvsFIP
{
    public partial class MainForm : Form
    {
        private IResultSource result = new LaplaceFilterResult();

        private List<GDImage32> images;

        public MainForm()
        {
            InitializeComponent();
            Text = "IPL vs FIP: " + result.GetType().Name.Replace("Result", string.Empty);
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
                var sourceImage = ImagesFolder.Images.Lena;
                var originalImage1 = new GDImage32(sourceImage);
                var originalImage2 = new GDImage32(sourceImage);

                var fipImg = new GDImage32(result.GetFIPResults(new FIP.FIP(), originalImage1.Bitmap));
                var iplImg = new GDImage32(result.GetIPLResult(originalImage2.Image));

                pbFIP.Image = fipImg.Bitmap;
                pbIPL.Image = iplImg.Bitmap;

                tsslInfo.Text = string.Format("MSE: {0:0.00}", ErrorMetrics.MSE(fipImg.Image, iplImg.Image));

                images = new List<GDImage32>() { fipImg, iplImg, originalImage1, originalImage2 };
            }
            catch (Exception e)
            {
                MessageBoxEx.ShowException(e);
            }
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
