using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Utente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo 'Nome' è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il 'Nome' non può avere più di 50 caratteri")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Il campo 'Quantità' è obbligatorio")]
        [Range(1,10,ErrorMessage ="Puoi acquistare un minimo di 1 prodotto/massimo di 10 prodotti")]
        public int quantità { get; set; }

        public DateTime Data { get; set; }

        public List<StrumentoMusicale> StrumentiMusicaliUtente { get; set; }

        public Utente()
        {
        
        }

        public Utente(string nome ,DateTime data)
        {
            this.Nome = nome;
            this.Data = DateTime.Now;
        }


    }
}
