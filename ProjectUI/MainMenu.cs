
namespace ProjectUI
{
    public class MainMenu : IMenu   
    {
        public void Display()
        {
            Console.WriteLine("==========Main Menu==========");
            Console.WriteLine("[0] Exit Main Menu");
            Console.WriteLine("[1] Employee List");
            Console.WriteLine("[2] Item List"); 
            Console.WriteLine("[3] StoreFront List"); 
            Console.WriteLine("[4] Inventory Management");
            Console.WriteLine("[5] Order History");
            Console.WriteLine("[6] Customer Interface");
            Console.WriteLine("======End of Main Menu=======");

        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    Console.WriteLine("GOOD BYE!");
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "Employee List";
                case "2":
                    Console.Clear();
                    return "Item List";
                case "3":
                    Console.Clear();
                    return "StoreFront Menu";
                case "4":
                    Console.Clear();
                    return "Inventory Management Menu";
                case "5":
                    Console.Clear();
                    return "Order History";
                case "6":
                    Console.Clear();
                    return "Customer View";
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Log.Information("INVALID INPUT DETECTED, REROUT TO MAIN MENU");
                    return "Main Menu";
            }
        
        }
    }
}

