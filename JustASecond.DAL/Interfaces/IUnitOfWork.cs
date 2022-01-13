namespace JustASecond.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}