using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class SDROMFilter5 : SDROMFilter
    {
        public SDROMFilter5() :
            base(5, new int[] { 20, 40, 60, 80, 100 })
        { }
    }
}
