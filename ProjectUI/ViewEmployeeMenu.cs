using ProjectBL;
using ProjectModel;


namespace ProjectUI
{
    public class ViewEmployeeMenu : IMenu
    {
        private IProjectBL _projectBL;
        public ViewEmployeeMenu(IProjectBL p_projectBL)
        {
            _projectBL = p_projectBL;
        }
          
        public void Display()
        {
            Console.WriteLine("[0] Go back");
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
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO VIEW EMPLOYEE LIST MENU");
                    return "view employee list";
            }
        }
    }
}