using ProjectModel;
namespace ProjectBL
{
    public interface IProjectBL
    {
        EmployeeModel AddEmployee(EmployeeModel p_Employee);

        List<EmployeeModel> SearchEmployee(string p_name);

        List<EmployeeModel> GetAllEmployee();
    }
}