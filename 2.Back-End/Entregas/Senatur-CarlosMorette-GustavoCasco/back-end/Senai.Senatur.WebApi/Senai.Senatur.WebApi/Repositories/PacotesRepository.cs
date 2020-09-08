using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();
       
        public void Atualizar(int id, Pacotes attPacotes)
        {
            Pacotes pacotesBuscado = ctx.Pacotes.Find(id);

            pacotesBuscado.NomeCidade = attPacotes.NomeCidade;

            pacotesBuscado.NomePacote = attPacotes.NomePacote;

            pacotesBuscado.Descricao = attPacotes.Descricao;

            pacotesBuscado.Valor = attPacotes.Valor;

            pacotesBuscado.Ativo = attPacotes.Ativo;

            pacotesBuscado.DataIda = attPacotes.DataIda;

            pacotesBuscado.DataVolta = attPacotes.DataVolta;

            ctx.Pacotes.Update(pacotesBuscado);

            ctx.SaveChanges();

        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Cadastrar(Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);

            ctx.SaveChanges();

        }

        public void Deletar(int Id)
        {
            Pacotes pacotesBuscado = ctx.Pacotes.Find(Id);

            ctx.Pacotes.Remove(pacotesBuscado);

            ctx.SaveChanges();

        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }

        public List<Pacotes> BuscarAtivo()
        {
            // Usamos o where
            return ctx.Pacotes.Where(p => p.Ativo == true).ToList();
        }

        public List<Pacotes> BuscarInativo()
        {
            //Usamos WHERE para identificar
            return ctx.Pacotes.Where(p => p.Ativo == false).ToList();
        }

        public List<Pacotes> BuscarCidade(string nomeCidade)
        {
            return ctx.Pacotes.Where(p => p.NomeCidade == nomeCidade).ToList();
        }

        public List<Pacotes> ListaOrdenadaMaiorMenor()
        {
            return ctx.Pacotes.OrderByDescending(p => p.Valor).ToList();
        }

        public List<Pacotes> ListaOrdenadoMenorMaior()
        {
            return ctx.Pacotes.OrderBy(p => p.Valor).ToList();
        }
    }
}
