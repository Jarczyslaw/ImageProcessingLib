using ImageProcessingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Views
{
    public partial class ColorCalculatorView : Form, IColorCalculatorView
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
            get { return new CMYK((double)nudC.AnemicValue, (double)nudM.AnemicValue, (double)nudY.AnemicValue, (double)nudK.AnemicValue); }
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
            get { return new HSV((double)nudH.AnemicValue, (double)nudS.AnemicValue, (double)nudV.AnemicValue); }
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
            LoadPixel(Pixel32.CreateRandom());
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

        private void hsv_AnemicValueChanged(object sender, EventArgs e)
        {
            var hsv = PixelHSV;
            Pixel = hsv.GetPixel();
            PixelCMYK = new CMYK(Pixel);
            UpdatePixelInfo();
            Debug.WriteLine(PixelHSV.ToString());
        }

        private void cmyk_AnemicValueChanged(object sender, EventArgs e)
        {
            var cmyk = PixelCMYK;
            Pixel = cmyk.GetPixel();
            PixelHSV = new HSV(Pixel);
            UpdatePixelInfo();
        }

        public void ShowView()
        {
            Show();
        }

        public void ShowViewAsDialog()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
        }
    }
}
