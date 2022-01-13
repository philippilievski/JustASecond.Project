namespace JustASecond.Web.Data.Models
{
    public class WaiterCall
    {
        public int Id { get; set; }
        public DateTime? CalledAt { get; set; }
        public int Waiter { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public int TableId { get; set; }
        public virtual Table? Table { get; set; }
    }
}
