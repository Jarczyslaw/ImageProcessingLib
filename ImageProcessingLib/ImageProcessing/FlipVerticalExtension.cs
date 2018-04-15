using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.ImageProcessing
{
    public static class FlipVerticalExtension
    {
        public static Image8 FlipHorizontal(this Image8 image)
        {
            Flip(image);
            return image;
        }

        public static Image8 FlipVertical(this Image8 image)
        {
            Flip(image);
            return image;
        }

        private static void Flip(ImageBase image)
        {
            int width = image.Width;
            int height = image.Height;
            int halfWidth = image.Width / 2;
            for (int i = 0; i < halfWidth; i++)
            {
                var tempWidth = image.Width - i - 1;
                for (int j = 0; j < height; j++)
                    image.Swap(i, j, tempWidth, j); 
            }
        }
    }
}
