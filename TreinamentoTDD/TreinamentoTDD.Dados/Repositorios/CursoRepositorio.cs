using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreinamentoTDD.Dados.Contextos;
using TreinamentoTDD.Dominio.Cursos;
using TreinamentoTDD.Dominio.Interface;

namespace TreinamentoTDD.Dados.Repositorios
{
    public class CursoRepositorio : RepositorioBase<Curso>, ICursoRepositorio
    { 

        public CursoRepositorio(ApplicationDbContext context) : base(context)
        {
        }       

        Curso ICursoRepositorio.ObterPeloNome(string nome)
        {
            return Context.Set<Curso>().Where(c => c.Nome == nome).FirstOrDefault();
        }
    }
}
