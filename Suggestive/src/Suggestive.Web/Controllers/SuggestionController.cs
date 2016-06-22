using Microsoft.AspNetCore.Mvc;

namespace Suggestive.Web.Controllers
{
    public class SuggestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}