using ProjectBL;
using ProjectModel;

namespace ProjectUI
{
    public class AddCustomerMenu : IMenu
    {

        private static CustomerModel _newCustomer = new CustomerModel();

        private IProjectBLCustomer _projectBL;
        public AddCustomerMenu(IProjectBLCustomer p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter your information");
            Console.WriteLine("[4] Name - " + _newCustomer.name);
            Console.WriteLine("[3] Number - " + _newCustomer.phonenumber);
            Console.WriteLine("[2] Email - " + _newCustomer.email);
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
                    return "Customer View";
                case "1":
                    Console.Clear();
                    try
                    {
                        Log.Information("Adding Employee \n" + _newCustomer);
                         _projectBL.AddCustomer(_newCustomer);
                        Log.Information("New User Added!");
                        Console.WriteLine("New User Added!");
                        return "Customer View";

                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add customer.)");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "Customer View";
                case "2":
                    Console.Clear();
                    Console.WriteLine("Please enter your email!");
                    _newCustomer.email = Console.ReadLine();
                    return "New User";
                case "3":
                    Console.Clear();
                    Console.WriteLine("Please enter your phone number!");
                    _newCustomer.phonenumber = Console.ReadLine();
                    return "New User";
                case "4":
                    Console.Clear();
                    Console.WriteLine("Please enter your full name!");
                    _newCustomer.name = Console.ReadLine();
                    return "New User";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "";
            }

        }
    }
}
