using ImageProcessingLibExamples.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLibExamples
{
    public interface IExamplesSource
    {
        List<Type> GetExamples();
        Dictionary<string, ExampleBase> CreateExamplesDictionary();
    }
}
