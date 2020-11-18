using Bookeasy.Domain.Entities;
using Bookeasy.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace Bookeasy.Infrastructure.Test
{
    [TestFixture]
    public class PasswordHasherUtilityTest
    {
        [Test]
        public void Test()
        {
            var password = "hellowordl";
            var salt = PasswordHasherUtility.CreateSalt();
            var hash = PasswordHasherUtility.HashPassword(password, salt);
            Assert.IsNotEmpty(hash);
            Assert.AreNotSame(password, hash);
        }

        [Test]
        public void TestSalt()
        {
            var salt = PasswordHasherUtility.CreateSalt();
            Assert.IsNotEmpty(salt);
            Assert.AreNotSame(salt, PasswordHasherUtility.CreateSalt());
        }

        [Test]
        public void TestVerify()
        {
            var password = "hellowordl";
            var salt = PasswordHasherUtility.CreateSalt();
            var hash = PasswordHasherUtility.HashPassword(password, salt);

            Assert.IsTrue(PasswordHasherUtility.VerifyPassword(password, salt, hash));
        }
    }
}