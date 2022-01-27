﻿namespace JustASecond.DAL.Data.Models
{
    public class Table
    {
        public int? Id { get; set; }
        public bool HasCalled { get; set; } = false;
        public virtual IEnumerable<Order>? Orders { get; set; }
    }
}
