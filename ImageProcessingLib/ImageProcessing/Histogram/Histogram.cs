using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class Histogram
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
                var indices = ArrayUtils.IndicesOf(data, max);
                return indices.Select(i => (byte)i).ToList();    
            }
        }

        public int Count
        {
            get
            {
                return data.Sum();
            }
        }

        public Histogram()
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

        public void Add(params byte[] values)
        {
            foreach (var value in values)
                Add(value);
        }

        public int[] GetCummulativeData()
        {
            var result = new int[data.Length];
            int sum = 0;
            for (int i = 0;i < data.Length;i++)
            {
                sum += data[i];
                result[i] = sum;
            }
            return result;
        }
    }
}
