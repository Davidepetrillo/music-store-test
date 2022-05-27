using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            List<StrumentoMusicale> struments = new List<StrumentoMusicale>();

            using (MusicContext context = new MusicContext())
            {
                struments = context.StrumentoMusicale
                    .ToList<StrumentoMusicale>();

                return Ok(struments);
            }
        }
    }
}
