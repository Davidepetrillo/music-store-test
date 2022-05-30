using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Rifornisci
    {

        [Key]
        public int Id { get; set; }

        DateTime data;

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome della categoria non può superare i 50 caratteri")]
        
        public int quantita { get; set; }

        public Rifornisci()
        {

        }
        public Rifornisci(int quantità,DateTime data)
        {
            this.data = data;
            data=DateTime.Now;
        }
    }
}
