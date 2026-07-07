using LayerProject.DataAccess.Data.Repository.IRepository;
using LayerProject.Models;
using LayerProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LayerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ArticlesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            ArticleCategoryViewModel articleCategoryViewModel = new ArticleCategoryViewModel()
            {
                Article = new Article(),
                ListCategories = _unitOfWork.ICategoryRepository.GetListCategories(),
            };
            return View(articleCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(ArticleCategoryViewModel articleCategoryViewModel)
        {
            string mainRoute = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(articleCategoryViewModel.Article.Id == 0 && files.Count() > 0)
            {
                string nameFile = Guid.NewGuid().ToString();
                string upload = Path.Combine(mainRoute, @"images\articles");
                var extension = Path.GetExtension(files[0].FileName);

                using(var fileStream = new FileStream(Path.Combine(upload, nameFile + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                articleCategoryViewModel.Article.UrlImage = @"\images\articles\" + nameFile + extension;
                articleCategoryViewModel.Article.CreatedDate = DateTime.Now.ToString();

                _unitOfWork.IArticleRepository.Add(articleCategoryViewModel.Article);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            articleCategoryViewModel.ListCategories = _unitOfWork.ICategoryRepository.GetListCategories();
            return View(articleCategoryViewModel);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ArticleCategoryViewModel articleCategoryViewModel = new ArticleCategoryViewModel()
            {
                Article = new Article(),
                ListCategories = _unitOfWork.ICategoryRepository.GetListCategories(),
            };
            if(id<=0)
            {
                return BadRequest();
            }
            else
            {
                articleCategoryViewModel.Article = _unitOfWork.IArticleRepository.GetById(id);
                return View(articleCategoryViewModel);
            }
        }

        [HttpPost]
        public IActionResult Edit(ArticleCategoryViewModel articleCategoryViewModel)
        {
            string mainRoute = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var articleFromDb = _unitOfWork.IArticleRepository.GetById(articleCategoryViewModel.Article.Id);
            if (files.Count() > 0)
            {
                string nameFile = Guid.NewGuid().ToString();
                string upload = Path.Combine(mainRoute, @"images\articles");
                var extension = Path.GetExtension(files[0].FileName);

                //Comprobamos si existe la imagen
                var pathOldImage = Path.Combine(mainRoute, articleFromDb?.UrlImage?.TrimStart('\\'));
                if (System.IO.File.Exists(pathOldImage))
                {
                    System.IO.File.Delete(pathOldImage);
                }

                //Volvemos a subir la imagen
                using (var fileStream = new FileStream(Path.Combine(upload, nameFile + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                articleCategoryViewModel.Article.UrlImage = @"\images\articles\" + nameFile + extension;
                //articleCategoryViewModel.Article.CreatedDate = DateTime.Now.ToString();

                //_unitOfWork.IArticleRepository.Update(articleCategoryViewModel.Article);
                //_unitOfWork.Save();

                //return RedirectToAction("Index");
            }
            else
            {
                articleCategoryViewModel.Article.UrlImage = articleFromDb.UrlImage;
            }

            _unitOfWork.IArticleRepository.Update(articleCategoryViewModel.Article);
            _unitOfWork.Save();

            return RedirectToAction("Index");

        }
        #endregion

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
