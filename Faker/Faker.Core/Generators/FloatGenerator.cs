using Faker.Core.Context;
using Faker.Core.Interfaces;

namespace Faker.Core.Generators
{
    public class FloatGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            return (float)context.Random.NextSingle();
        }
    }
}
