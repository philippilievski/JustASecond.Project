namespace JustASecond.Web.Data.Models
{
    public class OrderPosition
    {
        public int Position { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}