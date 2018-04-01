using ImageProcessingLib.Utilities;
using System.Drawing;

namespace ImageProcessingLib
{
    public class Image8 : ImageBase<byte>
    {
        #region Constructors

        public Image8(int width, int height)
        {
            SetSizes(width, height);
            data = JaggedArrayUtils.Create<byte>(width, height);
        }

        public Image8(Image8 img)
        {
            SetSizes(img.Width, img.Height);
            data = JaggedArrayUtils.Copy(img.Data);
        }

        public Image8(Image24 img)
        {
            //SetSizes(img.Width, img.Height);
            //data = RGBDataToBytes()
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
            var bmpData = BmpUtils.RGBValuesFrom(bmp);
            data = RGBDataToBytes(bmpData, width, height);
        }

        protected override Bitmap ToBitmap()
        {
            var bmpData = ByteDataToRGBValues(data, width, height);
            return BmpUtils.RGBValuesTo(bmpData, width, height);
        }

        #endregion

        #region Gets, sets and indexers


        #endregion

        #region Additionals

        public bool IsBlackAndWhite()
        {
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0;j < height;j++)
                {
                    var val = data[i][j];
                    if (val != 0 && val != 255)
                        return false;
                }
            }
            return true;
        }

        #endregion
    }
}
