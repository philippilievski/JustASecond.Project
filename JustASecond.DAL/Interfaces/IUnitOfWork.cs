namespace JustASecond.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepo OrderRepo { get; }
        IProductRepo ProductRepo { get; }
        Task Commit();
        Task Rollback();
    }
}