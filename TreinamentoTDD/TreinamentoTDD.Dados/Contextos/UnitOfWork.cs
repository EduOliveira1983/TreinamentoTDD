using System.Threading.Tasks;
using TreinamentoTDD.Dominio.Interface;

namespace TreinamentoTDD.Dados.Contextos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }


           
    }
}
