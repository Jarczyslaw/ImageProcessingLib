﻿using Commons.Utils;
using ImageProcessingLib;
using ImageProcessingLibExamples.Examples;
using ImageProcessingLibExamples.Views;
using ImagesFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples.Presenters
{
    public class MainPresenter
    {
        private IMainView view;
        private IImagesSource imagesSource;
        private IExamplesSource examplesSource;

        private Dictionary<string, ExampleBase> examples;
        private ExampleBase currentExample;
        private Bitmap currentImage;

        private HistogramPresenter histogramPresenter;
        private ColorCalculatorPresenter colorCalculatorPresenter;

        public MainPresenter(IMainView view, IImagesSource imagesSource, IExamplesSource examplesSource)
        {
            this.view = view;
            this.imagesSource = imagesSource;
            this.examplesSource = examplesSource;

            histogramPresenter = new HistogramPresenter(view);
            colorCalculatorPresenter = new ColorCalculatorPresenter(view);

            view.OnExampleRun += ExampleRun;
            view.OnViewClosing += ViewClosing;

            view.OnCurrentImageSave += CurrentImageSave;
            view.OnImagesSave += ImagesSave;
            view.OnFileOpen += FileOpen;
            view.OnMetricsShow += MetricsShow;
            view.OnHistogramShow += HistogramShow;
            view.OnColorCalculatorShow += ColorCalculatorShow;
            view.OnColorSelect += ColorSelect;

            view.SetImages(imagesSource.Images);
            examples = examplesSource.CreateExamplesDictionary();
            view.SetExamples(examples);
        }

        private void ColorSelect(int x, int y)
        {
            if (colorCalculatorPresenter == null)
                return;

            if (view.SelectedResultImage == null)
                return;

            var image = view.SelectedResultImage.Image;
            var pixel = image.Get(x, y);
            colorCalculatorPresenter.UpdateColor(x, y, pixel);
        }

        private void ColorCalculatorShow(IColorCalculatorView colorCalculatorView)
        {
            colorCalculatorPresenter.ShowView(colorCalculatorView, true);
        }

        private void HistogramShow(IHistogramView histogramView)
        {
            var image = view.SelectedResultImage;
            if (image == null)
            {
                view.ShowInfo("No image selected");
                return;
            }

            histogramPresenter.ShowHistogram(histogramView, image.Image, view.SelectedResultImageTitle);
        }

        private void MetricsShow()
        {
            if (currentExample == null || view.SelectedResultImage == null)
                return;

            var originalImage = currentExample.OriginalImage.Image;
            var resultImage = view.SelectedResultImage.Image;

            LaunchMetrics(originalImage, resultImage);
        }

        private async void LaunchMetrics(Image<Pixel32> originalImage, Image<Pixel32> resultImage)
        {
            view.Busy = true;
            try
            {
                var result = await Task.Run(() =>
                {
                    var mse = ErrorMetrics.MSE(originalImage, resultImage);
                    var psnr = ErrorMetrics.PSNR(originalImage, resultImage);
                    return Tuple.Create(mse, psnr);
                });
                view.ShowMetrics(result.Item1, result.Item2);
            }
            catch (Exception e)
            {
                view.ShowException(e);
            }
            finally
            {
                view.Busy = false;
            }
        }

        private void ImagesSave(string selectedPath)
        {
            if (currentExample == null)
                return;
 
            try
            {
                currentExample.Save(selectedPath);
                view.AllImagesSaveInfo(currentExample.Images.Count, selectedPath);
            }
            catch (Exception ex)
            {
                view.ShowException(ex);
            }
        }

        private void CurrentImageSave(string fileName)
        {
            if (view.SelectedResultImage == null)
                return;
            
            try
            {
                view.SelectedResultImage.Bitmap.Save(fileName, ImageFormat.Bmp);
                view.CurrentImageSaveInfo(fileName);
            }
            catch (Exception ex)
            {
                view.ShowException(ex);
            }
        }

        private void FileOpen(string fileName, string imageName)
        {
            try
            {
                var newImage = new Bitmap(fileName);
                imagesSource.AddImage(imageName, newImage);
                view.SetImages(imagesSource.Images);
            }
            catch (Exception exc)
            {
                view.ShowException(exc);
            }
        }

        private bool ViewClosing()
        {
            currentExample?.CleanUp();
            imagesSource?.Dispose();
            return false;
        }

        private async void ExampleRun()
        {
            if (view.SelectedExample == null || view.SelectedSourceImage == null)
                return;

            if (view.SelectedExample == currentExample && view.SelectedSourceImage == currentImage)
                return;

            view.SelectedResultImage = null;
            currentExample?.CleanUp();
            currentExample = view.SelectedExample;
            currentImage = view.SelectedSourceImage;

            view.Busy = true;
            await LaunchExample(currentImage, currentExample);
            view.Busy = false;
        }

        private async Task LaunchExample(Bitmap bmp, ExampleBase example)
        {
            try
            {
                TimeSpan initializationTime = TimeSpan.Zero;
                await Task.Run(() =>
                {
                    initializationTime = ExecTime.Run(() => example.ApplyExample(bmp));
                });
                view.SetResultImages(example.Images);
                view.SelectedResultImage = example.OriginalImage;
                view.SetSummary(example.GetType().Name, initializationTime.TotalMilliseconds);
            }
            catch (Exception exc)
            {
                view.ShowException(exc);
            }
        }
    }
}
