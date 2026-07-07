namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository ICategoryRepository { get; }
        IArticleRepository IArticleRepository { get; }
        void Save();
    }
}
