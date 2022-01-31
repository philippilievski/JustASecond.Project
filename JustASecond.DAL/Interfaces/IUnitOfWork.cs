namespace JustASecond.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepo OrderRepo { get; }
        IProductRepo ProductRepo { get; }
        IInvoiceRepo InvoiceRepo { get; }
        Task SaveChanges();
        ICustomerRepo CustomerRepo { get; }
        Task Rollback();
    }
}