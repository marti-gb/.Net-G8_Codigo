namespace LayerProject.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Slider> listSliders { get; set; }
        public IEnumerable<Article> listArticles { get; set; }

        //Pagination
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
