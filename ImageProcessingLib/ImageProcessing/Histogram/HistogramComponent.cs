using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class HistogramComponent
    {
        private int[] data;
        public ReadOnlyCollection<int> Data
        {
            get { return Array.AsReadOnly(data); }
        }

        public byte? Max { get; private set; }
        public byte? Min { get; private set; }

        public List<byte> MostCommon
        {
            get
            {
                int max = data.Max();
                return ArrayUtils.IndicesOf(data, max)
                    .Cast<byte>().ToList();
            }
        }

        public HistogramComponent()
        {
            data = new int[byte.MaxValue + 1];
        }

        public void Clear()
        {
            for (int i = 0; i < data.Length; i++)
                data[i] = 0;
        }

        public void Add(byte value)
        {
            data[value]++;
            if (Max == null || value > Max)
                Max = value;
            if (Min == null || value < Min)
                Min = value;
        }
    }
}
