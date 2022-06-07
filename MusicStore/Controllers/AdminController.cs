using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AdminController : Controller
    {
        //------------------LOGIN---------------
        [HttpGet]
        public IActionResult Login()
        {
            LoginAdmin loginModel = new LoginAdmin();

            return View("Login", loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginAdmin loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            using (MusicContext context = new MusicContext())
            {
                var status = context.LoginAdmin
                    .Where(data => data.UserName == loginModel.UserName && data.Password == loginModel.Password)
                    .FirstOrDefault();

                if (status == null)
                {
                    ViewBag.Message = "Invalid login detail.";
                }

                return RedirectToAction("Index");
            }
        }
        //-----------------------------------------------------

        [HttpGet]
        public IActionResult Index()
        {
            List<StrumentoMusicale> strumentiMusicali = new List<StrumentoMusicale>();

            using (MusicContext db = new MusicContext())
            {
               strumentiMusicali = db.StrumentoMusicale.Include(strumento => strumento.Categoria).ToList<StrumentoMusicale>();   
            }
            return View("Index", strumentiMusicali);

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
                //StrumentoDaCreare.QuantitaStrumento = nuovoStrumentoMusicale.StrumentiMusicali.QuantitaStrumento;
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
                    .Include(strumento => strumento.Rifornisci)
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
                return NotFound("Lo Strumento Musicale con id " + id + " non è stato trovato");
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
                    //strumentoDaModificare.QuantitaStrumento = model.StrumentiMusicali.QuantitaStrumento;
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
                    .Include(strumento => strumento.Rifornisci)
                    .Include(strumento => strumento.Categoria)
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



        [HttpGet]
        public IActionResult RifornisciArticolo(int id)
        {
            StrumentoMusicale? SmFound = null;
            using (MusicContext db = new MusicContext())
            {
                SmFound = db.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    
                    .FirstOrDefault();
            }

            if (SmFound != null)
            {

                return View("RifornisciArticolo");
            }
            else
            {
                return NotFound("Lo Strumento Musicale  con id " + id + " non è stato trovato");
            }
        }



        [HttpPost]
        public IActionResult RifornisciArticolo(int id,Rifornisci Model)
        {

            if (!ModelState.IsValid)
            {
                return View("RifornisciArticolo", Model);
            }

            
            
            using (MusicContext db = new MusicContext())
            {
                StrumentoMusicale SmFound = db.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    .FirstOrDefault();


                if (SmFound != null)
                {
                    Rifornisci rifornisci = new Rifornisci();
                    SmFound.QuantitaStrumento += Model.Quantita;
                    rifornisci.Quantita = Model.Quantita;
                    rifornisci.Data = DateTime.Now;
                    rifornisci.StrumentoMusicaleId = SmFound.Id;
                    
                    rifornisci.Nome = Model.Nome;
                    

                    db.Rifornisci.Add(rifornisci);
                    db.SaveChanges();

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




