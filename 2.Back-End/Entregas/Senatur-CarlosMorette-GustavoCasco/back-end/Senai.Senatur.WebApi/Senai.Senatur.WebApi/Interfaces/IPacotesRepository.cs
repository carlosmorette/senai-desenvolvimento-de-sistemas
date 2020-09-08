using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> Listar();

        void Cadastrar(Pacotes novoPacote);

        void Atualizar(int id, Pacotes attPacote);

        void Deletar(int Id);

        Pacotes BuscarPorId(int id);

        List<Pacotes> BuscarAtivo();

        List<Pacotes> BuscarInativo();

        List<Pacotes> BuscarCidade(string nomeCidade);

        List<Pacotes> ListaOrdenadaMaiorMenor();

        List<Pacotes> ListaOrdenadoMenorMaior();
    }
}
