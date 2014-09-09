namespace Library.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderDetails Details { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderDetails
    {
        public int Id { get; set; }
        public Product Item { get; set; }
        public int Quantity { get; set; }
    }
}
