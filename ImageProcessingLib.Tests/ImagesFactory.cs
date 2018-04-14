using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib.Tests
{
    public class ImagesFactory
    {
        public static Image24 CreateSmallRGB()
        {
            var image24 = new Image24(3, 2);
            image24.Set(0, 0, RGBSet.Red);
            image24.Set(1, 0, RGBSet.Green);
            image24.Set(2, 0, RGBSet.Blue);
            image24.Set(0, 1, RGBSet.White);
            image24.Set(1, 1, RGBSet.FromValue(128));
            image24.Set(2, 1, RGBSet.Black);
            return image24;
        }
    }
}
