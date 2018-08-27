using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace TestApp.WPF.Services
{
    public class DialogService : IDialogService
    {
        public string OpenFile()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = "Bitmap images (.bmp)|*.bmp"
            };
            var dr = ofd.ShowDialog();
            return (dr == true) ? ofd.FileName : null;
        }

        public string SaveFile()
        {
            var sfd = new SaveFileDialog
            {
                FileName = "image",
                DefaultExt = ".bmp",
                Filter = "Bitmap images (.bmp)|*.bmp"
            };
            var dr = sfd.ShowDialog();
            return (dr == true) ? sfd.FileName : null;
        }

        public void ShowException(Exception exception, string message)
        {
            MessageBox.Show(message + Environment.NewLine + exception.Message, "Exception");
        }

        public void ShowInformation(string message)
        {
            MessageBox.Show(message, "Information");
        }
    }
}
