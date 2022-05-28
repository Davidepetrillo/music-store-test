using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                List<StrumentoMusicale> strumentiMusicali = db.StrumentoMusicale.ToList();
                List<Categoria> categorie = db.Categoria.ToList();
                
                return View("Index", strumentiMusicali);
            }

        }

        //-----------------------------CREA------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            using(MusicContext db = new MusicContext())
            {
                List<Categoria> categorias = db.Categoria.ToList();

                CategoriaStrumento model = new CategoriaStrumento();
                model.StrumentiMusicali = new StrumentoMusicale();
                model.Categorie = categorias;

                return View("Create", model); 
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaStrumento nuovoStrumentoMusicale)
        {
            if (!ModelState.IsValid)
            {
                using (MusicContext db = new MusicContext())
                { 
                    nuovoStrumentoMusicale.Categorie = db.Categoria.ToList();

                    return View("Create", nuovoStrumentoMusicale);

                }
                
            }

            using (MusicContext db = new MusicContext())
            {
               StrumentoMusicale StrumentoDaCreare = new StrumentoMusicale();
                StrumentoDaCreare.Nome = nuovoStrumentoMusicale.StrumentiMusicali.Nome;
                StrumentoDaCreare.Descrizione = nuovoStrumentoMusicale.StrumentiMusicali.Descrizione;
                StrumentoDaCreare.Foto = nuovoStrumentoMusicale.StrumentiMusicali.Foto;
                StrumentoDaCreare.Prezzo = nuovoStrumentoMusicale.StrumentiMusicali.Prezzo;
                StrumentoDaCreare.QuantitaStrumento = nuovoStrumentoMusicale.StrumentiMusicali.QuantitaStrumento;
                StrumentoDaCreare.CategoriaId = nuovoStrumentoMusicale.StrumentiMusicali.CategoriaId;
               
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
            List<Categoria> categorias = new List<Categoria>();

            using (MusicContext db = new MusicContext())
            {
                SmFound = db.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    .FirstOrDefault();

                categorias = db.Categoria.ToList<Categoria>();
            }

            if (SmFound != null)
            {
                CategoriaStrumento model = new CategoriaStrumento();
                model.StrumentiMusicali = SmFound;
                model.Categorie = categorias;

                return View("Update", model);
            }
            else
            {
                return NotFound("Lo Strumento Musicale  con id " + id + " non è stato trovato");
            }

        }

        [HttpPost]
        public IActionResult Update(int id, CategoriaStrumento model)
        {
            if (!ModelState.IsValid)
            {
                using(MusicContext db = new MusicContext())
                {
                    List<Categoria> categorias = db.Categoria.ToList();

                    model.Categorie = categorias;
                }
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
                    strumentoDaModificare.Nome = model.StrumentiMusicali.Nome;
                    strumentoDaModificare.Descrizione = model.StrumentiMusicali.Descrizione;
                    strumentoDaModificare.Foto = model.StrumentiMusicali.Foto;
                    strumentoDaModificare.Prezzo = model.StrumentiMusicali.Prezzo;
                    strumentoDaModificare.CategoriaId = model.StrumentiMusicali.CategoriaId;

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