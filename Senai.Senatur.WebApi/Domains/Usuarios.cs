using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "A senha é um requisito obrigatório.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        [Required(ErrorMessage = "Indicar um tipo de usuário é obrigatório.")]
        public int IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuarios TipoUsuario { get; set; }

    }
}
