namespace ProjectUI
{
    public class CustomerViewMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[0] go back");
            Console.WriteLine("[1] New User");
            Console.WriteLine("[2] Login");
        }

        public string UserChoice()
        {
            string UserInput = Console.ReadLine();

            switch(UserInput)
            {
                case "0":
                    return "Main Menu";
                case "1":
                    return "New User";
                case "2":
                    return "Login";
                default:
                    return "Invalid Input";
            }
        }
    }
}