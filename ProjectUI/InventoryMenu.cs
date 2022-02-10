using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class InventoryMenu : IMenu
    {
        private IProjectBLInventory _projectBL;

        public InventoryMenu(IProjectBLInventory p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Back");
            Console.WriteLine("[-1] Log Out");
            Console.WriteLine("enter item ID to add item to cart");
            Console.WriteLine("Current Store Location: " + CurrentCustomer.currentstore.Location);
            Console.WriteLine("=====Item List=====");
            Console.WriteLine("ItemID || Name         || Price   || Category    || Quantity Available");
            List<InventoryModel> listOfInventory = _projectBL.GetAllInventory();
            List<ItemModel> listOfItem = _projectBL.GetAllItem();

            foreach(var inventory in listOfInventory)
            {
                if(inventory.storeID == CurrentCustomer.currentstore.storeID)
                {
                    ItemModel item = _projectBL.SearchItem(inventory.itemID)[0];
                    Console.WriteLine(item.ItemID +"         " + Data.ManageSpaceName(item.ItemName)+ Data.ManageSpacePrice(item.ItemPrice)+ "    "+item.ItemCategory +"       "+ inventory.quantity);
                }
                
                //Console.WriteLine(Data.ManageSpaceName(item.ItemName) + Data.ManageSpacePrice(item.ItemPrice) + "    " + Data.ManageSpaceName(item.ItemCategory) + "          " +item.ItemDescription);
            }
            
        }

        public string UserChoice()
        {
            try
            {
            int UserInput = Int32.Parse(Console.ReadLine());

            if (UserInput == 0)
            {
                Console.Clear();
                return "Choose a store";
            }
            else if (UserInput == -1)
            {
                Console.Clear();
                return "Customer View";
            }
            else if (UserInput > 0)
            {
                Console.Clear();
                return "Display Inventory";
            }
            else
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                return "Display Inventory";
            }
            //return "Display Inventory";
            }
            catch
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                return "Display Inventory";
            }

        }
    }
}