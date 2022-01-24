namespace ProjectUI
{
    public class BeverageMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("=========Beverages========");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Coca-Cola");
            Console.WriteLine("[2] Dr.Pepper");
            Console.WriteLine("[3] Sprite");
            Console.WriteLine("=====End of Beverages=====");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "";
                case "1":
                    Console.WriteLine("You have selected Coca-Cola");
                    return "";
                case "2":
                    Console.WriteLine("You have selected Dr.Pepper");
                    return "";
                case "3":
                    Console.WriteLine("You have selected Sprite");
                    return "";
                default:
                    Console.WriteLine("");
                    return "";
            }
        

        }

    }
}