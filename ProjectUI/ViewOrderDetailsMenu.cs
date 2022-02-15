using ProjectModel;
using ProjectBL;
namespace ProjectUI
{
    public class ViewOrderDetailsMenu : IMenu
    {
        private IProjectBLInventory _projectBL;

        public ViewOrderDetailsMenu(IProjectBLInventory p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("Enter Order ID to view details");
            Console.WriteLine("=========Order History=========");
            Console.WriteLine("Order ID|| Customer         ||Store Location            || Price");
            List<OrderModel> ListOfOrder = _projectBL.GetAllOrder();
            foreach(var o in ListOfOrder)
            {
                Console.WriteLine(o.orderID+"          "+Data.ManageSpaceName(_projectBL.GetCustomer(o.customerID).name) +"    "+ Data.ManageSpaceName(_projectBL.GetStore(o.storeID).Name) +"             $"+ o.TotalPrice);
            }

            Console.WriteLine("========End Of History ========");
        }

        public string UserChoice()
        {
            try
            {
                int UserInput = Int32.Parse(Console.ReadLine());
                Console.Clear();
                if (UserInput == 0)
                {
                    return "Order History";
                }
    
                List<OrderItemModel> listOfOrderItem = _projectBL.SearchOrderItem(UserInput);
                List<OrderModel> ListOfOrder = _projectBL.GetAllOrder();

                Console.WriteLine("=========Order " + UserInput + " =========");
                Console.WriteLine("Total Price: $" + ListOfOrder[UserInput-1].TotalPrice);
                Console.WriteLine("Item             || Price      ||Quantity     ");
                foreach(var O in listOfOrderItem)
                {
                    
                    Console.WriteLine(Data.ManageSpaceName(_projectBL.GetItem(O.itemID).ItemName)+ "     $" + Data.ManageSpacePrice(_projectBL.GetItem(O.itemID).ItemPrice)+ "     " + O.quantity);
                    //_projectBL.GetItem
                }

                Log.Information("ORDER SELECTED, DISPLAYING ORDER #" + UserInput);
                Console.WriteLine("=============End Of Order=============");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                return "ViewOrderDetails";

            }
            catch
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                Log.Information("INVALID INPUT DETECTED, REROUTING TO VIEW ORDER'S DETAILS MENU");
                return "ViewOrderDetails";   
            }

        }
    }
}
