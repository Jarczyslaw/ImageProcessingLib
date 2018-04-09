using ImageProcessingLib;
using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

            var img = new Image8(@"C:\Users\JT\Desktop\lena_trans.png");


            pictureBox1.Image = img.Bitmap;
        }
    }
}
