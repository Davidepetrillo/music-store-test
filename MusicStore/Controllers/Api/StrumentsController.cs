using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StrumentsController : ControllerBase
    {
        [HttpGet] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string? searchString, int? id)
        {
            List<StrumentoMusicale> struments = new List<StrumentoMusicale>();

            using (MusicContext context = new MusicContext())
            {
                if (searchString != null && searchString != "")
                {
                    struments = context.StrumentoMusicale
                    .Include(strument => strument.Categoria)
                    .Where(strument => strument.Nome.Contains(searchString)
                    || strument.Descrizione.Contains(searchString) 
                    || strument.Categoria.nomeCategoria.Contains(searchString))
                    .ToList<StrumentoMusicale>();
                }
                else if (id != null)
                {
                        StrumentoMusicale dettaglioStrumento = context.StrumentoMusicale
                        .Where(strumento => strumento.Id == id)
                        .First();
                        return Ok(dettaglioStrumento);
                } else
                {
                    struments = context.StrumentoMusicale.ToList<StrumentoMusicale>();
                }
                

                return Ok(struments);
            }
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
                    return Ok(strumentoTrovato);
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


        [HttpPost]
        public IActionResult AcquistaStrumento([FromBody] Acquista model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            using (MusicContext db = new MusicContext())
            {
                Acquista acquista = new Acquista();

                
                acquista.StrumentoMusicaleId = model.StrumentoMusicaleId;
                acquista.Quantita = model.Quantita;
                acquista.Data = model.Data;

                db.Acquista.Add(acquista);
                db.SaveChanges();
                return Ok();
            }
        }



    }
}
