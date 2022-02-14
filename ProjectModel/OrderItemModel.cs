namespace ProjectModel
{
    public class OrderItemModel
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public int quantity { get; set; }


        public OrderItemModel()
        {
            orderID = 0;
            itemID = 0;
            quantity = 0;
        }
    }
}