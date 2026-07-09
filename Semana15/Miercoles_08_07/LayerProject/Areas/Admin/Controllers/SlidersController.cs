using LayerProject.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LayerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SlidersController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Call to API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _unitOfWork.ISliderRepository.GetAll(x=>!x.IsDeleted)});
        }
        #endregion
    }
}
