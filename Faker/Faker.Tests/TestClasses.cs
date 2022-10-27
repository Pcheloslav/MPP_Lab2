using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Tests
{
    public class TestClass1
    {
        public int Int { get; set; }
        public string String { get; set; }
        public byte Byte { get; set; }
        public B? b;
        public bool Bool { get; set; }

        public TestClass1 parent;

        public TestClass1(int intValue, string stringValue)
        {
            Int = intValue;
            String = stringValue;
        }
    }

    public class B
    {
        public char symbol;

        private sbyte sb;
    }
    public class A
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "";

        public A()
        {
        }

        public A(int id)
        {
            Id = id;
            // throw new Exception("Oops 1");
        }

        public A(int id, string name) : this(id)
        {
            Name = name;
            // throw new Exception("Oops 2");
        }

        public override string ToString()
        {
            return $"{this.GetType().FullName} {{Id={Id}, Name='{Name}'}}";
        }
    }

    public class Address
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AddressLine1 { get; set; }

        public Address(string? country, string? city, string? addressLine1)
        {
            Country = country;
            City = city;
            AddressLine1 = addressLine1;
        }

        public override string? ToString()
        {
            return $"{this.GetType().FullName} {{Country={Country}, " +
                $"City={City}, AddressLine1={AddressLine1}}}";
        }
    }

    public class Person
    {
        public double _weight;

        public int Id { get; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Address? Address { get; set; }

        public Person(int id)
        {
            Id = id;
        }

        public Person(int id, string firstName, string lastName) : this(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int Height
        {
            get { return -1; }
            set { }
        }

        public override string? ToString()
        {
            return $"{this.GetType().FullName} {{Id={Id}, FirstName={FirstName}, " +
                $"LastName={LastName}, Address={Address}, Weight={_weight}}}";
        }
    }

    public class TestClass2
    {
        public TestClass3 tc3 { get; set; }
        public string str { get; set; }
    }

    public class TestClass3
    {
        public TestClass4 tc4 { get; set; }
    }

    public class TestClass4
    {
        public TestClass2 tc2 { get; set; }
    }

    public class ConstructorTest
    {
        public int a;
        public int b;
        public int Prop { get; }

        public ConstructorTest()
        { }

        public ConstructorTest(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public ConstructorTest(int a, int b, int p) : this(a, b)
        {
            this.Prop = p;
        }
    }

    public struct StructTest
    {
        public int Int { get; }
        public string String { get; set; }

        public StructTest(int intValue, string stringValue)
        {
            Int = intValue;
            String = stringValue;
        }
    }

    public struct StructInitTest
    {
        public int a { get; set; }
        public bool Bool { get; set; }
    }
}
