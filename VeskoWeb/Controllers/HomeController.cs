using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using VeskoWeb.Domain.Models;
using VeskoWeb.Domain.Services;
using VeskoWeb.Models;

namespace VeskoWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailSender _emailSender;
        public HomeController(IEmailSender emailSender, IHostingEnvironment env)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index([FromServices]IGenericService<TeamMember> teamSvc, [FromServices]IGenericService<Customer> customerSvc)
        {
            CommonViewModel viewModel = new CommonViewModel();
            viewModel.Team = teamSvc.GetAll();
            viewModel.Customers = customerSvc.GetAll();

            return View(viewModel);
        }       

        [HttpPost]
        public IActionResult Index([FromServices]IGenericService<TeamMember> teamSvc, [FromServices]IGenericService<Customer> customerSvc, CommonViewModel model)
        {
            model.Team = teamSvc.GetAll();
            model.Customers = customerSvc.GetAll();

            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(model.Email.CustomerEmail, model.Email.Subject, model.Email.Message, model.Email.Name).GetAwaiter();
                    model.StatusModel = "true";
                    View("Index", model);
                }
                catch (Exception ex)
                {
                    model.StatusModel = "error";
                    View("Index", model);
                }
            }else
            {
                model.StatusModel = "false";
            }
            return View("Index", model);
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
       
    }
}
