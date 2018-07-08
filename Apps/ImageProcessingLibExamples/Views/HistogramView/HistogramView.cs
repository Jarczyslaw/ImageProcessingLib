using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessingLib;

namespace ImageProcessingLibExamples.Views
{
    public partial class HistogramView : Form, IHistogramView
    {
        public HistogramView()
        {
            InitializeComponent();
        }

        public ImageHistogram Histogram { set => throw new NotImplementedException(); }

        public void CloseView()
        {
            Close();
        }

        public void ShowView()
        {
            Show();
        }

        public void ShowViewAsDialog()
        {
            ShowDialog();
        }
    }
}
