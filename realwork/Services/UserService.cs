using realwork.Data;
using realwork.Model;

namespace realwork.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db) 
        {
            _db = db;
        }

        public void CreateUser(User user)
        {
        }
    }
}
