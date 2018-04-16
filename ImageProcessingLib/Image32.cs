using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public class Image32 : Image<Pixel32>
    {
        public Image32(int width, int height) : base(width, height)
        {
        }

        public Image32(Image<Pixel32> img) : base(img)
        {
        }

        public void RemoveAlpha()
        {
            int len = Data.Length;
            ForEach((x, y) =>
            {
                var pixel = Get(x, y);
                Set(x, y, pixel.SetAlpha(255));
            });
        }
    }
}
