
namespace ProjectUI
{
    public class EmployeeList : IMenu
    {

        public void Display()
        {
            Console.WriteLine("==========Employee List Menu==========");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Add An Employee");
            Console.WriteLine("[2] Remove an An Employee");
            Console.WriteLine("[3] View Employees");
            Console.WriteLine("[4] Search for an employee");
            Console.WriteLine("======End of Employee List Menu=======");
        }

        public string UserChoice()
        {
            string userInputEmployeeList = Console.ReadLine();
            if (userInputEmployeeList == "0")
            {
                Console.Clear();
                return "Main Menu" ;
            }
            else if (userInputEmployeeList == "1") 
            {
                return "add an employee" ;
            }
            else if (userInputEmployeeList == "2") 
            {
                return "remove an employee" ;
            }
            else if (userInputEmployeeList == "3") 
            {
                Console.Clear();
                return "view employee list" ;
            }
            else if (userInputEmployeeList == "4") 
            {
                Console.Clear();
                return "search for an employee" ;
            }
            else
            {
                return "Invalid Input";
            }
        }

    }
}