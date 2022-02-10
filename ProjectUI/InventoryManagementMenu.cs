    using ProjectBL;
    using ProjectModel;
    namespace ProjectUI
    {
    public class InventoryManageMentMenu : IMenu
    {
        private IProjectBLInventory _projectBL;
        public InventoryManageMentMenu(IProjectBLInventory p_projectBL)
        {
            _projectBL = p_projectBL;
        }

        public void Display()
        {
            Console.WriteLine("[0] go back");
            Console.WriteLine("Enter storeID to select a store inventory");
            Console.WriteLine("=====StoreFront List=====");
            Console.WriteLine("StoreID ||Name         || Location ");
            List<StoreFrontModel> listOfStore = _projectBL.GetAllStoreFront();
            foreach(var store in listOfStore)
            {
                Console.WriteLine(store.storeID + "         "+Data.ManageSpaceName(store.Name) + " " + Data.ManageSpaceName(store.Location));
            }
        }

        public string UserChoice()
        {
            List<StoreFrontModel> listOfStore = _projectBL.GetAllStoreFront();
            try
            {
                int UserInput = Int32.Parse(Console.ReadLine());
                if (UserInput == 0)
                {
                    Console.Clear();
                    return "Main Menu";
                }
                else if(UserInput > 0 && UserInput <= listOfStore.Count) //&& UserInput < listOfStore.Count+1
                {
                    CurrentCustomer.SetStoreFront(listOfStore[UserInput-1]);
                    Console.Clear();
                    return "Replenish Item Menu";
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue3");
                    Console.ReadLine();
                    return "Inventory Management Menu";
                }
            }
            catch
            {
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue4");
                Console.ReadLine();
                Console.Clear();
                return "Inventory Management Menu";
            }

        }
    }
}