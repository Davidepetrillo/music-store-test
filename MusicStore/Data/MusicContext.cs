using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicContext : DbContext
    {
        DbSet<StrumentoMusicale> StrumentoMusicale { get; set; }
        DbSet<Utente> Utente { get; set; }
        DbSet<Fornitore> Fornitore { get; set; }
        DbSet<Categoria> Categoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Database_MusicStore;Integrated Security=True");
        }

    }
}
