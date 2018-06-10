using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessingLib
{
    public class SDROMFilter : IFilter
    {
        public int Range { get; private set; }
        public int MaskSize { get; private set; }
        private int[] thresholds;

        public SDROMFilter(int maskSize, int[] thresholds)
        {
            Validate(maskSize, thresholds);

            this.thresholds = thresholds;
            MaskSize = maskSize;
            Range = maskSize / 2;
        }

        public byte Apply(byte[] neighbourhood)
        {
            var currentValueIndex = MaskSize * MaskSize / 2;
            var currentValue = neighbourhood[currentValueIndex];
            var rom = neighbourhood.ToList();
            rom.RemoveAt(currentValueIndex);
            rom.Sort();
            var romSize = rom.Count;
            var romValue = (rom[currentValueIndex - 1] + rom[currentValueIndex]) / 2d;

            var rodSize = romSize / 2;
            var rod = new int[rodSize];
            for (int i = 0; i < rodSize; i++)
            {
                if (currentValue <= romValue)
                    rod[i] = rom[i] - currentValue;
                else
                    rod[i] = currentValue - rom[romSize - i - 1];
            }

            for (int i = 0; i < rodSize; i++)
            {
                if (rod[i] > thresholds[i])
                {
                    currentValue = MathUtils.RoundToByte(romValue);
                    break;
                }
            }
            return currentValue;
        }

        private void Validate(int maskSize, int[] thresholds)
        {
            ValidationUtils.IsMaskSize(maskSize);

            if (thresholds.Length != (maskSize * maskSize - 1) / 2)
                throw new ArgumentException("Thresholds must contain (maskSize ^ 2 - 1) / 2 elements");
        }
    }
}
