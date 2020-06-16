using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDesktop
{
    public class Usuarios
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public DateTime Nascimento { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public bool Admin { get; set; }

        public string photo { get; set; }
    }
}
