using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesFolder
{
    public class Images
    {
        public static Bitmap Lena
        {
            get { return Resources.Lena; }
        }

        public static Bitmap LenaGray
        {
            get { return Resources.LenaGray; }
        }

        public static Bitmap LenaTrans
        {
            get { return Resources.LenaTrans; }
        }

        public static Bitmap Test
        {
            get { return Resources.Test; }
        }
    }
}
