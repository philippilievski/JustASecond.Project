namespace JustASecond.Web.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? OrderId { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
