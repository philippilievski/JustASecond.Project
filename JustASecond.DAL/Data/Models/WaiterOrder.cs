using System.ComponentModel.DataAnnotations;

namespace JustASecond.DAL.Data.Models
{
    public class WaiterOrder
    {
        public int WaiterOrderId { get; set; }
        [Required]
        public string? WaiterId { get; set; }
        public ApplicationUser? Waiter { get; set; }

        [Required]
        public int? OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        public Orderstatus Status { get; set; }
    }
}
