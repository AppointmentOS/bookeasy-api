using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using Bookeasy.Infrastructure.Identity;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;

namespace Bookeasy.Infrastructure.Test
{
    [TestFixture]
    public class UserManagerServiceTest
    {
        [Test]
        public async Task CreateUserTest()
        {
            var user = new User()
            {
                Email = "sample@email.com"
            };
            var password = "password";

            var userMock = new Mock<IUserCollection>();
            userMock.Setup(u => u.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(() => new User()
                {
                    Id = ObjectId.GenerateNewId(),
                    Email = user.Email,
                    PasswordHash = "hash"
                });
            var contextMock = new Mock<IIrisDbContext>();
            contextMock.SetupGet(ctx => ctx.User).Returns(userMock.Object);

            var tokenGeneratorMock = new Mock<IAuthenticationTokenGenerator>();

            var manager = new UserManagerService(contextMock.Object, tokenGeneratorMock.Object);
            var result = await manager.CreateUserAsync(user, password);
            Assert.NotNull(result);
            Assert.IsTrue(result.Result.Succeeded);
            Assert.IsNotNull(result.user.Id);
        }
    }
}