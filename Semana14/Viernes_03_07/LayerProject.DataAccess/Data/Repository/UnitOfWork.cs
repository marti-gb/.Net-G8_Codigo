using LayerProject.Data;
using LayerProject.DataAccess.Data.Repository.IRepository;

namespace LayerProject.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ICategoryRepository = new CategoryRepository(_db);
        }

        public ICategoryRepository ICategoryRepository { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
