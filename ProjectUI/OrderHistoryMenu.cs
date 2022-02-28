using ProjectModel;
using ProjectBL;
namespace ProjectUI
{
    public class OrderHistoryMenu : IMenu
    {
        private IProjectBLInventory _projectBL;

        public OrderHistoryMenu(IProjectBLInventory p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] View Details");
            Console.WriteLine("=========Order History=========");
            Console.WriteLine("Order ID|| Customer         ||Store Location            || Price  || Date");
            List<OrderModel> ListOfOrder = _projectBL.GetAllOrder();
            foreach(var o in ListOfOrder)
            {
                Console.WriteLine(o.orderID+"          "+Data.ManageSpaceName(_projectBL.GetCustomer(o.customerID).name) +"    "+ Data.ManageSpaceName(_projectBL.GetStore(o.storeID).Name) +"             $"+ o.TotalPrice + "     " + o.datetimeoforder.ToString("MM/dd/yy"));
            }

            Console.WriteLine("========End Of History ========");
        }

        public string UserChoice()
        {
            try
            {
                int UserInput = Int32.Parse(Console.ReadLine());
                if (UserInput == 0)
                {
                    Console.Clear();
                    return "Main Menu";
                }
                else if (UserInput == 1)
                {
                    Console.Clear();
                    return "ViewOrderDetails";
                }
                else
                {
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return "Order History";
                }
            }
            catch
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                return "Order History";
            }
            
        }
    }
}