using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
