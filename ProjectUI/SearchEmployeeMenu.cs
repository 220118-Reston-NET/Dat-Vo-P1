using ProjectBL;
using ProjectModel;

namespace ProjectUI
{
    public class SearchEmployeeMenu : IMenu
    {
        private IProjectBL _projectBL;
        public SearchEmployeeMenu(IProjectBL p_projectBL)
        {
            _projectBL = p_projectBL;
        }  
        public void Display()
        {
            Console.WriteLine("Please select an option to filter the employee database");
            Console.WriteLine("[1] By Name");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please enter a name");
                    string name = Console.ReadLine();
                    Log.Information("SEARCHING FOR EMPLOYEE");
                    List<EmployeeModel> listOfEmployee = _projectBL.SearchEmployee(name);
                    Console.WriteLine("=====Employee List=====");
                    Console.WriteLine("Names         ||Number        || Email                ||EMPID");       

                    foreach (var item in listOfEmployee)
                    {
                        Console.WriteLine(Data.ManageSpaceName(item.name) + Data.ManageSpaceNumber(item.number)+ "    " + item.email + "        " +item.employeeID);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return "Employee List";
                case "0":
                    Console.Clear();
                    return "Employee List";
                default:
                    Console.Clear();
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO SEARCH EMPLOYEE MENU");
                    return "search for an employee";
            }


        }
    }
}