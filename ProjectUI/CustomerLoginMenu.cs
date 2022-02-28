using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class CustomerLoginMenu : IMenu
    {
        private IProjectBLCustomer _projectBL;
        public CustomerLoginMenu(IProjectBLCustomer p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter your userID");
            // Console.WriteLine("=====Customer List=====");
            // Console.WriteLine("Names         ||Number        || Email                ||CustomerID");
            // List<CustomerModel> listOfCustomer = _projectBL.GetAllCustomer();
            // foreach(var item in listOfCustomer)
            // {
            //     Console.WriteLine(Data.ManageSpaceName(item.name) + Data.ManageSpaceNumber(item.phonenumber)+ "    " + Data.ManageSpaceEmail(item.email) + "        " +item.customerID);
            // }
        }

        public string UserChoice()
        {

            try
            {
                int UserInput = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter your password");
                string passwordInput = (Console.ReadLine());

                List<CustomerModel> listOfCustomer = _projectBL.GetAllCustomer();
                foreach(var c in listOfCustomer)
                {
                    if (c.customerID == UserInput)
                    {
                        if(passwordInput == c.password)
                        {
                            CurrentCustomer.SetCustomer(c);
                        }
                        else
                        {
                            throw new Exception("Incorrect UserID or Password");
                        }

                    }
                }
                Console.Clear();
                Console.WriteLine("Hello " + CurrentCustomer.currentcustomer.name);
                Log.Information("SUCCESSFULLY LOGGED IN AS " + CurrentCustomer.currentcustomer.name);
                return "Choose a store";
            }
            catch (System.Exception exc)
            {
                Console.Clear();
                Console.WriteLine(exc.Message);
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Log.Information("FAILED LOG IN ATTEMPT, REROUTING TO LOGIN MENU");
                return "Login";
            }

        }

    }
}