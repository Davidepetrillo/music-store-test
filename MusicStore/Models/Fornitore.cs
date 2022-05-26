using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Fornitore
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del fornitore è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome del fornitore non può avere più di 50 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La data dell'acquisto è obbligatoria")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "La quantità da acquistare è obbligatoria")]
        [Range(1,20, ErrorMessage ="Il numero inserito non rientra nel range disponibile (1,20)")]
        public int Quantità { get; set; }


        public Fornitore()
        {

        }

        public Fornitore(int id, string name, DateTime data, int quantità)
        {
            this.Id = id;
            this.Name = name;
            this.Data = DateTime.Now;
            this.Quantità = quantità;
        }

    }
}
