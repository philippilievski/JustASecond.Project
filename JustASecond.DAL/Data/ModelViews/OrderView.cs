using JustASecond.DAL.Data.Models;
using JustASecond.Web.Data.ModelViews;

namespace JustASecond.DAL.Data.ModelViews
{
    public class OrderView
    {
        public int Id { get; set; }
        public ApplicationUser? Customer { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<OrderPositionView>? OrderPositions { get; set; }
    }
}
