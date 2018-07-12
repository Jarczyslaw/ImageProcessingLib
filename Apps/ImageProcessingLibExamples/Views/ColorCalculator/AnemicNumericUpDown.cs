using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingLibExamples.Views.ColorCalculator
{
    public class AnemicNumericUpDown : NumericUpDown
    {
        private EventHandler anemicEventHandler;

        public event EventHandler AnemicValueChanged
        {
            add
            {
                anemicEventHandler += value;
                ValueChanged += value;
            }
            remove
            {
                anemicEventHandler -= value;
                ValueChanged -= value;
            }
        }

        public decimal AnemicValue
        {
            get { return Value; }
            set
            {
                ValueChanged -= anemicEventHandler;
                Value = value;
                ValueChanged += anemicEventHandler;
            }
        }
    }
}
