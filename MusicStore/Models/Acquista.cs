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
        public int Quantita { get; set; }

        //----------

        public StrumentoMusicale strumentoMusicale { get; set; }
        public int? StrumentoMusicaleId { get; set; }



        public Acquista(int quantita)
        {
            Quantita = quantita;
            Data = DateTime.Now;

        }
    }
}
