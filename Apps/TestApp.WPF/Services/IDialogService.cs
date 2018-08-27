using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.WPF.Services
{
    public interface IDialogService
    {
        void ShowInformation(string message);
        void ShowException(Exception exception, string message);
        string SaveFile();
        string OpenFile();
    }
}
