using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples
{
    public interface IImagesSource : IDisposable
    {
        Dictionary<string, Bitmap> Images { get; }
        void AddImage(string title, Bitmap image);
    }
}
