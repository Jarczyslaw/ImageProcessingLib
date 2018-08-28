# ImageProcessingLib

## Intro

ImageProcessingLib is a C# library which allows to make most common operations and transformations on images. It's highly inspired by comprehensive elaboration created by Jakub Szymanowski which is available here: [Fundamentals of Image Processing - behind the scenes](https://www.codeproject.com/Articles/781213/Fundamentals-of-Image-Processing-behind-the-scenes). My library implements almost all operations described in this article.

The library itself is created as .NET Standard Library and doesn't need any external components.


## Functions

Implemented functions and image transformations:

- complement, crop, insert, resize
- flip, rotation
- filters: 
  - edge detection: Laplace, Sobel, Prewitt
  - linear: Gaussian, low pass, high pass
  - median
  - Kuwahara
  - SDROM
- color filtration
- to grayscale and black&white conversion
- effects: oil paint, cartoon, charcoal sketch, pen sketch
- morphology filtration: closing, dilation, erosion, opening and skeletonization
- sampling
- color accent
- gamma correction
- histogram operations: equalization, scaling, shifting and streching
- inversion and negative
- simple quantization
- sepia
	
With IPL you can also create image's histogram, compute discrete Fourier transform, calculate error metrics (MSE and PSNR) and add different kind of noises. There are also classes that are helpful in color spaces transformations (RGB, CMYK, HSV). 

There are 3 built in types of pixels: ARGB (Pixel32), grayscale (Pixel8) and black&white (Pixel1). Some operations are pixel-independent but some of them are supported only by specific image type (for example - morphology operations can be performed only on binary (Image<Pixel1>) images).
	
	
## Short explanation

Image<> is a simple generic collection of pixels. It almost all functions supports fluent syntax so you can create long chains of operation. See examples below to:

```cs
// create bitmap from file and convert it to Image<Pixel32>
var inputImagePath = @"inputImage.bmp";
var bitmap = new Bitmap(inputImagePath);
var image = ImageProcessingLibConverter.CreateImageFromBitmap(bitmap);

// resize it to desired size
image.Resize(512, 512, ResizeMethod.BilinearInterpolation);

// rotate it and flip horizontally
image.RotationClockwise()
	.FlipHorizontal();

// get image histogram
var histogram = image.Histogram();

// calculate discrete Fourier transform
var dft = image.DFT();

// create binary image 
var binaryImage = image.CopyAs(p => p.ToPixel1());

// perform closing and skeletonization operations
binaryImage.Closing(3)
  .Skeletonization();

// return to Image<Pixel32>, create Bitmap from it and save it
var resultImage = binaryImage.CopyAs(p => p.ToPixel32());
var resultBitmap = ImageProcessingLibConverter.CreateBitmapFromImage(resultImage);
var outputImagePath = @"outputImage.bmp";
resultBitmap.Save(outputImagePath);
```

## Solution contents

There are several projects in main solution:
- ImageProcessingLib - main library project
- ImageProcessingLib.Tests
- ImagesFolder - project which contains some test images
- FIP - project which holds FIP classes
- converters - contains projects with helper classes that performs conversions between Image, Bitmap and BitmapSource
- Apps:
  - Benchmarking - benchmark runner and few benchmarks used at the development stage
  - ImageProcessingLibExamples - WinForms application (with MVP pattern) which shows allows to perform all implemented functions
  - ImageProcessingLibToFIPComparison - simple app to compare IPL and FIP (result accuracy and performance)
  - TestApp.WF and TestApp.WPF - apps used for converters' testing

		
## Examples

As was mentioned above, there is a project which implements examples of all library's functions. To see how it works just look at the video below:

[![ImageProcessingLib](https://img.youtube.com/vi/Aj8G4JqMbQk/0.jpg)](https://www.youtube.com/watch?v=Aj8G4JqMbQk)


## External libraries and contents

There are two external libraries in IPL solution:
- [LiveCharts](https://lvcharts.net/)
- [BenchmarkDotNet](https://benchmarkdotnet.org/articles/overview.html)

Sample images are take from: [http://www.hlevkin.com/06testimages.htm](http://www.hlevkin.com/06testimages.htm)
