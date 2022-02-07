namespace ProjectModel
{
    public class OrderModel
    {
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public List<ItemModel>? ItemList{ get; set; }

        public OrderModel()
        {
            CustomerName = "Customer Name";
            TotalPrice = 0;
        }
    }
}