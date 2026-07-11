using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface IArticleRepository : IRepository<Article>
    {
        void Update(Article article);
        void Delete(int id);
        IQueryable<Article> AsQueryable();
    }
}
