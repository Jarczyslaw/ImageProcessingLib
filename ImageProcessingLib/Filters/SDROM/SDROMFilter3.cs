using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class SDROMFilter3 : SDROMFilter
    {
        public SDROMFilter3()
            : this(new int[4] { 20, 40, 60, 80 })
        { }

        public SDROMFilter3(int[] thresholds) :
                base(3, thresholds)
        { }
    }
}
