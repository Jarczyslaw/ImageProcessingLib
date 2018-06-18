using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class HistogramResult
    {
        public HistogramComponent R { get; private set; }
        public HistogramComponent G { get; private set; }
        public HistogramComponent B { get; private set; }

        public HistogramResult()
        {
            R = new HistogramComponent();
            G = new HistogramComponent();
            B = new HistogramComponent();
        }
    }
}
