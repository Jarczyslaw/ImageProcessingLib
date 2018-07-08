using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ImageProcessingLibExamples.Views
{
    public class HistogramChart : LiveCharts.WinForms.CartesianChart
    {
        public Brush Color
        {
            get { return Serie.Fill; }
            set { Serie.Fill = value; }
        }
        public ColumnSeries Serie { get; private set; }
        public IReadOnlyCollection<int> Data
        {
            set
            {
                if (Serie.Values != null)
                    Serie.Values.Clear();
                Serie.Values = new ChartValues<int>(value);
            }
        }

        public HistogramChart()
        {
            DisableAnimations = true;
            Initialize();
        }

        private void Initialize()
        {
            Clear();
            Serie = new ColumnSeries
            {
                ColumnPadding = 0,
                Title = "Count"
            };
            Series = new SeriesCollection { Serie };

            var xAxis = new Axis
            {
                Separator = new Separator
                {
                    Step = 32,
                    Stroke = Brushes.Black
                },
                MinValue = -1,
                MaxValue = 256,
                Foreground = Brushes.Black
            };
            AxisX.Add(xAxis);

            var yAxis = new Axis
            {
                Separator = new Separator
                {
                    Stroke = Brushes.Black
                },
                MinValue = 0,
                Foreground = Brushes.Black
            };
            AxisY.Add(yAxis);
        }

        private void Clear()
        {
            Series.Clear();
            AxisX.Clear();
            AxisY.Clear();
        }
    }
}
