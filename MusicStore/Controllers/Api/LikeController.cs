using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddLikeToInstruments (Liked data)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest("Lo strumento inviato non è corretto");

            } else
            {
                StrumentoMusicale? strumentoTrovato = new StrumentoMusicale();

                using(MusicContext database = new MusicContext())
                {
                    strumentoTrovato = database.StrumentoMusicale.Find(data.InstrumentId);

                    if (strumentoTrovato != null)
                    {
                        strumentoTrovato.NumeroLike++;
                        database.SaveChanges();
                    } else
                    {
                        return BadRequest("Lo strumento inviato non è corretto");
                    }

                }

                return Ok();
            }
        }
    }
}
