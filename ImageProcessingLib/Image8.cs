using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public class Image8 : ImageBase
    {
        public Image8(int width, int height)
        {
            CreateNew(width, height);
            Clear();
        }

        public Image8(Image8 img)
        {
            CreateFromExisting(img);
        }

        public Image8(Image24 img)
        {
            CreateNew(img.Width, img.Height);
            ToGrayscale(img);
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

        private void FromBitmap(Bitmap bmp)
        {
            CreateNew(bmp.Width, bmp.Height);
            GraphicsUtils.Copy(bmp, Bitmap);
            ToGrayscale(this);
        }

        private void ToGrayscale(ImageBase img)
        {
            var len = img.Size;
            for (int i = 0; i < len; i++)
            {
                var rgb = RGBSet.FromValue(img.Data[i]);
                data[i] = rgb.ToGrayscale().Value;
            }
        }

        public void Set(int x, int y, byte value)
        {
            SetValue(x, y, value);
        }

        public byte Get(int x, int y)
        {
            return GetValue(x, y).B;
        }

        public byte this[int x, int y]
        {
            get { return GetValue(x, y).B; }
            set { SetValue(x, y, value); }
        }
    }
}
