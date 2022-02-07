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
                        .ToList(); //ToList method just converts into a list collection that our method needs to return
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
            throw new NotImplementedException();
        }

        public List<ItemModel> GetAllItem()
        {
            throw new NotImplementedException();
        }

        public List<ItemModel> SearchItem(string p_name)
        {
            throw new NotImplementedException();
        }
    }
}
