using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    interface IFilmesRepository
    {
        List<FilmeDomain> ListarFilme();

        FilmeDomain BuscarFilmeId(int id);

        void CadastrarFilme(FilmeDomain filme);

        void AtualizarFilme(FilmeDomain filmes);

        //void DeletarFilme(int id);
    }
}
