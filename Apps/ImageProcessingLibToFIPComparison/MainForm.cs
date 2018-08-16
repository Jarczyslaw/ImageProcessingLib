﻿using System;
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
        private List<ImageWrapper> images;

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

        private void LoadResults(Bitmap image, IComparison comparison)
        {
            try
            {
                DisposeImages();

                var fipOriginalImage = new ImageWrapper(image);
                var iplOriginalImage = new ImageWrapper(image);

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

        private void StartProcessing(string selectedComparisonName)
        {
            Text = string.Format("{0}: {1}", title, selectedComparisonName);
            UnloadImages();
            Application.UseWaitCursor = true;
            ProgressBarState(true);
            tssdComparisons.Enabled = false;
            tsslInfo.Text = string.Empty;
        }

        private void StopProcessing()
        {
            Application.UseWaitCursor = false;
            ProgressBarState(false);
            tssdComparisons.Enabled = true;
        }
    }
}
