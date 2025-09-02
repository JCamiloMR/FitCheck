using System;
using System.Collections.Generic;

namespace FitCheck.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Cedula { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? Edad { get; set; }

    public string? Rol { get; set; }
}
