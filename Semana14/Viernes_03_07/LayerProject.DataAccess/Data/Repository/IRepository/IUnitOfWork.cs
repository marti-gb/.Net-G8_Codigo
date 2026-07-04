namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository ICategoryRepository { get; }
        void Save();
    }
}
