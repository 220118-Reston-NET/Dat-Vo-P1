using ProjectModel;
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
                return "go back" ;
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

        // public static EmployeeModel AddEmployee()
        // {
        //     bool repeatNumber = true;
        //     bool repeatEmail = true;
        //     EmployeeModel employee = new EmployeeModel();
        //     Console.WriteLine("Enter Employee Name:");
        //     string Name = Console.ReadLine();
        //     employee.name = Name;

        //     // While loop validating phone number
        //     while (repeatNumber)
        //     {
        //         Console.WriteLine("Enter Employee's Phone Number:");
        //         string Number = Console.ReadLine();
        //         if (Number.Count() == 10)
        //         {
        //             repeatNumber = false;
        //             employee.number = Number;
        //         }
        //         else
        //         {
        //             Console.Clear();
        //             Console.WriteLine("Please enter a valid phone number.");
        //         }
        //     }

        //     // While loop validating email
        //     while (repeatEmail)
        //     {
        //         Console.WriteLine("Enter Employee Email:");
        //         string Email = Console.ReadLine();
        //         if (Email.Contains("@") && Email.Contains(".") )
        //         {
        //             repeatEmail = false;
        //             employee.email = Email;
        //         }
        //         else
        //         {
        //             Console.Clear();
        //             Console.WriteLine("Please enter a valid email number.");
        //         }
        //     }

        //     return employee;

        //}
    }
}