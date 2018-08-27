using ImageProcessingLib.Converter.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TestApp.WPF.Services;

namespace TestApp.WPF
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BitmapSource image;
        public BitmapSource Image
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        public ICommand loadFileCommand;
        public ICommand LoadFileCommand
        {
            get
            {
                if (loadFileCommand == null)
                    loadFileCommand = new Command(LoadFile);
                return loadFileCommand;
            }
        }

        public ICommand saveFileCommand;
        public ICommand SaveFileCommand
        {
            get
            {
                if (saveFileCommand == null)
                    saveFileCommand = new Command(SaveFile);
                return saveFileCommand;
            }
        }

        private IDialogService dialogService;

        public TestViewModel(BitmapSource bitmap, IDialogService dialogService)
        {
            Image = bitmap;
            this.dialogService = dialogService;
        }

        private void LoadFile()
        {
            var filePath = dialogService.OpenFile();
            if (string.IsNullOrEmpty(filePath))
                return;

            try
            {
                var bitmap = CreateBitmapSourceFromFile(filePath);
                var image = ImageProcessingLibConverter.CreateImageFromBitmap(bitmap);
                var targetBitmap = ImageProcessingLibConverter.CreateBitmapFromImage(image);
                Image = targetBitmap;
                dialogService.ShowInformation("Image loaded");
            }
            catch (Exception e)
            {
                dialogService.ShowException(e, "Can not load file: ");
            }
        }

        private void SaveFile()
        {
            var filePath = dialogService.SaveFile();
            if (string.IsNullOrEmpty(filePath))
                return;

            try
            {
                ToFile(filePath);
                dialogService.ShowInformation("Image saved");
            }
            catch (Exception e)
            {
                dialogService.ShowException(e, "Can not save file: ");
            }
        }

        private BitmapSource CreateBitmapSourceFromFile(string filePath)
        {
            var bitmapImage = new BitmapImage(new Uri(filePath));
            var result = new FormatConvertedBitmap();
            result.BeginInit();
            result.Source = bitmapImage;
            result.DestinationFormat = PixelFormats.Bgra32;
            result.EndInit();
            return result;
        }

        public void ToFile(string filePath)
        {
            var encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Image));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                encoder.Save(fileStream);
        }
    }
}
