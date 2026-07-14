using LayerProject.Data;
using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LayerProject.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            var categoryFromDb = _db.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryFromDb != null)
            {
                categoryFromDb.Name = category.Name;
                categoryFromDb.Order = category.Order;
                _db.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var categoryFromDb = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb != null)
            {
                categoryFromDb.IsDeleted = true;
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetListCategories()
        {
            return _db.Categories
            .Where(x => !x.IsDeleted)
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}
