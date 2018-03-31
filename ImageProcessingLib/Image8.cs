using System.Drawing;

namespace ImageProcessingLib
{
    public class Image8 : ImageBase
    {
        #region Constructors

        public Image8(int width, int height)
        {
            SetSizes(width, height);
            data = new byte[Size];
        }

        public Image8(Image8 img)
        {
            SetSizes(img.Width, img.Height);
            data = img.DataCopy();
        }

        public Image8(Image24 img)
        {
            SetSizes(img.Width, img.Height);
            data = Data24To8(img.Data);
        }

        public Image8(Bitmap bmp)
        {
            FromBitmap(bmp);
        }

        public Image8(string filePath)
        {
            using (var bmp = new Bitmap(filePath))
            {
                FromBitmap(bmp);
            }
        }

        #endregion

        #region ImageBase implementation

        protected override void FromBitmap(Bitmap bmp)
        {
            SetSizes(bmp.Width, bmp.Height);
            var bmpData = BmpMarshal.DataFromBmp(bmp);
            data = Data24To8(bmpData);
        }

        protected override Bitmap ToBitmap()
        {
            var bmpData = Data8To24(data);
            return BmpMarshal.DataToBmp(bmpData, width, height);
        }

        protected override int GetDataIndex(int x, int y)
        {
            return width * x + y;
        }

        #endregion

        #region Gets, sets and indexers

        public byte Get(int x, int y)
        {
            return data[GetDataIndex(x, y)];
        }

        public void Set(int x, int y, byte value)
        {
            data[GetDataIndex(x, y)] = value;
        }

        public byte this[int x, int y]
        {
            get { return Get(x, y); }
            set { Set(x, y, value); }
        }

        #endregion

        #region Additionals

        public bool IsBlackAndWhite()
        {
            int len = DataSize;
            for (int i = 0; i < len; i++)
            {
                if (data[i] != 0 && data[i] != 255)
                    return false;
            }
            return true;
        }

        #endregion
    }
}
