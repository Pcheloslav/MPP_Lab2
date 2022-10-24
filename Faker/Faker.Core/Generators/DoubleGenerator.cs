using Faker.Core.Context;
using Faker.Core.Interfaces;

namespace Faker.Core.Generators
{
    public class DoubleGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(double) || type == typeof(Double);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (double)context.Random.NextDouble();
        }
    }
}
