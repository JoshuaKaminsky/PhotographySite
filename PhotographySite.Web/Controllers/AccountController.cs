using System;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Photography.Core.Contracts.Service;
using PhotographySite.Authorization;
using PhotographySite.Models;

namespace PhotographySite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISessionService _sessionService;

        private readonly IUserService _userService;

        public AccountController(ISessionService sessionService, IUserService userService)
        {
            _sessionService = sessionService;
            _userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!_userService.ValidateUser(model.EmailAddress, model.Password))
            {
                throw new AuthenticationException();
            }

            var user = _userService.GetUserByEmailAddress(model.EmailAddress);
            if (user == null)
            {
                throw new AuthenticationException();
            }

            var session = _sessionService.CreateSession(user.Id);

            var cookie = FormsAuthentication.GetAuthCookie(user.Name, model.RememberMe);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var newTicket = new FormsAuthenticationTicket(
                            ticket.Version,                                     
                            ticket.Name,                              
                            ticket.IssueDate,                          
                            ticket.Expiration,           
                            ticket.IsPersistent,
                            JsonConvert.SerializeObject(new SessionModel{SessionKey = session.SessionKey, UserId = user.Id}),                              
                            ticket.CookiePath);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(newTicket)) { HttpOnly = true });

            if (Url.IsLocalUrl(model.ReturnUrl) && model.ReturnUrl.Length > 1 && model.ReturnUrl.StartsWith("/") && !model.ReturnUrl.StartsWith("//") && !model.ReturnUrl.StartsWith("/\\"))
            {
                return Redirect(model.ReturnUrl);
            }
            
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(int userId, string token)
        {
            Guid requestToken;
            if (!Guid.TryParse(token, out requestToken))
            {
                ModelState.AddModelError("", "Token could not be found.");
            }
            else if (_userService.ValidatePasswordReset(userId, requestToken))
            {
                return View(new ResetPasswordModel {UserId = userId, Token = requestToken});
            }
                
            return RedirectToAction("ResetPasswordInvalid");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (model.Password != model.PasswordConfirmation)
            {
                throw new ArgumentException("Password confirmation does not match password.");
            }

            if (!_userService.ValidatePasswordReset(model.UserId, model.Token))
            {
                throw new ArgumentException("Invalid password reset request.");
            }

            _userService.ResetPassword(model.UserId, model.Password);

            var user = _userService.GetUser(model.UserId);

            return Login(new LoginModel { EmailAddress = user.EmailAddress, Password = model.Password, RememberMe = false });
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordInvalid()
        {
            return View();
        }

        public ActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassword(UpdatePasswordModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
