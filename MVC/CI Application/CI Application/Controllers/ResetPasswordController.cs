using CI_Application.Entities.CIDbContext;
using CI_Application.Entities.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using CI_Platform.Models;
using CI_Application.Models;

namespace CI_Application.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly CiPlatformContext _CiPlatformContext;

        public ResetPasswordController(CiPlatformContext CiPlatformContext)
        {
            _CiPlatformContext = CiPlatformContext;


        }
        [AllowAnonymous]
        public IActionResult Forgetpass()
        {
            return View();
        }



        public IActionResult Resetpass()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Forgetpass(ForgetModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _CiPlatformContext.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    //return RedirectToAction("Forgetpass", "ResetPassword");
                    ViewBag.RegError = "email already exist";
                    return View();
                }

                // Generate a password reset token for the user
                var token = Guid.NewGuid().ToString();

                // Store the token in the password resets table with the user's email
               var passwordReset = new PasswordReset
                {
                    Email = model.Email,
                    Token = token
                };
                _CiPlatformContext.PasswordResets.Add(passwordReset);
                _CiPlatformContext.SaveChanges();

                // Send an email with the password reset link to the user's email address
                var resetLink =Url.Action("Resetpass", "ResetPassword", new { email = model.Email, token }, Request.Scheme);
                // Send email to user with reset password link
                // ...
                var fromAddress = new MailAddress("ritugondaliya11@gmail.com", "CIPlatform");
                var toAddress = new MailAddress(model.Email);
                var subject = "Password reset request";
                var body = $"Hi,<br /><br />Please click on the following link to reset your password:<br /><br /><a href='{resetLink}'>{resetLink}</a>";
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("ritugondaliya11@gmail.com", "uuhhouquupiohcta"),
                    EnableSsl = true
                };
                smtpClient.Send(message);

                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Resetpass(string email, string token)
        {
            var passwordReset = _CiPlatformContext.PasswordResets.FirstOrDefault(pr => pr.Email == email && pr.Token == token);
            if (passwordReset == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // Pass the email and token to the view for resetting the password
            var model = new ResetPasswordView
            {
                Email = email,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Resetpass(ResetPasswordView resetPasswordView)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = _CiPlatformContext.Users.FirstOrDefault(u => u.Email == resetPasswordView.Email);
                if (user == null)
              
                
                
                
                {
                    return RedirectToAction("ForgetPassword", "Home");
                }

                // Find the password reset record by email and token
                var passwordReset = _CiPlatformContext.PasswordResets.FirstOrDefault(pr => pr.Email == resetPasswordView.Email && pr.Token == resetPasswordView.Token);
                if (passwordReset == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                // Update the user's password
                user.Password = resetPasswordView.Password;
                _CiPlatformContext.SaveChanges();

               


            }

            return View(resetPasswordView);
        }


    }

}
