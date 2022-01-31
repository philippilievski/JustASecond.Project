using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustASecond.DAL.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Table Table { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
