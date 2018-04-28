using System;
using System.Runtime.CompilerServices;

namespace ImageProcessingLib
{
    public class Image<TPixelType> : ImageBase
        where TPixelType : struct, IPixel<TPixelType>
    {
        public event ResizeHandler OnResize;

        protected TPixelType pixelSource = new TPixelType();

        public Image(int width, int height, bool clear = true)
        {
            InitializeNew(width, height);
            if (clear)
                this.Clear();
        }

        public Image(Image<TPixelType> img)
        {
            InitializeFrom(img);
        }

        public Image<TNewPixelType> CopyAs<TNewPixelType>(CopyHandler<TPixelType, TNewPixelType> convertFunc)
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

        public void InvokeResize()
        {
            OnResize?.Invoke();
        }

        public TPixelType this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }

        public override string ToString()
        {
            return string.Format("Image<{0}> {1}x{2}", nameof(TPixelType), Width, Height);
        }
    }
}
