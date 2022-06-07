using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MusicStore.Validate
{
    public class VaidationPassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(
               object value, ValidationContext validationContext)
        {
            string password = (string)value;

            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult("Password non puo' essere vuota o con gli spazi!");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(password))
            {
                return new ValidationResult("La password deve contenere almeno una lettera minuscola");
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                return new ValidationResult("La password deve contenere almeno una lettera maiuscola");

            }
            else if (!hasMiniMaxChars.IsMatch(password))
            {
                return new ValidationResult("La password non puo' essere piu' corta di 8 o maggiore di 15 caratteri.");

            }
            else if (!hasNumber.IsMatch(password))
            {
                return new ValidationResult("La password deve contenere almeno un numero.");

            }

            else if (!hasSymbols.IsMatch(password))
            {
                return new ValidationResult("La password deve contenere almeno un carattere speciale.");

            }
            else
            {
                return ValidationResult.Success;

            }
        }
    }
}
