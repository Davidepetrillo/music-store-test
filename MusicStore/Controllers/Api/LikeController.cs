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
        public IActionResult AddLikeToInstruments(Liked data)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            } 
            else
            {
                using(MusicContext database = new MusicContext())
                {
                    StrumentoMusicale? smFound = new StrumentoMusicale();
                    smFound = database.StrumentoMusicale.Find(data.StrumentoMusicaleId);

                    if (smFound != null)
                    {
                        if(data.Status == false)
                        {
                            smFound.NumeroLike++;
                        }
                        else
                        {
                            smFound.NumeroLike--;
                        }   
                    }   
                    database.SaveChanges(); 
                }
                return Ok();
            }
        }
    }
}
