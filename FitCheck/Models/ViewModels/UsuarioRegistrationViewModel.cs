using System.ComponentModel.DataAnnotations;

namespace FitCheck.Models.ViewModels
{
    public class UsuarioRegistrationViewModel
    {
        [Required]
        public string Cedula { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Contrasena { get; set; } = null!;

        [Required]
        public int Edad { get; set; }

        [Required]
        public string Rol { get; set; }

    }
}
