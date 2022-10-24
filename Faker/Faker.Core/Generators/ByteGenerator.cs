using Faker.Core.Context;
using Faker.Core.Interfaces;

namespace Faker.Core.Generators
{
    public class ByteGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (byte) context.Random.Next(0, byte.MaxValue);
        }
    }
}
