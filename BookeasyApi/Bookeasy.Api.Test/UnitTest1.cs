using MongoDB.Bson;
using NUnit.Framework;

namespace Iris.Api.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var obj = ObjectId.GenerateNewId();
            var str = obj.ToString();
            Assert.IsNotEmpty(obj.ToString());
        }
    }
}