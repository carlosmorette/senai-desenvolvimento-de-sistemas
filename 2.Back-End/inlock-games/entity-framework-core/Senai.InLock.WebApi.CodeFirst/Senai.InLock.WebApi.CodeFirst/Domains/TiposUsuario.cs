using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    // Define o nome da tabela
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        // Definindo que será uma chave primária
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Dizemos o que o id é uma chave primaria e auto incremento
        public int IdTipoUsuario { get; set; }

        // Define o tipo do dado
        [Column(TypeName = "VARCHAR (255)")]
        // Define que a propriedade é obrigatório
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        public string Titulo { get; set; }
    }
}
