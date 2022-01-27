using ProjectModel;
using ProjectDL;
namespace ProjectUI
{
    public class SearchEmployeeOptions : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[0] to go back");
            Console.WriteLine("[1] Search by name");
            Console.WriteLine("[2] Search by phone number");
            Console.WriteLine("[3] Search by phone email");
        }

        public string UserChoice()
        {
            int userInputEmployeeList = Int32.Parse(Console.ReadLine());
            if (userInputEmployeeList == 0)
            {
                Console.Clear();
                return "go back";
            }
            else if (userInputEmployeeList == 1)
            {
                return "search employee by name";
            }
            else if (userInputEmployeeList == 2)
            {
                return "search employee by number";
            }
            else if (userInputEmployeeList == 3)
            {
                return "search employee by email";
            }
            else
            {
                return "Invalid Input";
            }
        }
        public static void SearchByName()
        {
            Console.WriteLine("Enter Employee Name: ");
            string Name = Console.ReadLine();
            List<EmployeeModel> DataList = new List<EmployeeModel>();
            DataList = Serialization.DeserialMain();
            //Console.WriteLine
            Console.WriteLine("========RESULTS========");
            Console.WriteLine("Names        ||Number        || Email        ");
            for (int i = 0; i < DataList.Count(); i++)
            {
                //Console.WriteLine(DataList[0].name);
                if (DataList[i].name.ToLower().Contains(Name.ToLower()))
                {
                    Console.WriteLine(i+1 + "." + Data.ManageSpaceName(DataList[i].name) + Data.ManageSpaceNumber(DataList[i].number)+ "    " + DataList[i].email);
                }
            }
            Console.WriteLine("=====END OF RESULT=====");
            
        }
        
        public static void SearchByNumber()
        {
            Console.WriteLine("Enter Employee Number: ");
            string Number = Console.ReadLine();
            List<EmployeeModel> DataList = new List<EmployeeModel>();
            DataList = Serialization.DeserialMain();
            //Console.WriteLine
            Console.WriteLine("========RESULTS========");
            Console.WriteLine("Names        ||Number        || Email        ");
            for (int i = 0; i < DataList.Count(); i++)
            {
                //Console.WriteLine(DataList[0].name);
                if (DataList[i].number.ToLower().Contains(Number.ToLower()))
                {
                    Console.WriteLine(i+1 + "." + Data.ManageSpaceName(DataList[i].name) + Data.ManageSpaceNumber(DataList[i].number)+ "    " + DataList[i].email);
                }
            }
            Console.WriteLine("=====END OF RESULT=====");
            
        }

        public static void SearchByEmail()
        {
            Console.WriteLine("Enter Employee Email: ");
            string Email = Console.ReadLine();
            List<EmployeeModel> DataList = new List<EmployeeModel>();
            DataList = Serialization.DeserialMain();
            //Console.WriteLine
            Console.WriteLine("========RESULTS========");
            Console.WriteLine("Names        ||Number        || Email        ");
            for (int i = 0; i < DataList.Count(); i++)
            {
                //Console.WriteLine(DataList[0].name);
                if (DataList[i].email.ToLower().Contains(Email.ToLower()))
                {
                    Console.WriteLine(i+1 + "." + Data.ManageSpaceName(DataList[i].name) + Data.ManageSpaceNumber(DataList[i].number)+ "    " + DataList[i].email);
                }
            }
            Console.WriteLine("=====END OF RESULT=====");
            
        }



    }
}