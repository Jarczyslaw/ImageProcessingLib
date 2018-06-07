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
using IPTvsFIP.ResultSources;

namespace IPTvsFIP
{
    public partial class MainForm : Form
    {
        private IResultSource result = new EmptyResult();

        public MainForm()
        {
            InitializeComponent();
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
                var originalImage = ImagesFolder.Images.Lena;
                var originalGDIImage = new GDImage32(originalImage);

                var fipImg = new GDImage32(result.GetFIPResults(originalImage));
                var iptImg = new GDImage32(result.GetIPTResult(originalGDIImage.Image));

                pbFIP.Image = fipImg.Bitmap;
                pbIPT.Image = iptImg.Bitmap;

                tsslInfo.Text = string.Format("MSE: {0:0.00}", ErrorMetrics.MSE(fipImg.Image, iptImg.Image));

                fipImg.Dispose();
                iptImg.Dispose();
                originalGDIImage.Dispose();
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
    }
}
