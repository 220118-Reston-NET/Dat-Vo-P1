using ProjectModel;
using ProjectBL;
namespace ProjectUI
{
    public class RemoveEmployeeMenu : IMenu
    {
        private IProjectBL _projectBL;
        public RemoveEmployeeMenu(IProjectBL p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Go back");
            Console.WriteLine("[1] Delete by ID");
            //Console.WriteLine("[2] Delete by name");
            Console.WriteLine("=====Employee List=====");
            Console.WriteLine("Names         ||Number        || Email                ||EMPID");
            List<EmployeeModel> listOfEmployee = _projectBL.GetAllEmployee();
            foreach(var item in listOfEmployee)
            {
                Console.WriteLine(Data.ManageSpaceName(item.name) + Data.ManageSpaceNumber(item.number)+ "    " + Data.ManageSpaceEmail(item.email) + "        " +item.employeeID);
            }
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    return "Employee List";
                case "1":
                    //Console.Clear();
                    Console.WriteLine("Enter the ID to delete employee");
                    int userInput2 = Int32.Parse(Console.ReadLine());
                    
                    EmployeeModel employee = new EmployeeModel();
                    List<EmployeeModel> listOfEmployee = _projectBL.GetAllEmployee();
                    employee = listOfEmployee[userInput2];
                    _projectBL.RemoveEmployee(employee);
                    Log.Information("Employee Removed");
                    Console.WriteLine("Employee Removed!");
                    return "Employee List";
                // case "2":
                //     Console.Clear();
                //     return "Delete by name";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "remove an employee";
            }
        }
    }
}