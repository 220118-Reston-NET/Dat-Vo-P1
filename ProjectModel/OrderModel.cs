namespace ProjectModel
{
    public class OrderModel
    {
        public int orderID { get; set; }
        public decimal TotalPrice { get; set; }
        public int customerID { get; set; }
        public int storeID { get; set; }

        // public List<OrderItemModel> listOfOrderItems{ get; set; }

        // public List<int> listOfAmount{ get; set; }
        public Dictionary<ItemModel, int> ItemAndAmount { get; set; }

        public DateTime datetimeoforder { get; set;}


        public OrderModel()
        {
            //CustomerName = "Customer Name";
            TotalPrice = 0;
            customerID = 0;
            storeID = 0;
        }
    }
}