using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSQL _context;

        public UnitOfWork(ContextSQL context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
