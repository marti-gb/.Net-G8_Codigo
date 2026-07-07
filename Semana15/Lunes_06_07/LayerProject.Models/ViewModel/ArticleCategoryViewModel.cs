using Microsoft.AspNetCore.Mvc.Rendering;

namespace LayerProject.Models.ViewModel
{
    public class ArticleCategoryViewModel
    {
        public Article Article { get; set; }
        public IEnumerable<SelectListItem> ListCategories { get; set; }
    }
}
