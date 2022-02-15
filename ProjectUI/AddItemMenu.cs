using ProjectBL;
using ProjectModel;

namespace ProjectUI
{
    public class AddItemMenu : IMenu
    {
        private static ItemModel _newItem = new ItemModel();

        private IProjectBLitem _projectBL;
        public AddItemMenu(IProjectBLitem p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("Enter Item information");
            Console.WriteLine("[5] Name - " + _newItem.ItemName);
            Console.WriteLine("[4] Price - " + _newItem.ItemPrice);
            Console.WriteLine("[3] Description - " + _newItem.ItemDescription);
            Console.WriteLine("[2] Category - " + _newItem.ItemCategory);
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
                    return "Item List";
                case "1":
                    try
                    {
                        Log.Information("Adding Item \n" + _newItem);
                        InventoryModel _newinventory = new InventoryModel();

                        List<StoreFrontModel> ListOfStoreFront = _projectBL.GetAllStoreFront();
                        ///_newItem.ItemID = ListOfItem.Count+1;
                        _projectBL.AddItem(_newItem);
                        List<ItemModel> ListOfItem = _projectBL.GetAllItem();

                        foreach(var s in ListOfStoreFront)
                        {
                            _newinventory.storeID = s.storeID;
                            _newinventory.itemID = ListOfItem.Last().ItemID;
                            _newinventory.quantity = 0;
                            _projectBL.AddInventory(_newinventory);

                        }

                        Console.Clear();
                        Log.Information("Item Added!");
                        Console.WriteLine("Item Added!");
                        return "Item List";

                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add item.)");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "add item";
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter Item category");
                    Log.Information("USER INPUTTING ITEM CATEGORY");
                    _newItem.ItemCategory = Console.ReadLine();
                    return "add item";
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter Item description");
                    Log.Information("USER INPUTTING ITEM DESCRIPTION");
                    _newItem.ItemDescription = Console.ReadLine();
                    return "add item";
                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter Item price");
                    Log.Information("USER INPUTTING ITEM PRICE");
                    _newItem.ItemPrice = Convert.ToDecimal(Console.ReadLine());
                    return "add item";
                case "5":
                    Console.Clear();
                    Console.WriteLine("Enter Item name");
                    Log.Information("USER INPUTTING ITEM NAME");
                    _newItem.ItemName = Console.ReadLine();
                    return "add item";
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO ADD ITEM MENU");
                    return "add item";
            }
        }
    }

}