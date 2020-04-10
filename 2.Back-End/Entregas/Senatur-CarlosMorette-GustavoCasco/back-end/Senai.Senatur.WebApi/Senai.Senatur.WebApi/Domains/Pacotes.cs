using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Pacotes
    {
        public int IdPacote { get; set; }

        [Required(ErrorMessage = "Nome do pacote obrigatório !")]
        
        public string NomePacote { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória")]
        public string Descricao { get; set; }


        public DateTime? DataIda { get; set; }


        public DateTime? DataVolta { get; set; }


        public decimal? Valor { get; set; }


        public bool? Ativo { get; set; }

        [Required(ErrorMessage = "Nome da cidade obrigatorio")]
        public string NomeCidade { get; set; }
    }
}
