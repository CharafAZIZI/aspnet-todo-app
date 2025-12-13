using Microsoft.AspNetCore.Mvc;
using ToDo.Filters;
using ToDo.Mappers;
using ToDo.Models;
using ToDo.Services;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    public class AuthController : Controller
    {
        private readonly ISessionManagerService session;

        public AuthController(ISessionManagerService session)
        {
            this.session = session;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (vm.MotDePasse != vm.ConfirmationMotDePasse)
            {
                ModelState.AddModelError("", "Les mots de passe ne correspondent pas.");
                return View();
            }

            List<User> users = session.Get<List<User>>("users", HttpContext);

            if (users.Any(u => u.Identifiant == vm.Identifiant))
            {
                ModelState.AddModelError("", "Cet utilisateur existe déjà.");
                return View();
            }

            User user = UserMapper.FromRegisterVM(vm);

            users.Add(user);
            session.Add("users", users, HttpContext);

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            List<User> users = session.Get<List<User>>("users", HttpContext);

            User user = users.FirstOrDefault(u =>
                u.Identifiant == vm.Identifiant && u.MotDePasse == vm.MotDePasse);

            if (user == null)
            {
                ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe incorrect.");
                return View();
            }

            session.Add("userLogged", user, HttpContext);

            return RedirectToAction(nameof(Index), "Todos");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userLogged");
            return RedirectToAction(nameof(Login));
        }
    }
}
