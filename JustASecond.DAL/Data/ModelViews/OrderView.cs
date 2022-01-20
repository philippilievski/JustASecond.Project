using JustASecond.DAL.Data.Models;

namespace JustASecond.DAL.Data.ModelViews
{
    public class OrderView
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<OrderPositionView>? OrderPositions { get; set; }
    }
}
