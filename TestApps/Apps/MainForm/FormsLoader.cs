using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApps
{
    public class FormsLoader
    {
        public List<Type> GetAllForms(params Type[] excluded)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            return types.Where(t => t.IsSubclassOf(typeof(Form)))
                .Where(t => !excluded.Contains(t))
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
