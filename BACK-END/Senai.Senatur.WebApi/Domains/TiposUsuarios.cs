using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "Definir um tipo de usuário é obrigatório.")]
        public string Titulo { get; set; }
       
    }
}
