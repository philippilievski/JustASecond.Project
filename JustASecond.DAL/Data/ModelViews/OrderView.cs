using JustASecond.DAL.Data.Models;

namespace JustASecond.DAL.Data.ModelViews
{
    public class OrderView
    {
        public int Id { get; set; }
        public CustomerView Customer { get; set; }
        public DateTime? CreatedOn { get; set; }
        public OrderPosition OrderPosition { get; set; }
    }
}
