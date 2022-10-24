using Faker.Core.Interfaces;
using Faker.Core.Context;

namespace Faker.Core.Generators
{
    public class BoolGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.Next(0, 2) == 1;
        }
    }
}
