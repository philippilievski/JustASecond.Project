namespace JustASecond.DAL.Data.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<OrderPosition>? OrderPositions { get; set; }
    }
}