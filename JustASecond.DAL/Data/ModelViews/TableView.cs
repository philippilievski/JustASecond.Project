using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustASecond.DAL.Data.ModelViews
{
    public class TableView
    {
        public int? Id { get; set; }
        public bool HasCalled { get; set; } = false;
        public virtual IEnumerable<OrderView>? Orders { get; set; }
    }
}
