using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [RoutePrefix("account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AuthenticationService _service;

        public AccountController(AuthenticationService service)
        {
            _service = service;
        }

        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel user)
        {
            _service.Login(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            _service.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}