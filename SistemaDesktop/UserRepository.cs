using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDesktop
{
    public class UserRepository
    {
        //static permite que estas duas propriedades exista somente uma vez na memória
        private static List<Usuarios> usuarios;
        private static int contador = 1;
        public UserRepository()
        {
            if(usuarios == null)
            {
                usuarios = new List<Usuarios>();

                Usuarios usuario = new Usuarios
                {
                    id = 0,
                    Nome = "Andre",
                    Sobrenome = "Mattos",
                    Endereco = "Rua random",
                    Numero = "2",
                    Usuario = "aMattos",
                    Nascimento = new DateTime(1999,04, 02),
                    Senha = "123@Senai",
                    ConfirmarSenha = "123@Senai",
                    Admin = false
                };
                usuarios.Add(usuario);

                Usuarios usuarioAdmin = new Usuarios
                {
                    id = 1,
                    Nome = "Rosana",
                    Sobrenome = "Stávia",
                    Endereco = "Avenida Random",
                    Numero = "9",
                    Usuario = "rStavia",
                    Nascimento = new DateTime(1970, 04, 02),
                    Senha = "123@Senai",
                    ConfirmarSenha = "123@Senai",
                    Admin = true
                };
                usuarios.Add(usuarioAdmin);
            }
        }

        public List<Usuarios> Listar()
        {
            return usuarios;
        }


        public void Adicionar(Usuarios usuario)
        {
            usuario.id = contador;
            usuarios.Add(usuario);
            contador++;

        }


        public void deletar(int id)
        {
            Usuarios user = usuarios.Find(x => x.id == id);
            usuarios.Remove(user);
        }
        public void editar(Usuarios usuario)
        {
            Usuarios user = usuarios.Find(u => u.id == usuario.id);
            int position = usuarios.IndexOf(user);
            usuarios[position] = usuario;
        }
    }
}
