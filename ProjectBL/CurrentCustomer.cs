using ProjectModel;
using ProjectDL;

namespace ProjectBL
{
    public static class CurrentCustomer
    {

        public static CustomerModel currentcustomer {get; set;}
        public static StoreFrontModel currentstore {get; set;}
        public static List<InventoryModel> currentinventoryList {get; set;}
        public static InventoryModel currentinventory {get; set;}


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

        // public static void SetItem(ItemModel item)
        // {
        //     currentitem = item;
        // }





    }

}