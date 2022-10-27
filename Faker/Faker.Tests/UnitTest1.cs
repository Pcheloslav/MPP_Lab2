using Faker.Core.Generators;
using Faker.Core.Interfaces;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Tests
{
    public class Tests
    {
        private IFaker _faker;

        [SetUp]
        public void Setup()
        {
            _faker = new Core.Services.FakerImpl();
        }

        [Test]
        [TestCase(typeof(DateTime))]
        [TestCase(typeof(byte))]
        [TestCase(typeof(short))]
        [TestCase(typeof(int))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        [TestCase(typeof(sbyte))]
        [TestCase(typeof(string))]
        [TestCase(typeof(bool))]
        [TestCase(typeof(char))]
        [TestCase(typeof(TestClass1))]
        [TestCase(typeof(ConstructorTest))]
        [TestCase(typeof(List<List<int>>))]

        public void CreatePrimitiveTest(Type type)
        {
            Assert.DoesNotThrow(() => _faker.Create(type));
        }

        [Test]
        [TestCase(typeof(byte))]
        [TestCase(typeof(short))]
        [TestCase(typeof(int))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        [TestCase(typeof(sbyte))]
        [TestCase(typeof(string))]
        [TestCase(typeof(bool))]
        [TestCase(typeof(char))]
        public void CreatePrimitiveNotDefaultValue(Type type)
        {
            Assert.That(_faker.Create(type), Is.Not.EqualTo(UserTypeGenerator.GetDefaultValue(type)));
        }

        [Test]
        public void CreateInitedUserType()
        {
            TestClass1 testClass = _faker.Create<TestClass1>();

            Assert.Multiple(() =>
            {
                Assert.NotZero(testClass.Int);
                Assert.NotZero(testClass.Byte);
                Assert.NotNull(testClass.String);
                Assert.True(testClass.Bool);
                Assert.NotNull(testClass.b);
                Assert.That(testClass.b.symbol, Is.Not.EqualTo('\0'));
            });
        }

        [Test]
        public void CreateWithCycleDependencies()
        {
            Assert.DoesNotThrow(() => _faker.Create<TestClass2>());
        }

        [Test]
        public void CreateCycleParentInited()
        {
            TestClass2 testClass = _faker.Create<TestClass2>();
            Assert.Multiple(() =>
            {
                Assert.NotNull(testClass.tc3.tc4.tc2);
                Assert.NotNull(testClass.tc3.tc4.tc2.str);
            });

        }

        [Test]
        public void CreateSelectConstructor()
        {
            ConstructorTest testClass = _faker.Create<ConstructorTest>();
            Assert.NotZero(testClass.Prop);
        }

        [Test]
        public void CreateTestStructCtor()
        {
            StructTest ctorStruct = _faker.Create<StructTest>();

            Assert.Multiple(() =>
            {
                Assert.NotNull(ctorStruct.String);
                Assert.NotZero(ctorStruct.Int);
            });
        }

        [Test]
        public void CreateTestInitStruct()
        {
            StructInitTest initStruct = _faker.Create<StructInitTest>();

            Assert.Multiple(() =>
            {
                Assert.NotZero(initStruct.a);
                Assert.True(initStruct.Bool);
            });
        }

        [Test]
        public void CreateListValueCheckTest()
        {
            bool containsZeros = _faker.Create<List<int>>()
                .Where(p => p == 0).Count() > 0;

            Assert.False(containsZeros);
        }


        [Test]
        [TestCase(typeof(List<List<List<int>>>))]
        [TestCase(typeof(List<List<Char>>))]
        public void CreateListTest(Type type)
        {
            var list = (IList)_faker.Create(type);

            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(list);
                Assert.IsNotEmpty((IList)list[0]);
            });
        }
        
    }

}
