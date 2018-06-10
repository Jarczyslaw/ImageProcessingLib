using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class SDROMFilter5 : SDROMFilter
    {
        public SDROMFilter5() :
            this(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 })
        { }

        public SDROMFilter5(int[] thresholds) :
            base(5, thresholds)
        { }
    }
}
