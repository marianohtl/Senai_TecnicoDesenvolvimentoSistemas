using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Contexts
{
    public class SenaturContext : DbContext
    {

        public DbSet<Pacotes> Pacotes { get; set; }
        public DbSet<TiposUsuarios> TipoUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-7C6K4DAQ\\SQLEXPRESS; Database=Senatur_Manha;user Id=sa; pwd=sa@132;");
            //optionsBuilder.UseSqlServer("Server=DESKTOP-GCOFA7F\\SQLEXPRESS; Database=InLock_Games_CodeFirst; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasData(
                    new Pacotes
                    {
                        IdPacote = 1,
                        NomePacote = "SALVADOR - 5 DIAS / 4 DIÁRIAS",
                        Descricao = "O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que acredenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros.O Pelourinho e o Elevador são alguns dos principais pontos de visitação",
                        DataIda = Convert.ToDateTime("06/08/2020"),
                        DataVolta = Convert.ToDateTime("10/08/2020"),
                        Valor = Convert.ToDecimal("854,00"),
                        NomeCidade = "Salvador",
                        Ativo = true

                    },
                    new Pacotes
                    {
                        IdPacote = 2,
                        NomePacote = "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS",
                        Descricao = "O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.",
                        DataIda = Convert.ToDateTime("14/05/2020"),
                        DataVolta = Convert.ToDateTime("18/05/2020"),
                        Valor = Convert.ToDecimal("1826,00"),
                        NomeCidade = "Salvador",
                        Ativo = true

                    },
                    new Pacotes
                    {
                        IdPacote = 3,
                        NomePacote = "- BONITO VIA CAMPO GRANDE - DIÁRIAS",
                        Descricao = "O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.",
                        DataIda = Convert.ToDateTime("28/05/2020"),
                        DataVolta = Convert.ToDateTime("18/05/2020"),
                        Valor = Convert.ToDecimal("1004,00"),
                        NomeCidade = "Bonito",
                        Ativo = true

                    });
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                    entity.HasData(
                    new TiposUsuarios
                    {
                        TipoUsuario = 1,
                        Titulo = "ADMINISTRADOR"
                    },
                    new TiposUsuarios
                    {
                    TipoUsuario = 2,
                    Titulo = "CLIENTE"
                    });
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                    entity.HasData(
                    new Usuarios
                    {
                        IdUsuario = 1,
                        IdTipoUsuario = 1,
                        Titulo = "ADMINISTRADOR",
                        Email = "admin@admin.com",
                        Senha = "admin"
                    },
                   new Usuarios
                   {
                       IdUsuario = 2,
                       IdTipoUsuario = 2,
                       Titulo = "CLIENTE",
                       Email = "cliente@cliente.com",
                       Senha = "cliente"
                   });
            });
         }
    }
}
