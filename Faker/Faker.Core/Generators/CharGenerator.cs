using Faker.Core.Context;
using Faker.Core.Interfaces;

namespace Faker.Core.Generators
{
    public class CharGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(char) || type == typeof(Char);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            // Printable ASCII characters only
            return (char) context.Random.Next(32, 126);
        }
    }
}
