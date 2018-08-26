using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageProcessingLib.Converter.WPF;
using Microsoft.Win32;

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TestWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BitmapSource imageSource;
        public BitmapSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged(nameof(ImageSource));
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

        public TestWindow() : this(null) { }

        public TestWindow(BitmapSource bitmap)
        {
            ImageSource = bitmap;
            DataContext = this;
        }

        private void LoadFile()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = "Bitmap images (.bmp)|*.bmp"
            };

            var result = ofd.ShowDialog();
            if (result == true)
            {
                try
                {
                    var bitmap = CreateBitmapSourceFromFile(ofd.FileName);
                    var image = ImageProcessingLibConverter.CreateImageFromBitmap(bitmap);
                    var targetBitmap = ImageProcessingLibConverter.CreateBitmapFromImage(image);
                    ImageSource = targetBitmap;
                    MessageBox.Show("Image loaded", "Information");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can not load file: " + e.Message, "Exception");
                }
            }
        }

        private void SaveFile()
        {
            var sfd = new SaveFileDialog
            {
                FileName = "image",
                DefaultExt = ".bmp",
                Filter = "Bitmap images (.bmp)|*.bmp"
            };

            var result = sfd.ShowDialog();
            if (result == true)
            {
                try
                {
                    ToFile(sfd.FileName);
                    MessageBox.Show("Image saved", "Information");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can not save file: " + e.Message, "Exception");
                }
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
            encoder.Frames.Add(BitmapFrame.Create(ImageSource));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                encoder.Save(fileStream);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
