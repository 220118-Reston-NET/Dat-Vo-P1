using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class StoreFrontMenu : IMenu
    {
        private IProjectBLStoreFront _projectBL;
        public StoreFrontMenu(IProjectBLStoreFront p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            //Console.WriteLine("Please Select A Location");
            Console.WriteLine("[0] Back");
            //Console.WriteLine("Choose a location to shop.");
            Console.WriteLine("=====StoreFront List=====");
            Console.WriteLine("Name         || Location ");
            List<StoreFrontModel> listOfStore = _projectBL.GetAllStoreFront();
            foreach(var store in listOfStore)
            {
                Console.WriteLine(Data.ManageSpaceName(store.Name) + " " + Data.ManageSpaceName(store.Location));
            }
        }

        public string UserChoice()
        {
            int UserInput = Int32.Parse(Console.ReadLine());

            if (UserInput == 0)
            {
                Console.Clear();
                return "Main Menu";
            }
            else
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                return "InvalidInput";
            }
        }
    }
}