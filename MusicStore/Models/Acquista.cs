using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Acquista
    {
        

        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(1, 50, ErrorMessage = "Il massimo numero di strumenti che è possibile acquistare e' 50")]
        public int Quantita { get; set; }

        //----------

        public StrumentoMusicale? strumentoMusicale { get; set; }

        public int StrumentoMusicaleId { get; set; }

        public Acquista()
        {

        }

        /*
        public Acquista(int quantita)
        {
            Quantita = quantita;
            Data = DateTime.Now;

        }
        */
    }
}
