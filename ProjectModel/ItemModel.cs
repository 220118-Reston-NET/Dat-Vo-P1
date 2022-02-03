namespace ProjectModel
{
    public class ItemModel
    {
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string ItemDescription { get; set; }

        public ItemModel()
        {
            ItemName = "Item Name";
            ItemPrice = "$-.--";
            ItemDescription = "Description";
        }
    }
}