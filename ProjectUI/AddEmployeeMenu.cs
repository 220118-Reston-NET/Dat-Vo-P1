using ProjectBL;
using ProjectModel;

namespace ProjectUI
{
    public class AddEmployeeMenu : IMenu
    {
        private static EmployeeModel _newEmployee = new EmployeeModel();

        private IProjectBL _projectBL;
        public AddEmployeeMenu(IProjectBL p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter Employee information");
            Console.WriteLine("[4] Name - " + _newEmployee.name);
            Console.WriteLine("[3] Number - " + _newEmployee.number);
            Console.WriteLine("[2] Email - " + _newEmployee.email);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
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
                    try
                    {
                        Log.Information("Adding Employee \n" + _newEmployee);
                        //List<EmployeeModel> ListOfEmployee = _projectBL.GetAllEmployee();
                        // _newEmployee.employeeID = ListOfEmployee.Last().employeeID+1;
                        _projectBL.AddEmployee(_newEmployee);
                        Console.Clear();
                        Log.Information("Employee Added!");
                        Console.WriteLine("Employee Added!");
                        //Console.WriteLine("Employee ID is" + _newEmployee.employeeID);
                        return "Employee List";

                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add employee.)");
                        Console.WriteLine(exc.Message);
                        //Console.WriteLine("Employee ID is " + _newEmployee.employeeID);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "add an employee";
                case "2":
                    Console.WriteLine("Please enter employee's email!");
                    _newEmployee.email = Console.ReadLine();
                    return "add an employee";
                case "3":
                    Console.WriteLine("Please enter employee's phone number!");
                    _newEmployee.number = Console.ReadLine();
                    return "add an employee";
                case "4":
                    Console.WriteLine("Please enter employee's full name!");
                    _newEmployee.name = Console.ReadLine();
                    return "add an employee";

                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "add an employee";
            }

        }
    }
}