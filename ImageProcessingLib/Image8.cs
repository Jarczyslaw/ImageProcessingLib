using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
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

        private void ToGrayscale(Image24 img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    var rgb = img.Get(i, j);
                    var grayscale = MathUtils.RoundToByte(0.3d * rgb.R + 0.59d * rgb.G + 0.11d * rgb.B);
                    SetValue(i, j, grayscale);
                }
            }
        }

        public void Set(int x, int y, byte value)
        {
            SetValue(x, y, value);
        }

        public byte Get(int x, int y)
        {
            return GetValue(x, y).R;
        }

        public byte this[int x, int y]
        {
            get { return GetValue(x, y).R; }
            set { SetValue(x, y, value); }
        }
    }
}
