using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome della categoria non può superare i 50 caratteri")]
        public string nomeCategoria { get; set; }


        public List<StrumentoMusicale> StrumentiMusicali { get; set; }

        public Categoria()
        {

        }

    }
}