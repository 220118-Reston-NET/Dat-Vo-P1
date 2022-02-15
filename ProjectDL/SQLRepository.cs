using ProjectModel;
using System.Data.SqlClient;
namespace ProjectDL
{
    public class SQLRepository:IRepository 
    {
        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        // EMPLOYEES =======================================================
        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            string sqlQuery = @"insert into Employee values(@employeename, @employeenumber, @employeeemail)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@employeename",employee.name);
                command.Parameters.AddWithValue("@employeenumber",employee.number);
                command.Parameters.AddWithValue("@employeeemail",employee.email);

                command.ExecuteNonQuery();
            }

            return employee;
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> listOfEmployee = new List<EmployeeModel>();

            string sqlQuery = @"select * from Employee";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfEmployee.Add(new EmployeeModel(){
                        employeeID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        number = reader.GetString(2),
                        email = reader.GetString(3)
                    });
                }

            } 
            return listOfEmployee;
        }
        public EmployeeModel RemoveEmployee(EmployeeModel employee)
        {
            string sqlQuery = @"delete from Employee where employeeID = @employeeID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@employeeID", employee.employeeID);

                command.ExecuteNonQuery();
            }
            
            return employee;
        }
    

        // ITEMS =======================================================
        public ItemModel AddItem(ItemModel item)
        {
            string sqlQuery = @"insert into Item values(@ItemName, @ItemPrice, @ItemCategory, @ItemDescription)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                //@ItemID, @ItemName, @ItemPrice, @ItemCategory, @ItemDescription
                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@ItemID", item.ItemID);
                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                command.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
                command.Parameters.AddWithValue("@ItemCategory", item.ItemCategory);
                command.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);

                command.ExecuteNonQuery();
            }

            return item;
        }

        public List<ItemModel> GetAllItem()
        {
            List<ItemModel> listOfItem = new List<ItemModel>();

            string sqlQuery = @"select * from Item";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfItem.Add(new ItemModel(){
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        ItemPrice = reader.GetDecimal(2),
                        ItemCategory = reader.GetString(3),
                        ItemDescription = reader.GetString(4)
                    });
                }

            } 
            return listOfItem;
        }

        public ItemModel GetItem(int itemID)
        {
            ItemModel resultItem = new ItemModel();
            string sqlQuery = @"select * from Item where ItemID = @ItemID";
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ItemID", itemID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    resultItem.ItemID = reader.GetInt32(0);
                    resultItem.ItemName = reader.GetString(1);
                    resultItem.ItemPrice = reader.GetDecimal(2);
                    resultItem.ItemCategory = reader.GetString(3);
                    resultItem.ItemDescription = reader.GetString(4);
                }

            } 

            return resultItem;

        }

        public ItemModel RemoveItem(ItemModel Item)
        {
            string sqlQuery = @"delete from Item where ItemID = @ItemID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ItemID", Item.ItemID);

                command.ExecuteNonQuery();
            }
            
            return Item;
        }

        // CUSTOMERS =======================================================
        public CustomerModel AddCustomer(CustomerModel Customer)
        {
            string sqlQuery = @"insert into Customer values(@name, @phonenumber, @email)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@name", Customer.name);
                command.Parameters.AddWithValue("@phonenumber", Customer.phonenumber);
                command.Parameters.AddWithValue("@email", Customer.email);

                command.ExecuteNonQuery();
            }

            return Customer;
        }
        

        public List<CustomerModel> GetAllCustomer()
        {
            List<CustomerModel> listOfCustomer = new List<CustomerModel>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new CustomerModel(){
                        customerID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        phonenumber = reader.GetString(2),
                        email = reader.GetString(3)
                    });
                }

            } 
            return listOfCustomer;
        }

        public CustomerModel RemoveCustomer(CustomerModel Customer)
        {
            throw new NotImplementedException();
        }

        // STOREFRONT =======================================================
        public StoreFrontModel AddStoreFront(StoreFrontModel Customer)
        {
            throw new NotImplementedException();
        }

        public List<StoreFrontModel> GetAllStoreFront()
        {
            List<StoreFrontModel> listOfStoreFront = new List<StoreFrontModel>();

            string sqlQuery = @"select * from StoreFront";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStoreFront.Add(new StoreFrontModel(){
                        storeID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Location = reader.GetString(2),
                        //Inventory = reader.GetString(3)
                        //OrderList = reader.GetString(3)
                    });
                }

            } 
            return listOfStoreFront;
        }

        public CustomerModel SearchCustomerByID(int customerID)
        {
            List<CustomerModel> listOfCustomer = new List<CustomerModel>();
            string sqlQuery = @"select * from Customer where customerID = @customerID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerID", customerID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomer.Add(new CustomerModel(){
                        customerID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        phonenumber = reader.GetString(2),
                        email = reader.GetString(3)
                    });
                }

            } 
            return listOfCustomer[0];
        }


        // Inventory =======================================================
        public StoreFrontModel RemoveStoreFront(StoreFrontModel Customer)
        {
            throw new NotImplementedException();
        }

        public InventoryModel AddInventory(InventoryModel Inventory)
        {
            string sqlQuery = @"insert into Inventory values(@storeID,@itemID,@quantity)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                //@ItemID, @ItemName, @ItemPrice, @ItemCategory, @ItemDescription
                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@ItemID", item.ItemID);
                command.Parameters.AddWithValue("@storeID", Inventory.storeID);
                command.Parameters.AddWithValue("@itemID", Inventory.itemID);
                command.Parameters.AddWithValue("@quantity", Inventory.quantity);

                command.ExecuteNonQuery();
            }

            return Inventory;
        }

        public List<InventoryModel> GetAllInventory()
        {
            List<InventoryModel> listOfInventory = new List<InventoryModel>();

            string sqlQuery = @"select * from Inventory";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfInventory.Add(new InventoryModel(){
                        storeID = reader.GetInt32(0),
                        itemID = reader.GetInt32(1),
                        quantity = reader.GetInt32(2),
                        
                    });
                }

            } 
            return listOfInventory;
        }

        public InventoryModel RemoveInventory(InventoryModel Inventory)
        {
            throw new NotImplementedException();
        }

        public List<ItemModel> GetAvailableItems(int storeID)
        {
            string sqlQuery = "select i.ItemID, i.ItemName , i.ItemPrice , i.ItemDescription , Inventory.quantity  from StoreFront Sinner join Inventory on S.storeID  = Inventory.storeID inner join Item i on i.ItemID  = Inventory.itemIDhere S.storeID  = '@storeID' ";
            List<InventoryModel> listOfInventory = new List<InventoryModel>();
            List<ItemModel> listOfItem = new List<ItemModel>();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.AddWithValue("@storeID", storeID);

                while (reader.Read())
                {
                    listOfItem.Add(new ItemModel(){
                        ItemID = reader.GetInt32(6),
                        ItemName = reader.GetString(7),
                        ItemPrice = reader.GetDecimal(8),
                        ItemCategory = reader.GetString(9),
                        ItemDescription = reader.GetString(10)
                    
                    });
                   listOfInventory.Add(new InventoryModel(){
                        storeID = reader.GetInt32(3),
                        itemID = reader.GetInt32(4),
                        quantity = reader.GetInt32(5)

                    });
                }

                return listOfItem;

            } 

        }

        public InventoryModel UpdateInventory(InventoryModel Inventory)
        {
            string sqlQuery = @"update Inventory set quantity = @quantity where itemID = @itemID and storeID = @storeID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@quantity",Inventory.quantity);
                command.Parameters.AddWithValue("@itemID",Inventory.itemID);
                command.Parameters.AddWithValue("@storeID",Inventory.storeID);

                command.ExecuteNonQuery();
                return Inventory;
            }
        }

        // Order =======================================================
        public OrderModel AddOrder(OrderModel Order)
        {
            string sqlQuery = @"insert into CustomerOrder values(@totalprice, @customerID, @storeID)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@totalprice", Order.TotalPrice);
                command.Parameters.AddWithValue("@customerID", Order.customerID);
                command.Parameters.AddWithValue("@storeID", Order.storeID);

                command.ExecuteNonQuery();
            }

            return Order;
        }


        public List<OrderModel> GetAllOrder()
        {
            List<OrderModel> listOfOrder = new List<OrderModel>();

            string sqlQuery = @"select * from CustomerOrder";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrder.Add(new OrderModel(){
                        orderID =  reader.GetInt32(0),
                        TotalPrice = reader.GetDecimal(1),
                        customerID = reader.GetInt32(2),
                        storeID = reader.GetInt32(3)
                    });
                }

            } 
            return listOfOrder;
        }

        public OrderModel RemoveOrder(OrderModel Order)
        {
            throw new NotImplementedException();
        }


        public OrderItemModel AddOrderItem(OrderItemModel orderItem)
        {
            string sqlQuery = @"insert into Order_Items values(@orderID, @itemID, @quantity)";
 
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderID", orderItem.orderID);
                command.Parameters.AddWithValue("@itemID", orderItem.itemID);
                command.Parameters.AddWithValue("@quantity", orderItem.quantity);

                command.ExecuteNonQuery();
            }

            return orderItem;
        }

        public StoreFrontModel SearchStoreByID(int storeID)
        {
            List<StoreFrontModel> listOfStore = new List<StoreFrontModel>();
            string sqlQuery = @"select * from StoreFront where storeID = @storeID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", storeID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStore.Add(new StoreFrontModel(){
                        storeID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Location = reader.GetString(2)
                    });
                }

            } 
            return listOfStore[0];
        }

        public List<OrderItemModel> SearchOrderItem(int orderID)
        {
            string sqlQuery = @"select * from Order_Items where orderID = @orderID";

            List<OrderItemModel> listOfOrderItem = new List<OrderItemModel>();

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderID", orderID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrderItem.Add(new OrderItemModel(){
                        orderID = reader.GetInt32(0),
                        itemID = reader.GetInt32(1),
                        quantity = reader.GetInt32(2)
                    });
                }

            } 
            
            return listOfOrderItem;

        }
    }
}