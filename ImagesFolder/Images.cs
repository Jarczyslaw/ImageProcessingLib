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

        public static Bitmap Baboon
        {
            get { return Resources.baboon; }
        }

        public static Bitmap Cablecar
        {
            get { return Resources.cablecar; }
        }

        public static Bitmap Earth
        {
            get { return Resources.earth; }
        }

        public static Bitmap Fruits
        {
            get { return Resources.fruits; }
        }

        public static Bitmap Goldhill
        {
            get { return Resources.goldhill; }
        }

        public static Bitmap Lena
        {
            get { return Resources.lena; }
        }

        public static Bitmap Lena128
        {
            get { return Resources.lena_128; }
        }

        public static Bitmap LenaGrayscale
        {
            get { return Resources.lena_grayscale; }
        }

        public static Bitmap Machcolor
        {
            get { return Resources.machcolor; }
        }

        public static Bitmap Monarch
        {
            get { return Resources.monarch; }
        }

        public static Bitmap Pens
        {
            get { return Resources.pens; }
        }

        public static Bitmap Pepper
        {
            get { return Resources.pepper; }
        }

        public static Bitmap Shapes
        {
            get { return Resources.shapes; }
        }

        public static Bitmap Yacht
        {
            get { return Resources.yacht; }
        }

        public static Bitmap Morph
        {
            get { return Resources.morph; }
        }
    }
}
