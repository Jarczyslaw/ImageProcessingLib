using System;
using ImagesFolder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class ImageBaseTests
    {
        [TestMethod]
        public void ClearCheck()
        {
            var result = true;
            /*using (var image = CreateSmallRGB())
            {
                image.Clear();
                var blackValue = Pixel32.Black.Value;
                foreach (var pixel in image.Data)
                {
                    if (pixel != blackValue)
                    {
                        result = false;
                        break;
                    }
                }
            }*/
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveAlphaCheck()
        {
            var result = true;
            using (var lena = Images.LenaTrans)
            {
                // TODO
                /*using (var image = new Image24(lena))
                {
                    foreach(var pixel in image.Data)
                    {
                        if ((pixel >> 24 & 0xFF) != 0xFF)
                        {
                            result = false;
                            break;
                        }
                    }
                }*/
            }
            Assert.IsTrue(result);
        }

        private Image32 CreateSmallRGB()
        {
            var image = new Image32(3, 2);
            image.Set(0, 0, Pixel32.Red);
            image.Set(1, 0, Pixel32.Green);
            image.Set(2, 0, Pixel32.Blue);
            image.Set(0, 1, Pixel32.White);
            image.Set(1, 1, new Pixel32(128));
            image.Set(2, 1, Pixel32.Black);
            return image;
        }
    }
}
