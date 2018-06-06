using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class KuwaharaFilter : IFilter
    {
        public class SubArrayStatistics
        {
            public double MeanValue { get; set; } = 0d;
            public double Variance { get; set; } = 0d;

            public SubArrayStatistics(byte[,] subArea, int subAreaSize)
            {
                GetMeanValue(subArea, subAreaSize);
                GetVariance(subArea, subAreaSize);
            }

            private void GetMeanValue(byte[,] subArea, int subAreaSize)
            {
                for (int i = 0; i < subAreaSize; i++)
                    for (int j = 0; j < subAreaSize; j++)
                        MeanValue += subArea[i, j];
                MeanValue = MeanValue / (subAreaSize * subAreaSize);
            }

            private void GetVariance(byte[,] subArea, int subAreaSize)
            {
                for (int i = 0; i < subAreaSize; i++)
                    for (int j = 0; j < subAreaSize; j++)
                        Variance += Math.Pow((subArea[i, j] - MeanValue), 2d);
                Variance = Variance / (subAreaSize * subAreaSize);
            }
        }

        public int Range { get; private set; }

        public KuwaharaFilter(int size)
        {
            Range = size - 1;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var areaSize = Range * 2 + 1;
            var subAreaSize = Range + 1;
            var area = ArrayUtils.Reshape(neighbourhood, areaSize, areaSize);

            var statistics = new List<SubArrayStatistics>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var subArea = ArrayUtils.SubArray(area, i * Range, j * Range, subAreaSize, subAreaSize);
                    statistics.Add(new SubArrayStatistics(subArea, subAreaSize));
                }
            }

            SubArrayStatistics bestStatistics = statistics.First();
            for (int i = 1; i < statistics.Count; i++)
            {
                if (bestStatistics.Variance < statistics[i].Variance)
                    bestStatistics = statistics[i];
            }
            return MathUtils.ByteClamp(bestStatistics.MeanValue);
        }
    }
}
