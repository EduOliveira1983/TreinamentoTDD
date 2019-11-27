using TreinamentoTDD.Dominio.Cursos;

namespace TreinamentoTDD.Dominio.Interface
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {        
        Curso ObterPeloNome(string nome);
    }
}
