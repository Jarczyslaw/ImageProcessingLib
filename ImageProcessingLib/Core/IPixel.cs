using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public interface IPixel<TPixelType>
    {
        int Data { get; }
        TPixelType FromData(int data);
        TPixelType Blank { get; }
    }
}
