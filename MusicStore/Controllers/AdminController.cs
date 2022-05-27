using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index() 
        {

            using (MusicContext db = new MusicContext())
            {
                List<StrumentoMusicale> StrumentiMusicali = new List<StrumentoMusicale>();
                StrumentiMusicali = db.StrumentoMusicale.ToList<StrumentoMusicale>();

                return View("Index", StrumentiMusicali);
            }

        }

        //-----------------------------CREA------------------------------------------



        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StrumentoMusicale nuovoStrumentoMusicale)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", nuovoStrumentoMusicale);
            }

            using (MusicContext db = new MusicContext())
            {


               StrumentoMusicale StrumentoDaCreare = new StrumentoMusicale(nuovoStrumentoMusicale.Nome, nuovoStrumentoMusicale.Descrizione, nuovoStrumentoMusicale.Foto, nuovoStrumentoMusicale.Prezzo, nuovoStrumentoMusicale.QuantitaStrumento);

                db.StrumentoMusicale.Add(StrumentoDaCreare);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        //---------------------DETTAGLI---------------------------------


        [HttpGet]
        public IActionResult Details(int id)
        {


            StrumentoMusicale? SmFound = null;
            using (MusicContext db = new MusicContext())
            {
                SmFound = db.StrumentoMusicale
                    .Where(StrumentoMusicale => StrumentoMusicale.Id == id)
                    .FirstOrDefault();


            }

            if (SmFound != null)
            {
                return View("Details", SmFound);
            }
            else
            {
                return NotFound("Lo Strumento Musicale  con id " + id + " non è stato trovato");
            }

        }


            [HttpGet]
            public IActionResult Update(int id)
            {


                StrumentoMusicale? SmFound = null;
                using (MusicContext db = new MusicContext())
                {
                    SmFound = db.StrumentoMusicale
                        .Where(StrumentoMusicale => StrumentoMusicale.Id == id)
                        .FirstOrDefault();


                }

                if (SmFound != null)
                {
                    return View("Update", SmFound);
                }
                else
                {
                    return NotFound("Lo Strumento Musicale  con id " + id + " non è stato trovato");
                }

            }
    }
}
