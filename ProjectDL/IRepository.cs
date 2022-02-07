using ProjectModel;
namespace ProjectDL
{
    public interface IRepository
    {
        EmployeeModel AddEmployee(EmployeeModel Employee);

        List<EmployeeModel> GetAllEmployee();
        
        EmployeeModel RemoveEmployee(EmployeeModel Employee);

        ItemModel AddItem(ItemModel Item);

        List<ItemModel> GetAllItem();
        
        ItemModel RemoveItem(ItemModel Item);

    }
}
