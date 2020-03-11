using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("Pacotes")]
    public class Pacotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPacote { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "Nome do usuário é um campo obrigatório!")]
        public string NomePacote { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Indicar uma descrição é obrigatório.")]
        public string Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Indique uma data de partida.")]
        public DateTime DataIda { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Indique uma data de retorno.")]
        public DateTime DataVolta { get; set; }

        [Column(TypeName = "DECIMAL")]
        [Required(ErrorMessage = "O preço é um valor obrigatório..")]
        public decimal Valor { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Indique se o pacote está ativo.")]
        public bool Ativo { get; set; }

        [Column(TypeName ="VARCHAR(255)")]
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        public string NomeCidade { get; set; }
        
    }
}
