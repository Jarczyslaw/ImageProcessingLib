using ImageProcessingTest.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingTest
{
    public static class OperationsLoader
    {
        public static List<Type> GetOperations()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(OperationBase)))
                .OrderBy(t => t.Name)
                .ToList();
        }

        public static Dictionary<string, OperationBase> CreateOperationsDictionary()
        {
            var result = new Dictionary<string, OperationBase>();
            var operations = GetOperations();
            foreach(var operation in operations)
            {
                var title = operation.Name.Replace("Operation", string.Empty);
                var operationInstance = (OperationBase)Activator.CreateInstance(operation);
                result.Add(title, operationInstance);
            }
            return result;
        }
    }
}
