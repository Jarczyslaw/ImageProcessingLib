using System;
using ImagesFolder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessingLib.Tests
{
    [TestClass]
    public class ImageBaseTests
    {
        [TestMethod]
        public void CreateNew()
        {
            int width = 1000;
            int height = 2000;
            var image = new Image<Pixel32>(width, height);
            Assert.AreEqual(width, image.Width);
            Assert.AreEqual(height, image.Height);
            Assert.AreEqual(image.DataLength, width * height);
        }
        
        [TestMethod]
        public void CreateFromExisting()
        {
            var source = CreateTestImage();
            var image = new Image<Pixel32>(source);
            Assert.AreEqual(image, image);
        }

        [TestMethod]
        public void Swap()
        {
            var image = CreateTestImage();
            image.Swap(1, 2, 2, 3);
            Assert.AreEqual(image.Get(2, 3), Pixel32.Red);
            Assert.AreEqual(image.Get(1, 2), Pixel32.Green);
        }

        private Image<Pixel32> CreateTestImage()
        {
            var image = new Image<Pixel32>(3, 4);
            image.Set(1, 2, Pixel32.Red);
            image.Set(2, 3, Pixel32.Green);
            return image;
        }
    }
}
