using ReflectionPlaying.Models;

namespace ReflectionPlaying.Data
{
    public class DbContext : IDbContext
    {
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
