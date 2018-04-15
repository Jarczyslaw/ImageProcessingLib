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
            using (var image = CreateSmallRGB())
            {
                image.Clear();
                var blackValue = RGBSet.Black.Value;
                foreach (var pixel in image.Data)
                {
                    if (pixel != blackValue)
                    {
                        result = false;
                        break;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveAlphaCheck()
        {
            var result = true;
            using (var lena = Images.LenaTrans)
            {
                using (var image = new Image24(lena))
                {
                    foreach(var pixel in image.Data)
                    {
                        if ((pixel >> 24 & 0xFF) != 0xFF)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            Assert.IsTrue(result);
        }

        private Image24 CreateSmallRGB()
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
