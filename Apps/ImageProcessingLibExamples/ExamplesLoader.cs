using Commons;
using Commons.Utils;
using ImageProcessingLibExamples.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples
{
    public static class ExamplesLoader
    {
        public static List<Type> GetExamples()
        {
            return AssemblyUtils.GetTypesSubclassOf<ExampleBase>()
                .OrderBy(t => t.Name)
                .ToList();
        }

        public static Dictionary<string, ExampleBase> CreateExamplesDictionary()
        {
            var result = new Dictionary<string, ExampleBase>();
            var examples = GetExamples();
            foreach(var example in examples)
            {
                var exampleInstance = (ExampleBase)Activator.CreateInstance(example);
                result.Add(example.Name, exampleInstance);
            }
            return result;
        }
    }
}
