using Faker.Core.Context;
using Faker.Core.Interfaces;

namespace Faker.Core.Generators
{
    public class LongGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(long) || type == typeof(Int64);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (long)context.Random.NextInt64(long.MinValue, long.MaxValue);
        }
    }
}
