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
                    Console.Clear();
                    return "Main Menu";
                case "1":
                    Console.Clear();
                    return "New User";
                case "2":
                    Console.Clear();
                    return "Login";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO CUSTOMER VIEW");
                    return "Customer View";
            }
        }
    }
}