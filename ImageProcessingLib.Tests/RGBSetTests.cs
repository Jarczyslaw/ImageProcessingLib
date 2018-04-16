using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class RGBSetTests
    {
        [TestMethod]
        public void CreateNewFromRGB()
        {
            byte r = 123;
            byte g = 98;
            byte b = 40;
            var rgbSet = new Pixel32(r, g, b);
            var color = Color.FromArgb(r, g, b);
            // TODO
            // Assert.AreEqual(color.ToArgb(), rgbSet.Value);
        }

        [TestMethod]
        public void CreateFromGrayscale()
        {
            byte value = 128;
            var rgbSet = new Pixel32(value);
            var color = Color.FromArgb(value, value, value);
            //Assert.AreEqual(color.ToArgb(), rgbSet.Value);
        }

        [TestMethod]
        public void CreateFromValue()
        {
            byte r = 123;
            byte g = 98;
            byte b = 40;
            var color = Color.FromArgb(r, g, b);
            var rgbSet = new Pixel32(color.ToArgb());
            Assert.AreEqual(r, rgbSet.R);
            Assert.AreEqual(g, rgbSet.G);
            Assert.AreEqual(b, rgbSet.B);
        }
    }
}
