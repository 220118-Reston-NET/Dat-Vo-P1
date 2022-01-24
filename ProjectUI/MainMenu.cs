
namespace ProjectUI
{
    public class MainMenu : IMenu   
    {
        public void Display()
        {
            Console.WriteLine("==========Main Menu==========");
            Console.WriteLine("[0] Exit Main Menu");
            Console.WriteLine("[1] Food Menu");
            Console.WriteLine("======End of Main Menu=======");

        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Console.WriteLine("GOOD BYE! COME AGAIN");
                    return "Exit";
                case "1":
                    Console.Clear();
                    Console.WriteLine("==========Food Menu==========");
                    return "FoodMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    return "InvalidInput";
            }
        
        }
    }
}

