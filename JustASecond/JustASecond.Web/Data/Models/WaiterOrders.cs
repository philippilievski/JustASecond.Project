using System.ComponentModel.DataAnnotations;

namespace JustASecond.Web.Data.Models
{
    public class WaiterOrders
    {
        [Required]
        public string? WaiterId { get; set; }
        public ApplicationUser? Waiter { get; set; }

        [Required]
        public string? OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        public Orderstatus Status { get; set; }
    }
}
