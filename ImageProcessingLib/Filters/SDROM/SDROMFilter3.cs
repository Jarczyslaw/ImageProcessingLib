using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public class SDROMFilter3 : SDROMFilter
    {
        public SDROMFilter3() :
            base(3, new int[4] { 20, 40, 60, 80 })
        { }
    }
}
