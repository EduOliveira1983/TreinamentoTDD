using System.Collections.Generic;
using TreinamentoTDD.Dominio.Base;

namespace TreinamentoTDD.Dominio.Interface
{
    public interface IRepositorio<TEntidade> where TEntidade : Entidade
    {
        TEntidade ObterPorId(int id);
        List<TEntidade> Consultar();
        void Adicionar(TEntidade entity);
    }
}
