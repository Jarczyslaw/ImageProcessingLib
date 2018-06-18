using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons.Utils
{
    public static class ComboBoxExtension
    {
        public static void BindDictionary<TKey, TValue>(this ComboBox comboBox, IDictionary<TKey, TValue> dictionary)
        {
            comboBox.Bind("Key", "Value", dictionary);
        }

        public static void Bind<T>(this ComboBox comboBox, string displayMember, string valueMember, IEnumerable<T> collection)
        {
            comboBox.DataSource = new BindingSource(collection, null);
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
    }
}
