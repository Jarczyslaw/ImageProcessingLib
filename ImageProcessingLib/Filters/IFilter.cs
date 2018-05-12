using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingLib
{
    public interface IFilter
    {
        int Range { get; }
        byte Apply(byte[] neighbourhood);
    }
}
