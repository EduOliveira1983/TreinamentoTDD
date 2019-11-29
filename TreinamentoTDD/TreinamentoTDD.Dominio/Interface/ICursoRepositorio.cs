using TreinamentoTDD.Dominio.Entidades;

namespace TreinamentoTDD.Dominio.Interface
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {        
        Curso ObterPeloNome(string nome);
    }
}
