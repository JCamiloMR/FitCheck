using FitCheck.Models;
using FitCheck.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FitCheck.Controllers
{
    [Route("Usuario/Register")]
    public class UserRegistrationController : Controller
    {
        private readonly FitCheckContext _context;

        public UserRegistrationController(FitCheckContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Create")]
        public IActionResult Create()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioRegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hasher = new PasswordHasher<Usuario>();
                    var user = new Usuario()
                    {
                        Nombre = model.Nombre,
                        Cedula = model.Cedula.ToString(),
                        Email = model.Email.ToLower(),
                        Edad = model.Edad,
                        Rol = model.Rol
                    };

                    user.Contrasena = hasher.HashPassword(user, model.Contrasena);

                    if (await UserAlreadyExists(model.Cedula.ToString(), model.Email))
                    {
                        ModelState.AddModelError(string.Empty, "El usuario ya existe");
                        return View(model);
                    }
                    else
                    {
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "UserLogin");
                    }
                }

                return View(model);
            }
            catch (SqlException)
            {
                ModelState.AddModelError(string.Empty, "Error de conexión a la base de datos");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado: " + ex.Message);
                return View(model);
            }
            
        }

        public async Task<bool> UserAlreadyExists(string cedula, string email)
        {
            var users = await _context.Usuarios.FirstOrDefaultAsync(c => c.Cedula == cedula || c.Email == email);

            if(users != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
