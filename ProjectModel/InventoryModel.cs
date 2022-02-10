namespace ProjectModel
{
    public class InventoryModel
    {
        public int storeID { get; set; }
        public int itemID { get; set; }
        public int quantity { get; set; }

        public InventoryModel()
        {
            storeID = 0;
            itemID = 0;
            quantity = 0;
        }
    }
}