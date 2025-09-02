using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitCheck.Controllers
{

    [Authorize(policy:"EmpleadoOnly")]
    [Route("Empleado")]
    public class EmpleadoHomeController : Controller
    {
        // GET: EmpleadoHomeController
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
