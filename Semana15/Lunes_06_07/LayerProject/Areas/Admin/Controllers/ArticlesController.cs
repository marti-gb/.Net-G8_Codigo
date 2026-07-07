using LayerProject.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LayerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticlesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Call Apis
        [HttpGet]
        public IActionResult GetALL()
        {
            return Json(new { data = _unitOfWork.IArticleRepository.GetAll(filter: x=>!x.IsDeleted, 
                includeProperties:"Category") });
        }
        #endregion
    }
}
