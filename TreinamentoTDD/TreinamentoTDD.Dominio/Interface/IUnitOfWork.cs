using System.Threading.Tasks;

namespace TreinamentoTDD.Dominio.Interface
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
