namespace Bookeasy.Api.Services
{
    public class NewAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IAccountService
    {
        void SignUp(NewAccount newAccount);
    }

    public class AccountService : IAccountService
    {
        public void SignUp(NewAccount newAccount)
        {
            throw new System.NotImplementedException();
        }
    }
}
