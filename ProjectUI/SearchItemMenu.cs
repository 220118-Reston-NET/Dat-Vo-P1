using ProjectBL;
using ProjectModel;

namespace ProjectUI
{
    public class SearchItemMenu : IMenu
    {
        private IProjectBLitem _projectBL;
        public SearchItemMenu(IProjectBLitem p_projectBL)
        {
            _projectBL = p_projectBL;
        }  
        public void Display()
        {
            Console.WriteLine("Please select an option to filter the item database");
            Console.WriteLine("[1] By Name");
            Console.WriteLine("[0] Go back");
            // Console.WriteLine("=====Item List=====");
            // Console.WriteLine("Name         || Price   || Category               || Description");
            // List<ItemModel> listOfItem = _projectBL.GetAllItem();
            // foreach(var item in listOfItem)
            // {
            //     Console.WriteLine(Data.ManageSpaceName(item.ItemName) + Data.ManageSpacePrice(item.ItemPrice) + "    " + Data.ManageSpaceName(item.ItemCategory) + "          " +item.ItemDescription);
            // }
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please enter item name");
                    string name = Console.ReadLine();
                    List<ItemModel> listOfItem = _projectBL.SearchItem(name);
                    Console.WriteLine("=====Item List=====");
                    Console.WriteLine("Name         || Price   || Category               || Description");
                    foreach(var item in listOfItem)
                    {
                        Console.WriteLine(Data.ManageSpaceName(item.ItemName) + Data.ManageSpacePrice(item.ItemPrice) + "    " + Data.ManageSpaceName(item.ItemCategory) + "          " +item.ItemDescription);
                    }
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return "Item List";
                case "0":
                    Console.Clear();
                    return "Item List";
                
                default:
                    Console.Clear();
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return "search for an employee";
            }
        }
    }
}