using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using System.Linq;

namespace MusicStore.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StrumentsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string? searchString)
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
                else
                {
                    struments = context.StrumentoMusicale.ToList<StrumentoMusicale>();
                }

                return Ok(struments);
            }
        }

        [HttpGet]
        public IActionResult GetClassifica()
        {

            using(MusicContext context = new MusicContext())
            {
                var acquistoStrumento = context.acquistaStrumento.FromSqlRaw("SELECT StrumentoMusicale.Nome AS nomeStrumento, SUM(quantita) AS quantitaAcquistata, StrumentoMusicale.Foto AS fotoStrumento FROM StrumentoMusicale INNER JOIN Acquista ON StrumentoMusicale.Id = Acquista.StrumentoMusicaleId WHERE MONTH(Acquista.Data) > MONTH(DATEADD(month, -1, GETDATE())) GROUP BY StrumentoMusicale.Id, StrumentoMusicale.Nome, StrumentoMusicale.Foto ORDER BY quantitaAcquistata DESC").ToList();

                return Ok(acquistoStrumento);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StrumentoMusicale), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Details(int id)
        {
            //Troviamo l'id corrispondente allo strumento con lo stesso id
            //Ritorniamo quello strumento oppure NOTFOUND
            using (MusicContext context = new MusicContext())
            {
                StrumentoMusicale? strumentToFound = context.StrumentoMusicale
                    .Where(strument => strument.Id == id)
                    .Include(strument => strument.Categoria)
                    .FirstOrDefault();

                if (strumentToFound == null)
                    return NotFound();
                else
                    return Ok(strumentToFound);
            }
        }


        [HttpPost("{id}")]
        [ProducesResponseType(typeof(Acquista), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AcquistaStrumento([FromBody] Acquista model, int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            using (MusicContext db = new MusicContext())
            {
                StrumentoMusicale? smFound = db.StrumentoMusicale
                    .Where(strumento => strumento.Id == id)
                    .FirstOrDefault();

                Acquista acquista = new Acquista();

                acquista.StrumentoMusicaleId = model.StrumentoMusicaleId;
                acquista.Quantita = model.Quantita;
                acquista.Data = model.Data;
                smFound.QuantitaStrumento -= model.Quantita;

                db.Add(acquista);
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
