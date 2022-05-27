using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StrumentoMusicaleController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            using (MusicContext db = new MusicContext())
            {
                List<StrumentoMusicale> StrumentiMusicali = new List<StrumentoMusicale>();
                StrumentiMusicali = db.StrumentoMusicale.ToList<StrumentoMusicale>();
                return View("HomeADMIN", StrumentiMusicali);
            }

        }

        //-----------------------------CREA------------------------------------------



        [HttpGet]
        public IActionResult Create()
        {
            return View("CreaADMIN");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StrumentoMusicale nuovoStrumentoMusicale)
        {
            if (!ModelState.IsValid)
            {
                return View("CreaADMIN", nuovoStrumentoMusicale);
            }

            using (MusicContext db = new MusicContext())
            {


               StrumentoMusicale StrumentoDaCreare = new StrumentoMusicale(nuovoStrumentoMusicale.Nome, nuovoStrumentoMusicale.Descrizione, nuovoStrumentoMusicale.Foto, nuovoStrumentoMusicale.Prezzo, nuovoStrumentoMusicale.QuantitaStrumento);

                db.StrumentoMusicale.Add(StrumentoDaCreare);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
