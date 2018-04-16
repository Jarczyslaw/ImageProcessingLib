using System.Runtime.CompilerServices;

namespace ImageProcessingLib
{
    public abstract class Image<TPixelType> : ImageBase
        where TPixelType : struct, IPixel<TPixelType>
    {
        protected TPixelType pixelSource = new TPixelType();

        public Image(int width, int height)
        {
            CreateNew(width, height);
            Clear();
        }

        public Image(Image<TPixelType> img)
        {
            CreateFromExisting(img);
        }

        public void Clear()
        {
            Clear(pixelSource.Blank);
        }

        public void Clear(TPixelType pixel)
        {
            int value = pixel.Data;
            int len = Data.Length;
            for (int i = 0; i < len; i++)
                Data[i] = value;
        }

        public void Set(int x, int y, TPixelType pixel)
        {
            int index = GetIndex(x, y);
            Data[index] = pixel.Data;
        }

        public TPixelType Get(int x, int y)
        {
            int index = GetIndex(x, y);
            return pixelSource.FromData(Data[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetIndex(int x, int y)
        {
            return x + y * Width;
        }

        public TPixelType this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }
    }
}
