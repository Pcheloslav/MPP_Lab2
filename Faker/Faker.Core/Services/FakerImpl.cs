﻿using Faker.Core.Context;
using Faker.Core.Generators;
using Faker.Core.Interfaces;

namespace Faker.Core.Services
{
    public class FakerImpl : IFaker
    {
        private GeneratorContext _context;
        private List<IValueGenerator> _generators;

        public FakerImpl()
        {
            _context = new GeneratorContext(new Random(), this);
            _generators = new List<IValueGenerator> {
                new ByteGenerator(),
                new SByteGenerator(),
                new BoolGenerator(),
                new IntGenerator(),
                new LongGenerator(),
                new ShortGenerator(),
                new DoubleGenerator(),
                new FloatGenerator(),
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
            var generator = _generators.FirstOrDefault(g => g.CanGenerate(type), null);
            if (generator == null)
            {
                throw new InstantiationException($"Missing generator for type={type.FullName}");
            }
            return generator.Generate(type, _context);
        }
    }
}