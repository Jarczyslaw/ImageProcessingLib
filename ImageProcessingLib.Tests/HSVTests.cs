using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class HSVTests
    {
        private void HSVAssert(HSV expected, HSV current)
        {
            var tolerance = Math.Pow(1d, -3d);
            Assert.AreEqual(expected.H, current.H, tolerance);
            Assert.AreEqual(expected.S, current.S, tolerance);
            Assert.AreEqual(expected.V, current.V, tolerance);
        }

        [TestMethod]
        public void White()
        {
            var current = new HSV(Pixel32.White);
            var expected = new HSV(0d, 0d, 100d);
            HSVAssert(expected, current);
        }

        [TestMethod]
        public void Black()
        {
            var current = new HSV(Pixel32.Black);
            var expected = new HSV(0d, 0d, 0d);
            HSVAssert(expected, current);
        }

        [TestMethod]
        public void Pink()
        {
            var current = new HSV(new Pixel32(240, 76, 255));
            var expected = new HSV(295d, 70.2d, 100d);
            HSVAssert(expected, current);
        }

        [TestMethod]
        public void Green()
        {
            var current = new HSV(new Pixel32(100, 211, 109));
            var expected = new HSV(125d, 52.6d, 82.7d);
            HSVAssert(expected, current);
        }

        [TestMethod]
        public void Gold()
        {
            var current = new HSV(new Pixel32(255, 211, 109));
            var expected = new HSV(42d, 57.3d, 100d);
            HSVAssert(expected, current);
        }
    }
}
