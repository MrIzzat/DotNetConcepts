namespace ContosoPizza.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }
         
        public DateTime? OrderFulFilled { get; set; }

        public int CustomerId { get; set; }//if we remove this property the entityframeworkcore will add it automatically as a shadow property

        public Customer Customer { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    
    
    }
}