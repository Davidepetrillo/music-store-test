using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class LoginAdmin
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
