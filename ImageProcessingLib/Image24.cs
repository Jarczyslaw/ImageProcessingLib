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

        public void SetGrayscale(int x, int y, byte value)
        {
            SetValue(x, y, value);
        }

        public Color this[int x, int y]
        {
            get { return GetValue(x, y); }
            set { SetValue(x, y, value); }
        }
    }
}
