namespace JustASecond.Web.Data.Models
{
    public class Order
    {
        public string? Id { get; set; }
        public virtual ICollection<OrderPosition>? OrderPositions { get; set; }
    }
}