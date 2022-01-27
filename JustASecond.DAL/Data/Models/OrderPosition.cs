namespace JustASecond.DAL.Data.Models
{
    public class OrderPosition
    {
        public int PositionNr { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}