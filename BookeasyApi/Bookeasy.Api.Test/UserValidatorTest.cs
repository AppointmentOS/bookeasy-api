using FluentValidation;
using Iris.Api.DTOs;
using Iris.Api.Validators;
using Iris.Domain;
using NUnit.Framework;

namespace Iris.Api.Test
{
    [TestFixture]
    public class UserValidatorTest
    {
        public AbstractValidator<NewUser> Validator = new UserValidator();
        
        [Test]
        public void Validate_NullUser_False()
        {
            var newUser = new NewUser();
            Assert.IsFalse(Validator.Validate(newUser).IsValid);
        }

        [Test]
        public void Validate_ValidUser_True()
        {
            var user = new NewUser
            {
                FirstName = "John",
                LastName = "Doe"
            };
            
            Assert.IsTrue(Validator.Validate(user).IsValid);
        }
    }
}