using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StrumentoMusicaleController : Controller
    {
        public IActionResult Index()
        {

            using (MusicContext db = new MusicContext())
            {
                List<StrumentoMusicale> StrumentiMusicali = new List<StrumentoMusicale>();
                StrumentiMusicali = db.StrumentoMusicale.ToList<StrumentoMusicale>();
                return View("HomeADMIN", StrumentiMusicali);
            }
            
        }
    }
}
