using ReflectionPlaying.Models;

namespace ReflectionPlaying.Data
{
    public interface IDbContext
    {
        ICollection<User> Users { get; set; }
    }
}
