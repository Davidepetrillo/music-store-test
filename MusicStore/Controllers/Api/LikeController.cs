using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddLikeToInstruments([FromBody] StrumentoMusicale data)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            } 
            else
            {
                StrumentoMusicale? smFound = new StrumentoMusicale();

                using(MusicContext database = new MusicContext())
                {
                     smFound = database.StrumentoMusicale
                    .Where(strumento => strumento.Id == data.Id)
                    .FirstOrDefault();

                    if (smFound != null)
                    {
                        smFound.NumeroLike++;
                        database.SaveChanges();

                        return Ok();

                    } 
                    else
                    {
                        return BadRequest("Lo strumento inviato non è corretto");
                    }

                }

                
            }
        }
    }
}
