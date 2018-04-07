using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public class Image24 : ImageBase
    {
        public Image24(int width, int height)
        {
            CreateNew(width, height);
        }

        public Image24(Image8 img)
        {
            CreateFromExisting(img);
        }

        public Image24(Image24 img)
        {
            CreateFromExisting(img);
        }

        public Image24(Bitmap bmp)
        {
            CreateNew(bmp.Width, bmp.Height);
            GraphicsUtils.CopyTo(bmp, bitmap);
        }

        public void Set(int x, int y, byte value)
        {
            SetValue(x, y, value);
        }

        public void Set(int x, int y, RGBSet color)
        {
            SetValue(x, y, color);
        }

        public RGBSet Get(int x, int y)
        {
            return GetValue(x, y);
        }

        public RGBSet this[int x, int y]
        {
            get { return GetValue(x, y); }
            set { SetValue(x, y, value); }
        }
    }
}
