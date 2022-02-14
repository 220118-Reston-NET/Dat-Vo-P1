using ProjectModel;
namespace ProjectDL
{
    public interface IRepository
    {
        //Employee methods
        EmployeeModel AddEmployee(EmployeeModel Employee);

        List<EmployeeModel> GetAllEmployee();
        
        EmployeeModel RemoveEmployee(EmployeeModel Employee);

        //Item methods

        ItemModel AddItem(ItemModel Item);

        List<ItemModel> GetAllItem();
        ItemModel GetItem(int itemID);
        
        ItemModel RemoveItem(ItemModel Item);

        //Customer methods

        CustomerModel AddCustomer(CustomerModel Customer);

        List<CustomerModel> GetAllCustomer();
        
        CustomerModel RemoveCustomer(CustomerModel Customer);

        //StoreFront methods
        StoreFrontModel AddStoreFront(StoreFrontModel Customer);

        List<StoreFrontModel> GetAllStoreFront();
        
        StoreFrontModel RemoveStoreFront(StoreFrontModel Customer);

        //Inventory methods
        InventoryModel AddInventory(InventoryModel Inventory);
        List<InventoryModel> GetAllInventory();
            //InventoryModel GetInventory();
        InventoryModel RemoveInventory(InventoryModel Inventory);
        InventoryModel UpdateInventory(InventoryModel Inventory);

        //Order methods
        OrderModel AddOrder(OrderModel Order);
        List<OrderModel> GetAllOrder();
        OrderModel RemoveOrder(OrderModel Order);


    }
}
