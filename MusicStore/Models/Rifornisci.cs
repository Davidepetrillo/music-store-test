using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicStore.Models
{
    public class Rifornisci
    {

        [Key]
        public int Id { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(50, ErrorMessage = "Nome rifornitore maggiore di 50 parole")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(1, 50, ErrorMessage = "Il massimo numero di strumenti e' 50")]
        public int Quantita { get; set; }

        //----------
        
        public StrumentoMusicale strumentoMusicale { get; set; } 
        
        public int? StrumentoMusicaleId { get; set; }

        public Rifornisci()
        {

        }

        /*public Rifornisci(int quantita, string nome, DateTime data, int? strumentoMusicaleId)
        {
            Quantita = quantita;
            Data=data;
            Nome = nome;
            StrumentoMusicaleId = strumentoMusicaleId;    


        }
        */
    }
}
