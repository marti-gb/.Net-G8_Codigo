using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Delete(int id);
    }
}
