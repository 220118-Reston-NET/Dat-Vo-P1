using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class AddItemToOrderMenu : IMenu
    {
        private IProjectBLInventory _projectBL;
        //public List<ItemModel> CurrentCart;

        public AddItemToOrderMenu(IProjectBLInventory p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Go back");
            Console.WriteLine("Enter Item ID to add specificied item to cart");
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
                    return "Display Inventory";
                }
                Console.Clear();
                Console.WriteLine("Enter the amount: ");
                int UserInput2 = Int32.Parse(Console.ReadLine());

                CurrentCustomer.AddItemToCart(_projectBL.GetItem(UserInput));
                CurrentCustomer.currentcartquantity.Add(UserInput2);

                


                int c = new int();
                c = 0;
                Console.WriteLine("=======================Cart=======================");
                foreach(var i in CurrentCustomer.currentcart)
                {
                    Console.WriteLine("- " + i.ItemName + " x" + CurrentCustomer.currentcartquantity[c]);
                    c = c+1;
                }
                Console.WriteLine("====================End of Cart====================");
                return "add item to cart";
            }
            catch
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                return "add item to cart";
            }
        }
    }
}