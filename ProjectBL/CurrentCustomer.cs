using ProjectModel;
using ProjectDL;

namespace ProjectBL
{
    public static class CurrentCustomer
    {

        public static CustomerModel currentcustomer {get; set;}
        public static StoreFrontModel currentstore {get; set;}
        public static List<InventoryModel> currentinventoryList {get; set;}
        public static InventoryModel currentinventory = new InventoryModel();
        public static List<ItemModel> currentcart = new List<ItemModel>();
        public static List<int> currentcartquantity = new List<int>();

        public static OrderModel currentOrder = new OrderModel();


        public static void SetCustomer(CustomerModel customerInput)
        {
            currentcustomer = customerInput;
        }

        public static void SetStoreFront(StoreFrontModel storefrontInput)
        {
            currentstore = storefrontInput;
        }

        public static void SetInventoryStoreID(int storeID)
        {
            currentinventory.storeID = storeID;
        }
        public static void SetInventoryitemID(int itemID)
        {
            currentinventory.itemID = itemID;
        }

        public static void SetInventoryQuantity(int quantity)
        {
            currentinventory.quantity = quantity;
        }

        public static void AddItemToCart(ItemModel item)
        {
            currentcart.Add(item);
        }





    }

}