using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeskoWeb.Domain.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Por favor, nos informe seu e-mail de contato"), EmailAddress]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Informe o motivo do contato")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Digite uma mensagem para entendermos melhor o motivo de seu contato")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Por favor, nos informe seu nome")]
        public string Name { get; set; }
    }
}
