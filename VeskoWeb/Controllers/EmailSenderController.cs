using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VeskoWeb.Domain.Models;
using VeskoWeb.Domain.Services;

namespace VeskoWeb.Controllers
{
    public class EmailSenderController : Controller
    {
        private readonly IEmailSender _emailSender;
        public EmailSenderController(IEmailSender emailSender, IHostingEnvironment env)
        {
            _emailSender = emailSender;
        }
        public IActionResult EnviarEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarEmail(Email email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.CustomerEmail, email.Subject, email.Message, email.Name).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }
        public async Task TesteEnvioEmail(string email, string assunto, string mensagem, string name)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar
                await _emailSender.SendEmailAsync(email, assunto, mensagem, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult EmailEnviado()
        {
            return View();
        }
        public ActionResult EmailFalhou()
        {
            return View();
        }
    }
}