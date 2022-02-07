using ProjectBL;
using ProjectModel;


namespace ProjectUI
{
    public class ViewItemMenu : IMenu
    {
        private IProjectBLitem _projectBL;
        public ViewItemMenu(IProjectBLitem p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            Console.WriteLine("[0] Go back");
            Console.WriteLine("=====Item List=====");
            Console.WriteLine("Name         || Price   || Category               || Description");
            List<ItemModel> listOfItem = _projectBL.GetAllItem();
            foreach(var item in listOfItem)
            {
                Console.WriteLine(Data.ManageSpaceName(item.ItemName) + Data.ManageSpacePrice(item.ItemPrice) + "    " + Data.ManageSpaceName(item.ItemCategory) + "          " +item.ItemDescription);
            }
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    return "Item List";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "view item list";
            }
        }
    }

}