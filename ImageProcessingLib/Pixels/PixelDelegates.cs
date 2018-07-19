using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public delegate TPixelType PixelOperator<TPixelType>(TPixelType pixel);
    public delegate TNewPixelType PixelConverter<TOldPixelType, TNewPixelType>(TOldPixelType pixel);
}
