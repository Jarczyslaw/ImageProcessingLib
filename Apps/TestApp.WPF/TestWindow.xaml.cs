using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using ImageProcessingLib.Wrappers.WPF;
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

        private ImageWrapper imageWrapper;

        public TestWindow() : this(null) { }

        public TestWindow(ImageWrapper imageWrapper)
        {
            InitializeComponent();
            this.imageWrapper = imageWrapper;
            if (imageWrapper != null)
                ImageSource = imageWrapper.BitmapSource;
            DataContext = this;
        }

        private void LoadFile()
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ofd.Filter = "Bitmap images (.bmp)|*.bmp";

            var result = ofd.ShowDialog();
            if (result == true)
            {
                try
                {
                    var tempWrapper = new ImageWrapper(ofd.FileName);
                    imageWrapper = new ImageWrapper(tempWrapper.Image32);
                    ImageSource = imageWrapper.BitmapSource;
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
            if (imageWrapper == null)
                return;

            var sfd = new SaveFileDialog();
            sfd.FileName = "image";
            sfd.DefaultExt = ".bmp";
            sfd.Filter = "Bitmap images (.bmp)|*.bmp";

            var result = sfd.ShowDialog();
            if (result == true)
            {
                try
                {
                    imageWrapper.ToFile(sfd.FileName);
                    MessageBox.Show("Image saved", "Information");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can not save file: " + e.Message, "Exception");
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
