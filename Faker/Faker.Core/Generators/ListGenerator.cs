using Faker.Core.Context;
using Faker.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            var itemType = type.GetGenericArguments()[0];
            var listType = typeof(List<>).MakeGenericType(itemType);

            IList? list = Activator.CreateInstance(listType) as IList;
            if (list == null)
            {
                throw new InstantiationException($"Failed to instantiate List<{itemType}>");
            }

            var size = context.Random.Next(1, context.Config.MaxListLength);
            for (int i = 0; i < size; i++)
            {
                list.Add(context.Faker.Create(itemType));
            }

            return list;
        }
    }
}
