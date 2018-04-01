using ImageProcessingLib.Utilities;
using System.Drawing;

namespace ImageProcessingLib
{
    public class Image24 : ImageBase<RGBValue>
    {
        public readonly int bytesPerPixel = 3;

        #region Constructors

        public Image24(int width, int height)
        {
            SetSizes(width, height);
            data = JaggedArrayUtils.Create<RGBValue>(width, height);
        }

        public Image24(Image8 img)
        {
            SetSizes(img.Width, img.Height);
            data = ByteDataToRGBValues(img.Data, width, height);
        }

        public Image24(Image24 img)
        {
            SetSizes(img.Width, img.Height);
            data = JaggedArrayUtils.Copy(img.Data);
        }

        public Image24(Bitmap bmp)
        {
            FromBitmap(bmp);
        }

        public Image24(string filePath)
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
            data = BmpUtils.RGBValuesFrom(bmp);
        }

        protected override Bitmap ToBitmap()
        {
            return BmpUtils.RGBValuesTo(data, width, height);
        }

        #endregion

        #region Gets, sets and indexers

        #endregion

        #region Additionals

        public bool IsGrayscale()
        {
            for(int i = 0;i < width; i++)
            {
                for(int j = 0;j < height; j++)
                {
                    var p = data[i][j];
                    if (!p.IsInGrayscale())
                        return false;
                }
            }
            return true;
        }

        public bool IsBlackAndWhite()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var p = data[i][j];
                    if (!p.IsBlackOrWhite())
                        return false;
                }
            }
            return true;
        }

        #endregion
    }
}
