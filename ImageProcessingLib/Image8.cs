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
                    var color = img[i, j];
                    var grayscale = (byte)(0.3d * color.R + 0.59d * color.G + 0.11d * color.B);
                    SetValue(i, j, grayscale);
                }
            }
        }

        public byte this[int x, int y]
        {
            get { return GetValue(x, y).G; }
            set { SetValue(x, y, value); }
        }
    }
}
