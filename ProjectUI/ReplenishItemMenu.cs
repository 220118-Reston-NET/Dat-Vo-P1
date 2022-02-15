using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class RepleanishItemOptionsMenu : IMenu
    {
        //ItemModel item = new ItemModel();
        private IProjectBLInventory _projectBL;
        public RepleanishItemOptionsMenu(IProjectBLInventory p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Back");
            Console.WriteLine("[1] Update Quantity");
            Console.WriteLine("Store: " + CurrentCustomer.currentstore.Name);
            Console.WriteLine("=========Items==========");
            Console.WriteLine("Item ID || Item         || Price  || Categeory || Quantity");

            List<ItemModel> listOfItem = _projectBL.GetAllItem();
            List<InventoryModel> listOfinventory = _projectBL.GetAllInventory();
            InventoryModel inventoryI = new InventoryModel();
            foreach(var item in listOfItem)
            {
                foreach(var i in listOfinventory)
                {
                    if (i.itemID == item.ItemID && i.storeID == CurrentCustomer.currentstore.storeID)
                    {
                        inventoryI = i;
                    }
                }
                Console.WriteLine(item.ItemID +"          "+ Data.ManageSpaceName(item.ItemName) + Data.ManageSpacePrice(item.ItemPrice)+"   " + item.ItemCategory+"      " + inventoryI.quantity);

            }
        }

        public string UserChoice()
        {
            InventoryModel inven = new InventoryModel();
            CurrentCustomer.currentinventory = inven;
            try
            {
                int UserInput = Int32.Parse(Console.ReadLine());
                if (UserInput == 0)
                {
                    Console.Clear();
                    return "Inventory Management Menu";
                }
                else if (UserInput == 1)
                {
                    Console.WriteLine("Enter Item ID");
                    int UserInput2 = Int32.Parse(Console.ReadLine());
                    CurrentCustomer.SetInventoryitemID(UserInput2);
                    CurrentCustomer.SetInventoryStoreID(CurrentCustomer.currentstore.storeID);
                    Console.WriteLine("Enter amount");
                    int UserInput3 = Int32.Parse(Console.ReadLine());
                    CurrentCustomer.SetInventoryQuantity(UserInput3);
                    _projectBL.UpdateInventory(CurrentCustomer.currentinventory);

                    Log.Information("INVENTORY UPDATED");
                    Console.Clear();
                    return "Replenish Item Menu";
                }
                else
                {
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO REPLENISH ITEM MENU");
                    return "Replenish Item Menu";
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue5");
                Console.ReadLine();
                Log.Information("INVALID INPUT DETECTED, REROUTING TO REPLENISH ITEM MENU");
                return "Replenish Item Menu";
            }

        }
    }
}