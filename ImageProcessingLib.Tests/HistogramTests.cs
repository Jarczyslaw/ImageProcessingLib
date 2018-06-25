using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class HistogramTests
    {
        private static Histogram histogram;
        private static byte[] values;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            histogram = new Histogram();
            values = new byte[] { 16, 32, 64, 128, 16, 32, 128, 128, 64, 64 };
            histogram.Add(values);
        }

        [TestMethod]
        public void MostCommon()
        {
            var mostCommon = histogram.MostCommon;
            Assert.AreEqual(2, mostCommon.Count);
            Assert.IsTrue(mostCommon.Contains(64));
            Assert.IsTrue(mostCommon.Contains(128));
        }

        [TestMethod]
        public void MinMax()
        {
            Assert.AreEqual(128, histogram.Max.Value);
            Assert.AreEqual(16, histogram.Min.Value);
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(values.Length, histogram.Count);
        }
    }
}
