using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    [NotMapped]
    public class AcquistoStrumento
    {
        public string nomeStrumento { get; set; }

        public int quantitaAcquistata { get; set; }

        public AcquistoStrumento()
        {

        }



    }

   
}
