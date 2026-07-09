using LayerProject.Data;
using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ArticleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var articleFromDb = _dbContext.Articles.FirstOrDefault(x => x.Id == id);
            if (articleFromDb != null)
            {
                articleFromDb.IsDeleted = true;
            }
            _dbContext.SaveChanges();
        }

        public void Update(Article article)
        {
            var articleFromDb = _dbContext.Articles.FirstOrDefault(x => x.Id == article.Id);
            if (articleFromDb != null)
            {
                articleFromDb.Name = article.Name;
                articleFromDb.Description = article.Description;
                articleFromDb.UrlImage = article.UrlImage;
                articleFromDb.CategoryId = article.CategoryId;
            }
            _dbContext.SaveChanges();
        }
    }
}
