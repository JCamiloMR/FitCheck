using System.ComponentModel.DataAnnotations;

namespace FitCheck.Models.ViewModels
{
    public class UsuarioRegistrationViewModel
    {
        [Required]
        [Range(10000, 9999999999, ErrorMessage = "La cédula debe tener entre 5 y 10 dígitos.")]
        public long Cedula { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Contrasena { get; set; } = null!;

        [Required]
        [Range(16, 100, ErrorMessage = "La edad debe ser entre 16 y 100 años.")]

        public int Edad { get; set; }

        [Required]
        public string? Rol { get; set; }

    }
}
