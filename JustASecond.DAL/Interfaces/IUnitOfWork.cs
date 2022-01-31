namespace JustASecond.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepo OrderRepo { get; }
        IProductRepo ProductRepo { get; }
        ICustomerRepo CustomerRepo { get; }
        Task SaveChanges();
        Task Rollback();
    }
}