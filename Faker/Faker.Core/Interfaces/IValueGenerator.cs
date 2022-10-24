using Faker.Core.Context;

namespace Faker.Core.Interfaces
{
    public interface IValueGenerator
    {
        object Generate(Type type, GeneratorContext context);

        bool CanGenerate(Type type);
    }
}
