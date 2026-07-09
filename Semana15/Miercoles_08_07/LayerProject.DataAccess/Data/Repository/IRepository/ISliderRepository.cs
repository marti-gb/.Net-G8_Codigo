using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository.IRepository
{
    public interface ISliderRepository: IRepository<Slider>
    {
        void Update(Slider slider);
        void Delete(int id);
    }
}
