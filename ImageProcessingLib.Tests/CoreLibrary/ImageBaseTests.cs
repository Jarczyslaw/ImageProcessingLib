using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests.CoreLibrary
{
    [TestClass]
    public class ImageBaseTests
    {
        [TestMethod]
        public void ClearCheck()
        {
            var result = true;
            using (var image = ImagesFactory.CreateSmallRGB())
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
            using (var lena = ImagesLoader.LoadLenaTrans())
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
    }
}
