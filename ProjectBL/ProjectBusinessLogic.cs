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

        public ItemModel RemoveItem(ItemModel p_Item)
        {
            return _repo.RemoveItem(p_Item);
        }

        public List<ItemModel> SearchItem(string p_name)
        {
            List<ItemModel> listOfItem= _repo.GetAllItem();
            // LINQ library
            return listOfItem
                        .Where(item => item.ItemName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that the method needs to return
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


}
