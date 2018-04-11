using System;
using System.Collections.Generic;
using System.Text;

namespace SampleTests.Models
{
    public class ExampleModel
    {
        public string Name { get; set; }
        public int Counter { get; set; }
        [Obsolete]
        public string AttributeExanple { get; set; }
    }
}
