namespace ProjectDeliv.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
    }
}
