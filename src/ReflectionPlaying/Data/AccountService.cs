using ReflectionPlaying.Models;

namespace ReflectionPlaying.Data
{
    public class AccountService : IAccountService
    {
        private readonly IDbContext dbContext;

        public AccountService(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool ChangePassword(string id, string oldPassword, string newPassword)
        {
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            return true;
        }

        public User RegisterUser(string username, string password)
        {
            var user = new User
            {
                Name = username,
                Password = password
            };
            this.dbContext.Users.Add(user);
            return user;
        }
    }
}
