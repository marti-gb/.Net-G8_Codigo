using LayerProject.Data;
using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void BlockUser(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(100);
            }
            _dbContext.SaveChanges();
        }

        public void UnBlockUser(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(_x => _x.Id == userId);
            if (user != null)
            {
                user.LockoutEnd = DateTime.Now;
            }
            _dbContext.SaveChanges();
        }
    }
}
