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
            Clear();
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

        public Image<TPixelType> ForEach(Action<int, int> action)
        {
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    action(j, i);
            return this;
        }

        public Image<TPixelType> ForEach(Action<int, int, TPixelType> action)
        {
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    action(j, i, Get(j, i));
            return this;
        }

        public Image<TPixelType> ForEach(Func<int, int, TPixelType, TPixelType> action)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var newPixel = action(j, i, Get(j, i));
                    Set(j, i, newPixel);
                }
            }
            return this;
        }

        public Image<TPixelType> ForSegment(int segment, int segmentsCount, Action<int, int> action)
        {
            float len = (float)Height / segmentsCount;
            int start = (int)Math.Round(segment * len);
            int end = (int)Math.Round((segment + 1) * len);
            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < Width; j++)
                    action(j, i);
            }
            return this;
        }

        public Image<TPixelType> Clear()
        {
            Clear(pixelSource.Blank);
            return this;
        }

        public Image<TPixelType> Clear(TPixelType pixel)
        {
            int value = pixel.Data;
            int len = Data.Length;
            for (int i = 0; i < len; i++)
                Data[i] = value;
            return this;
        }

        public void Set(int x, int y, TPixelType pixel)
        {
            SetData(x, y, pixel.Data);
        }

        public TPixelType Get(int x, int y)
        {
            var data = GetData(x, y);
            return pixelSource.FromData(data);
        }

        public TPixelType this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }
    }
}
