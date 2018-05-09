using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public delegate void ResizeHandler();
    public delegate TNewPixelType CopyHandler<TOldPixelType, TNewPixelType>(TOldPixelType pixel);
    public delegate void ForHandler(int x, int y);
    public delegate void ForNeighbourhoodHandler<TPixelType>(int x, int y, TPixelType[] neighbourhood);
}
