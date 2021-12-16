namespace JustASecond.Web.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public virtual ICollection<OrderPosition>? OrderPositions { get; set; }
    }
}