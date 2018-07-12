using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Views
{
    public partial class ColorCalculatorView : Form
    {
        public Pixel32 Pixel
        {
            get { return new Pixel32((byte)nudA.AnemicValue, (byte)nudR.AnemicValue, (byte)nudG.AnemicValue, (byte)nudB.AnemicValue); }
            set
            {
                var p = value;
                nudA.AnemicValue = p.A;
                nudR.AnemicValue = p.R;
                nudG.AnemicValue = p.G;
                nudB.AnemicValue = p.B;
            }
        }

        public CMYK PixelCMYK
        {
            get { return new CMYK(Pixel); }
            set
            {
                var cmyk = value;
                nudC.AnemicValue = (decimal)cmyk.C;
                nudM.AnemicValue = (decimal)cmyk.M;
                nudY.AnemicValue = (decimal)cmyk.Y;
                nudK.AnemicValue = (decimal)cmyk.K;
            }
        }

        public HSV PixelHSV
        {
            get { return new HSV(Pixel); }
            set
            {
                var hsv = value;
                nudH.AnemicValue = (decimal)hsv.H;
                nudS.AnemicValue = (decimal)hsv.S;
                nudV.AnemicValue = (decimal)hsv.V;
            }
        }

        private string title;

        public ColorCalculatorView()
        {
            InitializeComponent();
            title = Text;
            LoadPixel(new Pixel32(255, 30, 60, 90));
        }

        public void SetCoordinates(int? x, int? y)
        {
            if (x == null || y == null)
                Text = title;
            else
                Text = string.Format("{0} [{1}, {2}]", title, x.Value, y.Value);
        }

        public void LoadPixel(Pixel32 pixel)
        {
            Pixel = pixel;
            PixelCMYK = new CMYK(pixel);
            PixelHSV = new HSV(pixel);
            UpdatePixelInfo();
        }

        private void UpdatePixelInfo()
        {
            UpdatePreview();
            UpdateHex();
        }

        private void UpdatePreview()
        {
            var color = Color.FromArgb(Pixel.Data);
            plColorPreview.BackColor = color;
        }

        private void UpdateHex()
        {
            tbHex.Text = "#" + Pixel.ToHex();
        }

        private void argb_AnemicValueChanged(object sender, EventArgs e)
        {
            var pixel = Pixel;
            PixelCMYK = new CMYK(pixel);
            PixelHSV = new HSV(pixel);
            UpdatePixelInfo();
        }
    }
}
