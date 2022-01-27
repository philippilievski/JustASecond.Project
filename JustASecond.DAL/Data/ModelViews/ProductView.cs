using System.ComponentModel.DataAnnotations.Schema;

namespace JustASecond.Web.Data.ModelViews
{
    public class ProductView
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [Column(TypeName = "decimal(13,2)")]
        public decimal Price { get; set; }
        public virtual ICollection<OrderPositionView>? OrderPositions { get; set; }
    }
}
