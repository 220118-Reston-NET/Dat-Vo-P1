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
            Console.WriteLine("[5] Name - " + _newCustomer.name);
            Console.WriteLine("[4] Password - " + _newCustomer.password);
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
                        Log.Information("Adding Customer \n" + _newCustomer.name);
                        _projectBL.AddCustomer(_newCustomer);
                        Console.Clear();
                        Log.Information("New customer Added!");
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
                    Log.Information("INPUTING EMAIL");
                    _newCustomer.email = Console.ReadLine();
                    return "New User";
                case "3":
                    Console.Clear();
                    Console.WriteLine("Please enter your phone number!");
                    Log.Information("INPUTING PHONE NUMBER");
                    _newCustomer.phonenumber = Console.ReadLine();
                    return "New User";
                case "4":
                    Console.Clear();
                    Console.WriteLine("Please enter password!");
                    Log.Information("INPUTING PASSWORD");
                    _newCustomer.password = Console.ReadLine();
                    return "New User";
                case "5":
                    Console.Clear();
                    Console.WriteLine("Please enter your full name!");
                    _newCustomer.name = Console.ReadLine();
                    Log.Information("INPUTING NAME");
                    return "New User";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO NEW USER MENU");
                    return "New User";
            }

        }
    }
}
