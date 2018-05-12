using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class FilterBaseTests
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
            CollectionAssert.AreEqual(new double[] { 2d, 4d, 6d, 8d, 10d, 12d, 14d, 16d, 18d }, filter.Kernel);
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
