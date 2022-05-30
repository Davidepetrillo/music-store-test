using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicStore.Models
{
    public class Rifornisci
    {

        [Key]
        public int Id { get; set; }

        public DateTime data { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(1, 50, ErrorMessage = "Il massimo numero di strumenti e' 50")]
        public int quantita { get; set; }

        //----------
        [JsonIgnore]
        public List<StrumentoMusicale> StrumentiMusicali { get; set; }
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
