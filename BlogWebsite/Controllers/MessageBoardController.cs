using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class MessageBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
