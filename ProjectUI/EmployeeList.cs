
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
                Console.Clear();
                return "add an employee" ;
            }
            else if (userInputEmployeeList == "2") 
            {
                Console.Clear();
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
                
                Console.Clear();
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Log.Information("INVALID INPUT DETECTED, REROUTE TO EMPLOYEE LIST");
                return "Employee List";
            }
        }

    }
}