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
    public partial class HistogramView : Form, IHistogramView
    {
        public event Action OnLoad;

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
            chRed.Color = Brushes.Red;
            chGreen.Color = Brushes.Green;
            chBlue.Color = Brushes.Blue;
        }

        private void HistogramView_Load(object sender, EventArgs e)
        {
            OnLoad?.Invoke();
        }

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
