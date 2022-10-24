using Faker.Core.Interfaces;
using Faker.Core.Context;
using System.Text;

namespace Faker.Core.Generators
{
    public class StringGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            var length = context.Random.Next(1, context.Config.MaxStringLength);

            var builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(context.Faker.Create<char>());
            }
            return builder.ToString();
        }
    }
}
