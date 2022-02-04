namespace ProjectModel
{
    public class ItemModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
        public string ItemCategory { get; set; }
        public string ItemDescription { get; set; }


        public ItemModel()
        {
            ItemID = 0;
            ItemName = "Item Name";
            ItemPrice = 0;
            ItemCategory = "Category";
            ItemDescription = "Description";

        }
    }
}