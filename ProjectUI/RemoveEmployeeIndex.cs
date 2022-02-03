using ProjectModel;
namespace ProjectUI
{
    public class RemoveEmployeeIndex : ViewEmployeeList
    {
        public static List<EmployeeModel> UserChoice(List<EmployeeModel> list1)
        {
            //Console.WriteLine("[0] cancels");
            Console.WriteLine("Enter the index number to delete employee from database.");
            try
            {
                int userInput = Int32.Parse(Console.ReadLine());
                if (userInput == 0)
                {
                    //return list1;
                    Console.Clear();
                    throw new Exception("Please Enter A Phone Number");
                }
                else if (userInput > 0)
                {
                    list1.RemoveAt(userInput-1);
                    Console.Clear();
                    Console.WriteLine("DataBase Updated");
                    return list1;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
            }
            return list1;
        }
    }
}