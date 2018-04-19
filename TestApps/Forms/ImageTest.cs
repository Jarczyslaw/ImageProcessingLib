﻿using ImageProcessingLib;
using ImageProcessingLib.GDI;
using ImageProcessingLib.ImageProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp.Forms
{
    public partial class ImageTest : Form
    {
        private GDImage32 image;

        public ImageTest()
        {
            InitializeComponent();
            image = GetImage();
            pbImage.Image = image.Bitmap;
            ResizeTo(image.Bitmap.Width, image.Bitmap.Height);
        }

        private GDImage32 GetImage()
        {
            var image = new GDImage32(ImagesFolder.Images.Lena);
            image.Image.FlipVertical();
            return image;
        }

        private void ResizeTo(int width, int height)
        {
            int x = Width - pbImage.Width;
            int y = Height - pbImage.Height;
            pbImage.Width = width;
            pbImage.Height = height;
            Width = width + x;
            Height = height + y;
        }

        private void ImageTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            image.Dispose();
        }

        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var cm = new ContextMenu();
            cm.MenuItems.Add("Save", ImageSave);
            cm.Show(pbImage, e.Location);
        }

        private void ImageSave(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "Bitmap Image (.bmp)|*.bmp",
                FileName = "image"
            };
            var dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    image.ToFile(sfd.FileName);
                    MessageBoxEx.ShowInfo("Image saved as: " + sfd.FileName);
                }
                catch (Exception exc)
                {
                    MessageBoxEx.ShowError(exc.ToString());
                }
            }
        }
    }
}
