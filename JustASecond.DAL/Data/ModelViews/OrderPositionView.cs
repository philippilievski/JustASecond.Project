using System.ComponentModel.DataAnnotations.Schema;

namespace JustASecond.Web.Data.ModelViews
{
    public class OrderPositionView
    {
        public int Position { get; set; }
        public int OrderId { get; set; }
        public virtual ProductView Product { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "decimal(13,2)")]
        public decimal Total => Amount * Product.Price;
    }
}
