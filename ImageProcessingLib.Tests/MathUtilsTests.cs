using System;
using ImageProcessingLib.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class MathUtilsTests
    {
        private double tolerance = 0.001d;

        [TestMethod]
        public void Rescale()
        {
            Assert.AreEqual(2d, MathUtils.Rescale(1d, 1d, 3d, 2d, 6d), tolerance);
            Assert.AreEqual(6d, MathUtils.Rescale(3d, 1d, 3d, 2d, 6d), tolerance);
            Assert.AreEqual(4d, MathUtils.Rescale(2d, 1d, 3d, 2d, 6d), tolerance);
            Assert.AreEqual(0d, MathUtils.Rescale(3d, 2d, 10d, -1d, 7d), tolerance);
        }
    }
}
