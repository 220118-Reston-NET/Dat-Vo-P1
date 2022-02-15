using ProjectBL;
using ProjectModel;
namespace ProjectUI
{
    public class ChooseStoreFrontMenu : IMenu
    {
        private IProjectBLStoreFront _projectBL;
        public ChooseStoreFrontMenu(IProjectBLStoreFront p_projectBL)
        {
            _projectBL = p_projectBL;
        }
        public void Display()
        {
            //Console.WriteLine("[0] Log Out");
            Console.WriteLine("Choose a location to shop by entering the store ID.");
            Console.WriteLine("=====StoreFront List=====");
            Console.WriteLine("Store ID || Name         || Location ");
            List<StoreFrontModel> listOfStore = _projectBL.GetAllStoreFront();
            foreach(var store in listOfStore)
            {
                Console.WriteLine(store.storeID + "          " + Data.ManageSpaceName(store.Name) + " " + Data.ManageSpaceName(store.Location));
            }

        }

        public string UserChoice()
        {
            List<StoreFrontModel> listofStore = _projectBL.GetAllStoreFront();

            try
            {
                int UserInput = Int32.Parse(Console.ReadLine());
                CurrentCustomer.SetStoreFront(listofStore[UserInput-1]);
                Console.Clear();
                Log.Information("SET CURRENT STORE TO " + listofStore[UserInput-1].Name);
                return "Display Inventory";
            }
            catch
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                Log.Information("INVALID INPUT DETECTED, REROUTING TO CHOOSE A STORE MENU");
                return "Choose a store";
            }

            

        }
    }
}
