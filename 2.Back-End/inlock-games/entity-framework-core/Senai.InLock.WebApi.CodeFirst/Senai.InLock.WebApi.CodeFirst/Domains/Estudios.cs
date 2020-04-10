using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    [Table("Etudios")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudio { get; set; }

        [Column(TypeName = "VARCHAR (15)")]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string NomeEstudio { get; set; }


        public List<Jogos> Jogos { get; set; }
    }
}
