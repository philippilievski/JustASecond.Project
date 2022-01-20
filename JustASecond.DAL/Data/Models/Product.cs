namespace JustASecond.DAL.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public ProductType Type { get; set; }
        public string Image { get; set; } = "placeholder";
        public virtual ICollection<OrderPosition>? OrderPositions { get; set; }
    }
}