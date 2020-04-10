using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Nome obritório")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
    }
}
