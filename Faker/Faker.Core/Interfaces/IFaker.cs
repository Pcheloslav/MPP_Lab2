namespace Faker.Core.Interfaces
{
    public interface IFaker
    {
        T Create<T>();

        object Create(Type t);
    }
}
