using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    internal class OilPaintLookup
    {
        private Dictionary<int, OilPaintIntensity> intensities = new Dictionary<int, OilPaintIntensity>();
        private double q;

        public OilPaintLookup(int levels)
        {
            q = levels / 255d / 3d;
        }

        public void Add(Pixel32 pixel)
        {
            var intensity = MathUtils.FloorToInt((pixel.R + pixel.G + pixel.B) * q);

            OilPaintIntensity oilPaintIntensity;
            if (intensities.ContainsKey(intensity))
                oilPaintIntensity = intensities[intensity];
            else
            {
                oilPaintIntensity = new OilPaintIntensity();
                intensities.Add(intensity, oilPaintIntensity);
            }
            oilPaintIntensity.Add(pixel);
        }

        public Pixel32 GetResult(byte alpha)
        {
            var intensitiesKeys = intensities.Keys.ToList();
            var maxIntensity = intensities[intensitiesKeys[0]];
            for (int i = 1; i < intensitiesKeys.Count; i++)
            {
                var intensity = intensities[intensitiesKeys[i]];
                if (intensity.Count > maxIntensity.Count)
                    maxIntensity = intensity;
            }
            return maxIntensity.GetResult(alpha);
        }
    }
}
