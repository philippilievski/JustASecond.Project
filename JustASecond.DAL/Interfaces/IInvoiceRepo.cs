using JustASecond.DAL.Data.Models;

namespace JustASecond.DAL.Interfaces
{
    public interface IInvoiceRepo
    {
        Task CreateInvoicePDF(Order order, int invoinceNumber);
    }
}
