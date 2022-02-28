using ProjectModel;
using ProjectDL;

namespace ProjectBL
{
    public static class CurrentCustomer
    {

        public static CustomerModel currentcustomer = new CustomerModel();
        public static EmployeeModel currentemployee = new EmployeeModel();
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

        public static void SetEmployee(EmployeeModel employeeInput)
        {
            currentemployee = employeeInput;
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
            if(quantity >=0)
            {
                currentinventory.quantity = quantity;
            }
            else
            {
                Console.WriteLine("Cannot set quantity to negative number");
                throw new Exception("Cannot set quantity to negative number");
            }
            
        }

        public static void AddItemToCart(ItemModel item)
        {
            currentcart.Add(item);
        }

        public static void LogOut()
        {
            currentcustomer = new CustomerModel();
            currentemployee = new EmployeeModel();
        }

        public static void clearcurrentcustomer()
        {
            currentcustomer = new CustomerModel();
        }
        public static void clearcurrentemployee()
        {
            currentemployee = new EmployeeModel();
        }

        public static void clearcart()
        {
            currentcart = new List<ItemModel>();
            currentcartquantity = new List<int>();
        }




    }

}