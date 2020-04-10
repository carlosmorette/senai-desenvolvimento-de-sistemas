using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "Email obrigatorio")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha Obrigatoria !")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
