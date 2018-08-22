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
    public class ExamplesSource : IExamplesSource
    {
        public List<Type> GetExamples()
        {
            return AssemblyUtils.GetTypesSubclassOf<ExampleBase>()
                .OrderBy(t => t.Name)
                .ToList();
        }

        public Dictionary<string, ExampleBase> CreateExamplesDictionary()
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
