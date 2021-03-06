// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicStore.Data;

#nullable disable

namespace MusicStore.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20220527132921_ModificaChiaveEsternaUtenteId")]
    partial class ModificaChiaveEsternaUtenteId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicStore.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("nomeCategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("MusicStore.Models.Fornitore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantità")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fornitore");
                });

            modelBuilder.Entity("MusicStore.Models.StrumentoMusicale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FornitoreId")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumeroLike")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.Property<int>("QuantitaStrumento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornitoreId");

                    b.ToTable("StrumentoMusicale");
                });

            modelBuilder.Entity("MusicStore.Models.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantità")
                        .HasColumnType("int");

                    b.Property<int>("StrumentoMusicaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StrumentoMusicaleId");

                    b.ToTable("Utente");
                });

            modelBuilder.Entity("MusicStore.Models.StrumentoMusicale", b =>
                {
                    b.HasOne("MusicStore.Models.Categoria", "Categoria")
                        .WithMany("StrumentiMusicali")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore.Models.Fornitore", "Fornitore")
                        .WithMany("StrumentiMusicaliFornitore")
                        .HasForeignKey("FornitoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fornitore");
                });

            modelBuilder.Entity("MusicStore.Models.Utente", b =>
                {
                    b.HasOne("MusicStore.Models.StrumentoMusicale", "StrumentoMusicale")
                        .WithMany()
                        .HasForeignKey("StrumentoMusicaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrumentoMusicale");
                });

            modelBuilder.Entity("MusicStore.Models.Categoria", b =>
                {
                    b.Navigation("StrumentiMusicali");
                });

            modelBuilder.Entity("MusicStore.Models.Fornitore", b =>
                {
                    b.Navigation("StrumentiMusicaliFornitore");
                });
#pragma warning restore 612, 618
        }
    }
}
