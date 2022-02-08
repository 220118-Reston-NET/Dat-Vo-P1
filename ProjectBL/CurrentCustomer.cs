using ProjectModel;
using ProjectDL;
namespace ProjectBL
{
    public static class CurrentCustomer
    {
        public static CustomerModel currentcustomer {get; set;}
        public static StoreFrontModel currentstore {get; set;}
        public static InventoryModel currentinventory {get; set;}
        public static void SetCustomer(CustomerModel customerInput)
        {
            //CustomerModel currentcustomer = new CustomerModel();
            currentcustomer = customerInput;
        }

        public static void SetStoreFront(StoreFrontModel storefrontInput)
        {
            currentstore = storefrontInput;
        }

        
    }

}