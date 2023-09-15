using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class PhotoAlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
