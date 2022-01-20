namespace JustASecond.Web.Data.ModelViews
{
    public class OrderPositionView
    {
        public int Position { get; set; }
        public int OrderId { get; set; }
        public virtual ProductView Product { get; set; }
        public int Amount { get; set; }
        public decimal Total => Amount * Product.Price;
    }
}
