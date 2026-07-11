using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void BlockUser(string userId);
        void UnBlockUser(string userId);
    }
}
