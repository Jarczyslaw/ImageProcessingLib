using Commons.Utils;
using ImageProcessingLib;
using ImageProcessingLibExamples.Examples;
using ImageProcessingLibExamples.Views;
using ImagesFolder;
using System;
using System.Collections.Generic;
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

        private Dictionary<string, ExampleBase> examples;
        private ExampleBase currentExample;
        private Bitmap currentImage;

        public MainPresenter(IMainView view, IExamplesSource examplesSource)
        {
            this.view = view;

            view.OnExampleRun += ExampleRun;
            view.OnClose += OnClose;

            view.OnCurrentImageSave += CurrentImageSave;
            view.OnImagesSave += ImagesSave;
            view.OnMetricsShow += MetricsShow;

            view.SetImages(Images.AllBitmaps);
            examples = examplesSource.CreateExamplesDictionary();
            view.SetExamples(examples);
        }

        private async void MetricsShow()
        {
            if (currentExample == null || view.SelectedResultImage == null)
                return;

            try
            {
                var originalImage = currentExample.OriginalImage.Image;
                var resultImage = view.SelectedResultImage.Image;

                view.IsBusy = true;
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
                catch(Exception e)
                {
                    view.ShowException(e);
                }
                finally
                {
                    view.IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                view.ShowException(ex);
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

        private void OnClose()
        {
            currentExample?.CleanUp();
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

            view.IsBusy = true;
            await LaunchExample(currentImage, currentExample);
            view.IsBusy = false;
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
