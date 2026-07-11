using LayerProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Delete(int id);
        IEnumerable<SelectListItem> GetListCategories();
    }
}
