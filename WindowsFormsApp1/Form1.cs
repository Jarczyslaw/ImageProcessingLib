using ImageProcessingLib;
using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var path = @"C:\Users\JT\Desktop\lena.bmp";
            var im = new Bitmap(path);
            Image24 bmp = new Image24(im);
            for (int i = 0; i < 512; i++)
                bmp[i, i] = Color.Black;
            
            pictureBox1.Image = bmp.Bitmap;
        }
    }
}
