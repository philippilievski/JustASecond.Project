using System.ComponentModel.DataAnnotations.Schema;

namespace JustASecond.DAL.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [Column(TypeName= "decimal(13,2)")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public ProductType Type { get; set; }
        public string Image { get; set; } = "placeholder";
        public virtual ICollection<OrderPosition>? OrderPositions { get; set; }
    }
}