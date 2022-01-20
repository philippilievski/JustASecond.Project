namespace JustASecond.Web.Data.ModelViews
{
    public class ProductView
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<OrderPositionView>? OrderPositions { get; set; }
    }
}
