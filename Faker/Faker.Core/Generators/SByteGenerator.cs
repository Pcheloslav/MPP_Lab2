using Faker.Core.Interfaces;
using Faker.Core.Context;


namespace Faker.Core.Generators
{
    public class SByteGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(sbyte);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (sbyte)context.Random.Next(sbyte.MinValue, sbyte.MaxValue);
        }
    }
}
