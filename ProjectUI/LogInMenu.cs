namespace ProjectUI
{
    public class LogInMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[0] Exit Program");
            Console.WriteLine("[1] Customer Login");
            Console.WriteLine("[2] Employee Login");
        }

        public string UserChoice()
        {
            string UserInput = Console.ReadLine();
            switch(UserInput)
            {
                case "0":
                    Console.Clear();
                    return "Exit";
                case "1":
                    Console.Clear();
                    return "Customer View";
                case "2":
                    Console.Clear();
                    return "Employee Login";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    Log.Information("INVALID INPUT DETECTED, REROUTING TO ADD AN EMPLOYEE MENU");
                    Console.Clear();
                    return  "LogInMenu";
            }
        }
    }
}