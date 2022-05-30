﻿using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicContext : DbContext
    {
        public DbSet<StrumentoMusicale> StrumentoMusicale { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Acquista> Acquista { get; set; }
        public DbSet<Rifornisci> Rifornisci { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Database_MusicStore;Integrated Security=True");
        }

    }
}
