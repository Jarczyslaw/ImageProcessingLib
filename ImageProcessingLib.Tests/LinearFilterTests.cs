using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class LinearFilterTests
    {
        [TestMethod]
        public void ValidCreation()
        {
            var multiplier = 2d;
            var kernel = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var filter = new LinearFilter(multiplier, kernel);
            Assert.AreEqual(kernel.Length, filter.Kernel.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidCreation()
        {
            var kernel = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            var filter = new LinearFilter(0d, kernel);
        }
    }
}
