using ReflectionPlaying.Models;

namespace ReflectionPlaying.Data
{
    public interface IAccountService
    {
        User RegisterUser(string username, string password);
        bool LoginUser(string username, string password);
        bool ChangePassword(string id, string oldPassword, string newPassword);
    }
}
