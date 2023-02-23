namespace WebApplication1.EntityModel
{
    public class CartItemEntity
    {
        public int Id { get; set; }
        public string ?ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }
        public string ?Image { get; set; }
        
    }
}
