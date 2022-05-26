using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Utente
    {
        [Key]
        public int id;

        [Required(ErrorMessage = "Il campo 'Nome' è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il 'Nome' non può avere più di 50 caratteri")]
        public string nome;


        [Required(ErrorMessage = "Il campo 'Quantità' è obbligatorio")]
        [Range(1,10,ErrorMessage ="Puoi acquistare un minimo di 1 prodotto/massimo di 10 prodotti")]
        public int quantità;


        public DateTime data;

        public Utente()
        {
        
        }

        public Utente(int id, string nome ,DateTime data)
        {
            this.id = id;
            this.nome = nome;
            this.data = DateTime.Now;
        }


    }
}
