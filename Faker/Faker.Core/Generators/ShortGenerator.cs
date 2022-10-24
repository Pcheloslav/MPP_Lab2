using Faker.Core.Interfaces;
using Faker.Core.Context;

namespace Faker.Core.Generators
{
    public class ShortGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(short) || type == typeof(Int16);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (short)context.Random.Next(short.MinValue, short.MaxValue);
        }
    }
}
