using ProjectModel;
using ProjectDL;
namespace ProjectBL
{
    public class ProjectBLc:IProjectBL
    {
        private IRepository _repo;
        public ProjectBLc(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public EmployeeModel AddEmployee(EmployeeModel Employee)
        {
            List<EmployeeModel> listOfEmployee = _repo.GetAllEmployee();
    

            if (listOfEmployee.Count >= 9)
            {
                throw new Exception("you can not have more than 9 employees");
            }
            else if (Employee.number.Length != 10)
            {
                throw new Exception("Invalid Phone Number");
            }
            else if (!Employee.email.Contains("@"))
            {
                throw new Exception("Invalid Email");
            }
            else
            {
                return _repo.AddEmployee(Employee);
            }

        }


        public List<EmployeeModel> GetAllEmployee()
        {
            return _repo.GetAllEmployee();
        }

        public EmployeeModel RemoveEmployee(EmployeeModel p_Employee)
        {
            return _repo.RemoveEmployee(p_Employee);
        }

        public List<EmployeeModel> SearchEmployee(string p_name)
        {
            List<EmployeeModel> listOfEmployee= _repo.GetAllEmployee();


            // LINQ library
            return listOfEmployee
                        .Where(employee => employee.name.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that the method needs to return
        }

    }

    public class ProjectBLitem : IProjectBLitem
    {
        private IRepository _repo;
        public ProjectBLitem(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public ItemModel AddItem(ItemModel p_Item)
        {
            List<ItemModel> listOfItem = _repo.GetAllItem();
            return _repo.AddItem(p_Item);
        }

        public List<ItemModel> GetAllItem()
        {
            return _repo.GetAllItem();
        }

        public List<StoreFrontModel> GetAllStoreFront()
        {
            /// <summary>
            /// return store front to add empty inventory
            /// </summary>
            /// <returns></returns>
            return _repo.GetAllStoreFront();
        }

        public ItemModel RemoveItem(ItemModel p_Item)
        {
            return _repo.RemoveItem(p_Item);
        }

        public List<ItemModel> SearchItem(string p_name)
        {
            List<ItemModel> listOfItem = _repo.GetAllItem();
            // LINQ library
            return listOfItem
                        .Where(item => item.ItemName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that the method needs to return
        }
        public InventoryModel AddInventory(InventoryModel p_inventory)
        {
            return _repo.AddInventory(p_inventory);
        }

        public ItemModel GetItem(int itemID)
        {
            return _repo.GetItem(itemID);
        }
    }

    public class ProjectBLCustomer : IProjectBLCustomer
    {
        private IRepository _repo;
        public ProjectBLCustomer(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public CustomerModel AddCustomer(CustomerModel p_customer)
        {
            List<CustomerModel> listOfCustomer = _repo.GetAllCustomer();
            return _repo.AddCustomer(p_customer);
        }

        public List<CustomerModel> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
        }

        public CustomerModel RemoveCustomer(CustomerModel p_customer)
        {
            return _repo.RemoveCustomer(p_customer);
        }

        public List<CustomerModel> SearchCustomer(string p_name)
        {
            List<CustomerModel> listOfCustomer= _repo.GetAllCustomer();
            // LINQ library
            return listOfCustomer
                        .Where(customer => customer.name.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that the method needs to return
        }
    }

    public class ProjectBLStoreFront : IProjectBLStoreFront
    {
        private IRepository _repo;
        public ProjectBLStoreFront(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public StoreFrontModel AddStoreFront(StoreFrontModel p_storefront)
        {
            throw new NotImplementedException();
        }

        public List<StoreFrontModel> GetAllStoreFront()
        {
            return _repo.GetAllStoreFront();
        }

        public StoreFrontModel RemoveStoreFront(StoreFrontModel p_storefront)
        {
            throw new NotImplementedException();
        }

        public StoreFrontModel SearchStoreFront(string p_name)
        {
            throw new NotImplementedException();
        }
    }
    public class ProjectBLInventory : IProjectBLInventory
    {
        private IRepository _repo;
        public ProjectBLInventory(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public InventoryModel AddInventory(InventoryModel p_inventory)
        {
            throw new NotImplementedException();
        }

        public List<InventoryModel> GetAllInventory()
        {
            return _repo.GetAllInventory();
        }

        public InventoryModel RemoveInventory(InventoryModel p_inventory)
        {
            throw new NotImplementedException();
        }

        public List<InventoryModel> SearchInventoryByStoreID(int storeID)
        {
            List<InventoryModel> listOfInventory= _repo.GetAllInventory();
            return listOfInventory;
        }

        public List<ItemModel> GetAllItem()
        {
            return _repo.GetAllItem();
        }

        public List<ItemModel> SearchItem(int itemID)
        {
            List<ItemModel> listOfItem= _repo.GetAllItem();
            //public ItemModel result;
            // ItemModel result = from item in listOfItem
            //                     where item.ItemID.

            // LINQ library
            return listOfItem
                        .Where(item => item.ItemID.Equals(itemID)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that the method needs to return
        }

        public List<StoreFrontModel> GetAllStoreFront()
        {
            return _repo.GetAllStoreFront();
        }

        public InventoryModel UpdateInventory(InventoryModel p_inventory)
        {
            return _repo.UpdateInventory(p_inventory);
        }

        public ItemModel GetItem(int itemID)
        {
            return _repo.GetItem(itemID);
        }

        public OrderModel AddOrder(OrderModel order)
        {

            CurrentCustomer.currentOrder.customerID = CurrentCustomer.currentcustomer.customerID;
            CurrentCustomer.currentOrder.storeID = CurrentCustomer.currentstore.storeID;

            int c = new int();
            decimal total = new decimal();
            foreach(var item in CurrentCustomer.currentcart)
            {
                total = total + item.ItemPrice*CurrentCustomer.currentcartquantity[c];
                
                int currentquantity = new int();
                List<InventoryModel> ListOfInventory = GetAllInventory();
                foreach(var inven in ListOfInventory)
                {
                    if (inven.itemID == item.ItemID && inven.storeID == CurrentCustomer.currentstore.storeID)
                    {
                        currentquantity = inven.quantity;
                    }
                }

                CurrentCustomer.currentinventory.itemID = item.ItemID;
                CurrentCustomer.currentinventory.storeID = CurrentCustomer.currentstore.storeID;
                CurrentCustomer.SetInventoryQuantity(currentquantity-CurrentCustomer.currentcartquantity[c]);
                _repo.UpdateInventory(CurrentCustomer.currentinventory);

                c=c+1;
            }
            CurrentCustomer.currentOrder.TotalPrice = total;

            //CurrentCustomer.currentcart.Clear();
            //CurrentCustomer.currentcartquantity.Clear();


            return _repo.AddOrder(order);
        }

        public List<OrderModel> GetAllOrder()
        {
            return _repo.GetAllOrder();
        }

        public void AddOrderItem()
        {
            List<OrderModel> listOfOrder = _repo.GetAllOrder();
            int c = new int();
            foreach(var item in CurrentCustomer.currentcart)
            {
                OrderItemModel OI = new OrderItemModel();
                OI.itemID = item.ItemID;
                OI.orderID = listOfOrder.Last().orderID;
                OI.quantity = CurrentCustomer.currentcartquantity[c];
                _repo.AddOrderItem(OI);
                c = c + 1;
            }

            CurrentCustomer.currentcart.Clear();
            CurrentCustomer.currentcartquantity.Clear();
        }

        public CustomerModel GetCustomer(int customerID)
        {
            return _repo.SearchCustomerByID(customerID);
        }

        public StoreFrontModel GetStore(int storeID)
        {
            return _repo.SearchStoreByID(storeID);
        }

        public List<OrderItemModel> SearchOrderItem(int orderID)
        {
            return _repo.SearchOrderItem(orderID);
        }
    }



}
