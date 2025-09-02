using System.ComponentModel.DataAnnotations;

namespace FitCheck.Models.ViewModels
{
    public class UsuarioLoginViewModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Contrasena { get; set; } = null!;
    }
}
