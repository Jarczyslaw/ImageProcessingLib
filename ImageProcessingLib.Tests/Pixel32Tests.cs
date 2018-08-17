using System;
using System.Drawing;
using ImageProcessingLib.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class Pixel32Tests
    {
        [TestMethod]
        public void CreateNewFromRGB()
        {
            byte r = 123;
            byte g = 98;
            byte b = 40;
            var pixel = new Pixel32(r, g, b);
            var color = Color.FromArgb(r, g, b);
            Assert.AreEqual(color.ToArgb(), BytesUtils.GetDataFromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
        }

        [TestMethod]
        public void CreateFromGrayscale()
        {
            byte value = 128;
            var pixel = new Pixel32(value);
            var color = Color.FromArgb(value, value, value);
            Assert.AreEqual(color.ToArgb(), BytesUtils.GetDataFromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
        }

        [TestMethod]
        public void ToHexString()
        {
            var pixel = new Pixel32(255, 130, 209, 255);
            Assert.AreEqual("FF82D1FF", pixel.ToHex());
        }

        [TestMethod]
        public void FromHexString()
        {
            var pixel = Pixel32.FromHex("FF78715D");
            Assert.AreEqual(255, pixel.A);
            Assert.AreEqual(120, pixel.R);
            Assert.AreEqual(113, pixel.G);
            Assert.AreEqual(93, pixel.B);
        }
    }
}
