using Faker.Core.Context;
using Faker.Core.Generators;
using Faker.Core.Interfaces;

namespace Faker.Core.Services
{
    public class FakerImpl : IFaker
    {
        private readonly GeneratorContext _context;
        private readonly List<IValueGenerator> _generators;
        private Dictionary<Type, int> _types = new();
        

        public FakerImpl()
        {
            _context = new GeneratorContext(new Random(), this, new GeneratorConfig());
            _generators = new List<IValueGenerator> {
                new ByteGenerator(),
                new SByteGenerator(),
                new BoolGenerator(),
                new IntGenerator(),
                new LongGenerator(),
                new ShortGenerator(),
                new DoubleGenerator(),
                new FloatGenerator(),
                new CharGenerator(),
                new StringGenerator(),
                new ListGenerator(),
                new DictionaryGenerator(),
                new DateTimeGenerator(),
                new UserTypeGenerator(),
            };
        }

        public T Create<T>()
        {
            return (T)CreateObject(typeof(T));
        }


        public object Create(Type t)
        {
            return CreateObject(t);
        }

        private object CreateObject(Type type)
        {
            try
            {
                if (!AddNewType(type))
                {
                    return null;
                }
                var generator = _generators.FirstOrDefault(g => g.CanGenerate(type), null);
                if (generator == null)
                {
                    throw new InstantiationException($"Missing generator for type={type.FullName}");
                }

                return generator.Generate(type, _context);
            }
            finally
            {
                RemoveType(type);
            }
        }
        private bool AddNewType(Type type)
        {
            if (_types.ContainsKey(type))
            {
                _types[type]++;
            }
            else
            {
                _types.Add(type, 1);
            }

            return _types[type] <= _context.Config.NestingLevel;
        }

        private void RemoveType(Type type)
        {
            _types[type]--;
        }
    }
}
