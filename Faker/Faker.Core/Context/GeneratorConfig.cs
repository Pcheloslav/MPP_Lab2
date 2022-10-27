using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.Context
{
    public class GeneratorConfig
    {
        public readonly int MaxStringLength;
        public readonly int MaxListLength;
        public readonly int MaxDictLength;
        public readonly int NestingLevel;

        public GeneratorConfig() : this(50, 20, 5, 3)
        {
        }

        public GeneratorConfig(int maxStringLength, int maxListLength, int maxDictLength, int nestingLevel)
        {
            MaxStringLength = maxStringLength;
            MaxListLength = maxListLength;
            MaxDictLength = maxDictLength;
            NestingLevel = nestingLevel;
        }
    }
}
