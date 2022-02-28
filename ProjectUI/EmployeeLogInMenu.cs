using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class EmployeeLogInMenu : IMenu
    {
        private IProjectBL _projectBL;
        public EmployeeLogInMenu(IProjectBL p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter your employeeID");
        }

        public string UserChoice()
        {
            //try
            //{
                int UserInput = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter your password");
                string passwordInput = (Console.ReadLine());

                List<EmployeeModel> listOfEmployee = _projectBL.GetAllEmployee();
                foreach(var c in listOfEmployee)
                {
                    if (c.employeeID == UserInput)
                    {
                        if(passwordInput == c.password)
                        {
                            CurrentCustomer.SetEmployee(c);
                        }
                        else
                        {
                            throw new Exception("Incorrect UserID or Password");
                        }

                    }
                }
                Console.Clear();
                Console.WriteLine("Hello " + CurrentCustomer.currentemployee.name);
                Log.Information("SUCCESSFULLY LOGGED IN AS " + CurrentCustomer.currentemployee.name);
                return "Main Menu";
            //}
            // catch(System.Exception exc)
            // {
            //     Console.Clear();
            //     Console.WriteLine(exc.Message);
            //     Console.WriteLine("Please press Enter to continue");
            //     Console.ReadLine();
            //     Log.Information("FAILED LOG IN ATTEMPT, REROUTING TO LOGIN MENU");
            //     return "Employee Login";
            // }
            
        }
    }
}