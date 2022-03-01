using ProjectModel;
namespace ProjectDL
{
    public interface IRepository
    {
        //Employee methods
        EmployeeModel AddEmployee(EmployeeModel Employee);

        List<EmployeeModel> GetAllEmployee();
        
        EmployeeModel RemoveEmployee(EmployeeModel Employee);

        EmployeeModel GetEmployeeByID(int employeeID);
        //List<EmployeeModel> SearchEmployee(string p_name);

        //Item methods

        ItemModel AddItem(ItemModel Item);

        List<ItemModel> GetAllItem();
        ItemModel GetItem(int itemID);
        
        ItemModel RemoveItem(ItemModel Item);

        //Customer methods

        CustomerModel AddCustomer(CustomerModel Customer);

        List<CustomerModel> GetAllCustomer();
        
        CustomerModel RemoveCustomer(CustomerModel Customer);

        CustomerModel SearchCustomerByID(int customerID);

        //StoreFront methods
        StoreFrontModel AddStoreFront(StoreFrontModel Customer);

        List<StoreFrontModel> GetAllStoreFront();
        
        StoreFrontModel RemoveStoreFront(StoreFrontModel Customer);

        StoreFrontModel SearchStoreByID(int? storeID);
        //StoreFrontModel SearchStoreFront(int storeID);

        StoreFrontModel SearchStoreFront(string p_name);

        //Inventory methods
        InventoryModel AddInventory(InventoryModel Inventory);
        List<InventoryModel> GetAllInventory();
            //InventoryModel GetInventory();
        InventoryModel RemoveInventory(InventoryModel Inventory);
        InventoryModel UpdateInventory(InventoryModel Inventory);

        List<InventoryModel> SearchInventoryByStoreID(int storeID);

        //Order methods
        OrderModel AddOrder(OrderModel Order);
        List<OrderModel> GetAllOrder();

        List<OrderModel> GetAllOrder(int? customerID);
        OrderModel RemoveOrder(OrderModel Order);

        //OrderItems methods
        OrderItemModel AddOrderItem(OrderItemModel orderItem);

        List<OrderItemModel> SearchOrderItem(int? orderID);


    }
}
