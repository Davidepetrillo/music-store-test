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
    }
}
