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
            Console.WriteLine("Enter Employee information");
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
                        List<ItemModel> ListOfItem = _projectBL.GetAllItem();
                        _newItem.ItemID = ListOfItem.Count+1;
                        _projectBL.AddItem(_newItem);
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
                case "3":
                    Console.Clear();
                    return "add item";
                case "4":
                    Console.Clear();
                    return "add item";
                case "5":
                    Console.Clear();
                    return "add item";
                default:
                    return " ";
            }
        }
    }

}