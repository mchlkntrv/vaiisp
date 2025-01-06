using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Meno je povinné.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Meno musí mať 2-50 znakov.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Priezvisko je povinné.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Priezvisko musí mať 2-50 znakov.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Používateľské meno je povinné.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Používateľské meno musí mať 3-50 znakov.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail je povinný.")]
        [EmailAddress(ErrorMessage = "Neplatný formát e-mailu.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Heslo je povinné.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Heslo musí mať aspoň 8 znakov.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Potvrďte heslo.")]
        [Compare("Password", ErrorMessage = "Heslá sa nezhodujú.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

}
