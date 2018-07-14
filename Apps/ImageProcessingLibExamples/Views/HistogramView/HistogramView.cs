using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using ImageProcessingLib;
using LiveCharts;
using LiveCharts.Wpf;

namespace ImageProcessingLibExamples.Views
{
    public partial class HistogramView : BaseForm, IHistogramView
    {
        public ImageHistogram Histogram
        {
            set
            {
                var hist = value;
                chRed.Data = hist.R.Data;
                chGreen.Data = hist.G.Data;
                chBlue.Data = hist.B.Data;
            }
        }

        public HistogramView()
        {
            InitializeComponent();
        }
    }
}
