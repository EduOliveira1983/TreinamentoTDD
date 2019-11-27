using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreinamentoTDD.Dados.Contextos;
using TreinamentoTDD.Dominio.Base;
using TreinamentoTDD.Dominio.Interface;

namespace TreinamentoTDD.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Adicionar(TEntidade entity)
        {
            Context.Set<Entidade>().Add(entity);
        }

        public List<TEntidade> Consultar()
        {
            var entidades = Context.Set<TEntidade>().ToList();
            return entidades.Any() ? entidades : new List<TEntidade>();
        }

        public TEntidade ObterPorId(int id)
        {
            var query = Context.Set<TEntidade>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }
    }
}
