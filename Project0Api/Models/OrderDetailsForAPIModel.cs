namespace ProjectModel
{
    public class OrderDetailsForAPIModel
    {
        public string StoreName{ get; set; }
        public string CustomerName{ get; set; }
        public int orderID{ get; set; }
        public decimal TotalCost{ get; set; }

        // public List<ItemModel> ItemList{ get; set; }
        // public List<int> QuantityList{ get; set; }

        public List<ItemAndQuantityforApiModel> ItemAndQuantity{ get; set; }
        public DateTime DateTimeOfOrder{ get; set; }

        public OrderDetailsForAPIModel()
        {
            ItemAndQuantity = new List<ItemAndQuantityforApiModel>();

        }
    }
}