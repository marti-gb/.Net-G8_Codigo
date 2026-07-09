using LayerProject.Data;
using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;

namespace LayerProject.DataAccess.Data.Repository
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SliderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var sliderFromDb = _dbContext.Sliders.FirstOrDefault(x=>x.Id == id && !x.IsDeleted) ;
            if (sliderFromDb != null)
            {
                sliderFromDb.IsDeleted = true;
            }
            _dbContext.SaveChanges();
        }

        public void Update(Slider slider)
        {
            var sliderFromDb = _dbContext.Sliders.FirstOrDefault(x => x.Id == slider.Id && !x.IsDeleted);
            if (sliderFromDb != null)
            {
                sliderFromDb.Name = slider.Name;
                sliderFromDb.State = slider.State;
                sliderFromDb.UrlImage = slider.UrlImage;
            }
            _dbContext.SaveChanges();
        }
    }
}
