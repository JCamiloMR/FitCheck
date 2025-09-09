using FitCheck.Models;
using FitCheck.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace FitCheck.Controllers
{

    [Route("Usuario")]
    public class UserLoginController : Controller
    {

        private readonly FitCheckContext _context;

        public UserLoginController(FitCheckContext context)
        {
            _context = context;
        }


        [HttpGet("Login")]
        public ActionResult Index()
        {

            if(User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Index(UsuarioLoginViewModel model)
        {

            try
            {
                if (!ModelState.IsValid) return View(model);

                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email && u.Contrasena == model.Contrasena);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                    return View(model);
                }
                else
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Rol!)
                };

                    var identity = new ClaimsIdentity(claims, "Cookies");
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("Cookies", principal);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch(SqlException ex)
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



        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Index", "Home");
        }
    }
}
