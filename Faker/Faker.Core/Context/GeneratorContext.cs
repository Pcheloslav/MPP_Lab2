using Faker.Core.Interfaces;

namespace Faker.Core.Context
{
    public class GeneratorContext
    {
        public Random Random { get; }
        public IFaker Faker { get; }
        public GeneratorConfig Config { get; }

        public GeneratorContext(Random random, IFaker faker, GeneratorConfig config)
        {
            Random = random;
            Faker = faker;
            Config = config;    
        }
    }
}
