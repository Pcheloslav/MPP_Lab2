using Faker.Core.Interfaces;
using Faker.Core.Context;
using System.Reflection;

namespace Faker.Core.Generators
{
    public class UserTypeGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.IsClass || (type.IsValueType && !type.IsEnum);
        }

        public object Generate(Type type, GeneratorContext context)
        {
            var instance = CreateInstance(type, context);
            // Console.WriteLine("Created instance:\n" + instance + "\n");

            var properties = instance.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(property => property.CanWrite);
            foreach (var property in properties)
            {
                if (Equals(property.GetValue(instance), GetDefaultValue(property.PropertyType)))
                {
                    // Console.WriteLine($"Property={property}");
                    property.SetValue(instance, context.Faker.Create(property.PropertyType));
                }
            }
            // Console.WriteLine("Initialized props:\n" + instance + "\n");

            var fields = instance.GetType().GetFields()
                .Where(field => !field.IsStatic)
                .Where(field => !field.IsInitOnly);
            foreach (var field in fields)
            {
                if (Equals(field.GetValue(instance), GetDefaultValue(field.FieldType)))
                {
                    // Console.WriteLine($"Field={field}");
                    field.SetValue(instance, context.Faker.Create(field.FieldType));
                }
            }
            // Console.WriteLine("Initialized fields:\n" + instance + "\n");

            return instance;
        }

        private object CreateInstance(Type type, GeneratorContext context)
        {
            var constructors = type
                 .GetConstructors()
                 .OrderByDescending(c => c.GetParameters().Length)
                 .ToList();

            foreach (var constructor in constructors)
            {
                try
                {
                    return constructor.Invoke(
                         constructor.GetParameters()
                             .Select(p => context.Faker.Create(p.ParameterType))
                             .ToArray()
                         );
                }
                catch {}
            }

            try
            {
                var instance = Activator.CreateInstance(type);
                if (instance != null)
                {
                    return instance;
                }
            }
            catch {}

            throw new InstantiationException($"Can't create instance of {type.FullName}");
        }

        public static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
