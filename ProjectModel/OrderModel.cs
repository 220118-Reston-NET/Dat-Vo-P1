namespace ProjectModel
{
    public class OrderModel
    {
        public int orderID { get; set; }
        public decimal TotalPrice { get; set; }
        public int customerID { get; set; }
        public int storeID { get; set; }


        public OrderModel()
        {
            //CustomerName = "Customer Name";
            TotalPrice = 0;
            customerID = 0;
            storeID = 0;
        }
    }
}