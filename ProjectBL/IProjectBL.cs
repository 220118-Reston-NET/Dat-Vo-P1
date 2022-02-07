using ProjectModel;
namespace ProjectBL
{
    public interface IProjectBL
    {
        EmployeeModel AddEmployee(EmployeeModel p_Employee);

        EmployeeModel RemoveEmployee(EmployeeModel p_Employee);

        List<EmployeeModel> SearchEmployee(string p_name);

        List<EmployeeModel> GetAllEmployee();

    }

    public interface IProjectBLitem
    {
        ItemModel AddItem(ItemModel p_Item);

        ItemModel RemoveItem(ItemModel p_Item);

        List<ItemModel> SearchItem(string p_name);

        List<ItemModel> GetAllItem();
    }
}