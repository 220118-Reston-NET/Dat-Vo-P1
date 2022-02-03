using ProjectBL;
using ProjectDL;
using ProjectModel;
namespace ProjectUI
{
    public class ViewEmployeeList:IMenu
    {
        public void Display()
        {
            List<EmployeeModel> InputList = new List<EmployeeModel>();
            InputList = Serialization.DeserialMain();
            Console.WriteLine("=====Employee List=====");
            Console.WriteLine("Names                ||Number        || Email        ");
            for (int i=0;i<InputList.Count;i++)
            {
                Console.WriteLine(i+1 + "." + Data.ManageSpaceName(InputList[i].name) + Data.ManageSpaceNumber(InputList[i].number)+ "    " + InputList[i].email);

            } 
        }

        public string UserChoice()
        {
            Console.WriteLine("Enter 0 to go back");
            Console.WriteLine("Enter 1 to remove an employee");
            
            string userInput = Console.ReadLine();
            if (userInput == "0")
            {
                Console.Clear();
                return "go back";
            }
            else if (userInput == "1")
            {
                Console.Clear();
                return "remove an employee";
            }
            else
            {
                return "InvalidInput";
            }
        }

    


    }
}
