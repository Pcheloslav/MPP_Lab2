using Faker.Core.Context;
using Faker.Core.Interfaces;

namespace Faker.Core.Generators
{
    public class IntGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return context.Random.Next(int.MinValue, int.MaxValue);
        }
    }
}
