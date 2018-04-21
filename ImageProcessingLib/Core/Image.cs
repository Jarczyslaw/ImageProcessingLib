using System;
using System.Runtime.CompilerServices;

namespace ImageProcessingLib
{
    public class Image<TPixelType> : ImageBase
        where TPixelType : struct, IPixel<TPixelType>
    {
        protected TPixelType pixelSource = new TPixelType();

        public Image(int width, int height, bool clear = true)
        {
            CreateNew(width, height);
            if (clear)
                this.Clear();
        }

        public Image(Image<TPixelType> img)
        {
            CreateFromExisting(img);
        }

        public Image<TNewPixelType> CopyAs<TNewPixelType>(Func<TPixelType, TNewPixelType> convertFunc)
            where TNewPixelType : struct, IPixel<TNewPixelType>
        {
            var result = new Image<TNewPixelType>(Width, Height);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var newValue = convertFunc(Get(j, i));
                    result.Set(j, i, newValue);
                }
            }
            return result;
        }

        public void Set(int x, int y, TPixelType pixel)
        {
            SetData(x, y, pixel.Data);
        }

        public TPixelType Get(int x, int y)
        {
            var data = GetData(x, y);
            return pixelSource.From(data);
        }

        public TPixelType this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }
    }
}
