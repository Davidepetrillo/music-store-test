using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers
{
    public class StrumentoMusicaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
