using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela Generos
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        // Biblioteca: DataAnnotations
        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Nome { get; set; }
    }
}
