namespace JustASecond.DAL.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Table Table { get; set; }
        public bool Sent { get; set; } = false;
        public virtual ICollection<OrderPosition>? OrderPositions { get; set; }
        public virtual Customer Customer { get; set; }
    }
}