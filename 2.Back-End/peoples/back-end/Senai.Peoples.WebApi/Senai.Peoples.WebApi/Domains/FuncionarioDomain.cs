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

<<<<<<< HEAD
        // Define que a propriedade nome é obrigatória
        [Required(ErrorMessage ="Nome é obrigatório!")]
=======
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Passou do limite")]
>>>>>>> d6a74a6302760a5828be2ec7bba0131e53eda7f2
        public string Nome { get; set; }

        // Adiciona um tipo de dado adicional
        [DataType(DataType.Date)]
        public string Sobrenome { get; set; }
    }
}
