using JustASecond.DAL.Data.Models;

namespace JustASecond.DAL.Interfaces
{
    public interface IInvoiceRepo
    {
        void CreateInvoicePDF(Order order, int invoinceNumber);
    }
}
