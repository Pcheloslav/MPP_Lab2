using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.Interfaces
{
    public class InstantiationException : Exception
    {
        public InstantiationException(string message) : base(message)
        {
        }
    }
}
