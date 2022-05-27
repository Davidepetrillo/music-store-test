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
                StrumentiMusicali = db.StrumentoMusicale.Include(StrumentiMusicali => StrumentiMusicali.Categoria).ToList<StrumentoMusicale>();

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
                
                StrumentoDaCreare.CategoriaId = nuovoStrumentoMusicale.CategoriaId;
               
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
                    .Where(strumento => strumento.Id == id)
                    .Include(strumento => strumento.Categoria)
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

        //--------------------------MODIFICA--------------------------------
        [HttpGet]
        public IActionResult Update(int id)
        {
            StrumentoMusicale? SmFound = null;
            using (MusicContext db = new MusicContext())
            {
                SmFound = db.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    .Include(strumento => strumento.Categoria)
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

        [HttpPost]
        public IActionResult Update(int id, StrumentoMusicale model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            StrumentoMusicale? strumentoDaModificare = null;

            using (MusicContext context = new MusicContext())
            {
                strumentoDaModificare = context.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    .FirstOrDefault();

                if (strumentoDaModificare != null)
                {
                    strumentoDaModificare.Nome = model.Nome;
                    strumentoDaModificare.Descrizione = model.Descrizione;
                    strumentoDaModificare.Foto = model.Foto;
                    strumentoDaModificare.Prezzo = model.Prezzo;
                    strumentoDaModificare.CategoriaId = model.CategoriaId;

                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        //---------------------------ELIMINA-----------------------------------
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (MusicContext context = new MusicContext())
            {
                StrumentoMusicale? strumentoDaEliminare = context.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    .FirstOrDefault();

                if (strumentoDaEliminare != null)
                {
                    context.StrumentoMusicale.Remove(strumentoDaEliminare);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}