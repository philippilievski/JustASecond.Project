namespace JustASecond.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepo OrderRepo { get; }
        Task Commit();
        Task Rollback();
    }
}