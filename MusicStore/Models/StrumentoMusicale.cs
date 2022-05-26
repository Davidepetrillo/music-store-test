using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class StrumentoMusicale
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Nome strumento maggiore di 50 parole")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column(TypeName= "text")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Url(ErrorMessage = "URL non valido")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(20, 10000, ErrorMessage = "Lo strumento non puo' costare meno di 20 euro")]
        public double Prezzo { get; set; }


        public int QuantitaStrumento { get; set; }


        public int NumeroLike { get; set; }

        public StrumentoMusicale()
        {

        }

        public StrumentoMusicale(string nome, string descrizione, string foto, double prezzo, int quantitaStrumento)
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Foto = foto;
            this.Prezzo = prezzo;
            this.QuantitaStrumento = quantitaStrumento;
        }
    }
}
