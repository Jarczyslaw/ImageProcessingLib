using System;
using System.Runtime.CompilerServices;

namespace ImageProcessingLib
{
    public class Image<TPixelType> : ImageBase
        where TPixelType : struct, IPixel<TPixelType>
    {
        private event ResizeHandler onResize;
        public event ResizeHandler OnResize
        {
            add { onResize += value; }
            remove { onResize -= value; }
        }

        protected TPixelType pixelSource = new TPixelType();

        public Image(int width, int height)
        {
            InitializeNew(width, height);
        }

        public Image(int width, int height, TPixelType clearPixel)
        {
            InitializeNew(width, height);
            ClearExtension.Clear(this, clearPixel);
        }

        public Image(Image<TPixelType> img)
        {
            InitializeFrom(img);
        }

        public Image<TNewPixelType> CopyAs<TNewPixelType>(PixelConverter<TPixelType, TNewPixelType> converter)
            where TNewPixelType : struct, IPixel<TNewPixelType>
        {
            var result = new Image<TNewPixelType>(Width, Height);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var newValue = converter(Get(j, i));
                    result.Set(j, i, newValue);
                }
            }
            return result;
        }

        public Image<TPixelType> Copy()
        {
            return new Image<TPixelType>(this);
        }

        public void Set(int i, TPixelType pixel)
        {
            SetData(i, pixel.Data);
        }

        public void Set(int x, int y, TPixelType pixel)
        {
            SetData(x, y, pixel.Data);
        }

        public TPixelType Get(int i)
        {
            var data = GetData(i);
            return pixelSource.From(data);
        }

        public TPixelType Get(int x, int y)
        {
            var data = GetData(x, y);
            return pixelSource.From(data);
        }

        public TPixelType[] GetNeighbourhood(int x, int y, int range)
        {
            var size = 1 + 2 * range;
            var result = new TPixelType[size * size];

            var startX = x - range;
            var endX = x + range;
            var startY = y - range;
            var endY = y + range;
            int index = 0;
            for (int i = startY; i <= endY; i++)
                for (int j = startX; j <= endX; j++)
                    result[index++] = Get(ClampWidth(j), ClampHeight(i));
            return result;
        }

        public void InvokeResize()
        {
            onResize?.Invoke();
        }

        public TPixelType this[int i]
        {
            get { return Get(i); }
            set { Set(i, value); }
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
