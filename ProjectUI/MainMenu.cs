
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
            Console.WriteLine("[3] StoreFront"); 
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
                default:
                    Console.WriteLine("Invalid Input");
                    return "InvalidInput";
            }
        
        }
    }
}

