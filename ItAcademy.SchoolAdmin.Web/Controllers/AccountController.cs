using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;
using ItAcademy.SchoolAdmin.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    [Authorize]
    public partial class AccountController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        [AllowAnonymous]
        public virtual ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<ActionResult> Login(LoginModel model)
        {
            ////await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError(" ", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(
                        new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public virtual ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterModel model)
        {
            ////await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }

            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(
                new UserDTO
                {
                    Email = "mail@mail.ru",
                    UserName = "mail@mail.ru",
                    Password = "mail@mail.ru",
                    Name = "Иван Иванович Петров",
                    Address = "Адрес",
                    Role = "admin",
                }, new List<string> { "user", "admin" });
        }
    }
}