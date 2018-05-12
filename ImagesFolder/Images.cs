using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesFolder
{
    public class Images
    {
        public static Dictionary<string, Bitmap> AllBitmaps
        {
            get
            {
                var set = Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true);
                return set.OfType<DictionaryEntry>()
                    .Where(i => i.Value.GetType() == typeof(Bitmap))
                    .OrderBy(i => i.Key)
                    .ToDictionary(i => i.Key.ToString(), i => (Bitmap)i.Value);
            }
        }

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

        public static Bitmap Test2
        {
            get { return Resources.Test2; }
        }

        public static Bitmap HalfLena
        {
            get { return Resources.HalfLena; }
        }
    }
}
