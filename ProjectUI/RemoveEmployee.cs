using ProjectModel;
using ProjectDL;
namespace ProjectUI
{
    public class RemoveEmployee : IMenu
    {
        public void Display()
        {
            List<EmployeeModel> InputList = new List<EmployeeModel>();
            InputList = Serialization.DeserialMain();
            Console.WriteLine("=====Employee List=====");
            Console.WriteLine("Names        ||Number        || Email        ");
            for (int i=0;i<InputList.Count;i++)
            {
                Console.WriteLine(i+1 + "." + Data.ManageSpaceName(InputList[i].name) + Data.ManageSpaceNumber(InputList[i].number)+ "    " + InputList[i].email);

            } 
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