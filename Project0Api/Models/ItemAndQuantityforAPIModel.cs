namespace ProjectModel
{
    public class ItemAndQuantityforApiModel
    {
        public ItemModel Item{ get; set; }
        public int Quantity{ get; set; }

        public ItemAndQuantityforApiModel()
        {
            Item = new ItemModel();
            Quantity = new int();
        }
    }
}