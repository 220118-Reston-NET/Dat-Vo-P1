namespace ProjectUI
{
    public class StoreFrontMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Please Select A Location");
            Console.WriteLine("[0] Back");

        }

        public string UserChoice()
        {
            int UserInput = Int32.Parse(Console.ReadLine());

            if (UserInput == 0)
            {
                Console.Clear();
                return "go back";
            }
            else if (UserInput > 0)
            {
                Console.Clear();
                return "item" + UserInput.ToString();
            }
            else
            {
                
                return "InvalidInput";
            }
        }
    }
}