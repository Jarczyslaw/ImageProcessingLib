using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class CMYKTests
    {
        private void CMYKAssert(CMYK expected, CMYK current)
        {
            var tolerance = Math.Pow(1d, -3d);
            Assert.AreEqual(expected.C, current.C, tolerance);
            Assert.AreEqual(expected.M, current.M, tolerance);
            Assert.AreEqual(expected.Y, current.Y, tolerance);
            Assert.AreEqual(expected.K, current.K, tolerance);
        }

        [TestMethod]
        public void White()
        {
            var current = new CMYK(Pixel32.White);
            var expected = new CMYK(0d, 0d, 0d, 0d);
            CMYKAssert(expected, current);
        }

        [TestMethod]
        public void Black()
        {
            var current = new CMYK(Pixel32.Black);
            var expected = new CMYK(0d, 0d, 0d, 1d);
            CMYKAssert(expected, current);
        }

        [TestMethod]
        public void Pink()
        {
            var current = new CMYK(new Pixel32(240, 76, 255));
            var expected = new CMYK(0.66d, 0.7d, 0d, 0d);
            CMYKAssert(expected, current);
        }

        [TestMethod]
        public void Green()
        {
            var current = new CMYK(new Pixel32(100, 211, 109));
            var expected = new CMYK(0.53d, 0d, 0.48d, 0.17d);
            CMYKAssert(expected, current);
        }

        [TestMethod]
        public void Gold()
        {
            var current = new CMYK(new Pixel32(255, 211, 109));
            var expected = new CMYK(0d, 0.17d, 0.57d, 0d);
            CMYKAssert(expected, current);
        }
    }
}
