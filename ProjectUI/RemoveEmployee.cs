namespace ProjectUI
{
    public class RemoveEmployee : IMenu
    {
        public void Display()
        {
            throw new NotImplementedException();
        }

        public string UserChoice()
        {
            Console.WriteLine("[0] cancels");
            Console.WriteLine("[1] delete by index");
            int userInputEmployeeList = Int32.Parse(Console.ReadLine());
            if (userInputEmployeeList == 0)
            {
                Console.Clear();
                return "go back";
            }
            else if (userInputEmployeeList == 1)
            {
                return "remove employee by index";
            }
            else
            {
                return "Invalid Input";
            }
        }
    }

}