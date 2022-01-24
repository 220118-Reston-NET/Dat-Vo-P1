namespace ProjectUI
{
    public class FoodMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("==========Food Menu==========");
            Console.WriteLine("[0] BEVERAGES");
            Console.WriteLine("[1] ENTREES");
            Console.WriteLine("[2] SIDES");
            Console.WriteLine("======End Food Menu=======");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    BeverageMenu.Display();

                    return "E";
                case "1":
                    Console.Clear();
                    Console.WriteLine("");
                    return "F";
                default:
                    Console.WriteLine("");
                    return "I";
            }
        }
    }
}