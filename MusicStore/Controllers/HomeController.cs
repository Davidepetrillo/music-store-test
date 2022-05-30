using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using System.Diagnostics;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (MusicContext db = new MusicContext())
            {
                try
                {
                    StrumentoMusicale strumentoTrovato = db.StrumentoMusicale
                        .Where(x => x.Id == id)
                        .First();
                    return View("Details", strumentoTrovato);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Lo strumento musicale non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        public IActionResult AboutUs()
        {
            return View();
        }

    }
}