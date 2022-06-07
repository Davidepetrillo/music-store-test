using MusicStore.Validate;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class LoginAdmin
    {
        [Key]
        public string UserName { get; set; }
        
        [Required]
        [VaidationPassword]
        public string Password { get; set; }
    }
}
