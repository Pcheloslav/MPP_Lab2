using Faker.Core.Context;
using Faker.Core.Interfaces;
using System.Collections;


namespace Faker.Core.Generators
{
    public class DictionaryGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            var keyType = type.GetGenericArguments()[0];
            var valueType = type.GetGenericArguments()[1];
            var dictionaryType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);

            IDictionary? dictionary = Activator.CreateInstance(dictionaryType) as IDictionary;
            if (dictionary == null)
            {
                throw new InstantiationException($"Failed to instantiate Dictionary<{keyType},{valueType}>");
            }

            var size = context.Random.Next(1, context.Config.MaxDictLength);
            for (int i = 0; i < size; i++)
            {
                dictionary.Add(context.Faker.Create(keyType), context.Faker.Create(valueType));
            }
            return dictionary;
        }
    }
}
