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


            Image24 bmp = new Image24(30, 20);
            /*for (int i = 0;i < bmp.Width; i++)
            {
                for (int j = 0;j < bmp.Height; j++)
                {
                    bmp[i, j] = Color.Red;
                }
            }*/

            var b = new Image8(bmp);
            
            pictureBox1.Image = b.Bitmap;
        }
    }
}
