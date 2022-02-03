namespace ProjectModel
{
    public class cartModel
    {
        public string CustomerName { get; set; }
        public float TotalPrice { get; set; }
        public List<string> ItemList{ get; set; }

        public cartModel()
        {
            CustomerName = "Item Name";
            TotalPrice = 0;
        }
    }
}