using ProjectModel;
namespace ProjectUI
{
    public class AddEmployee
    {
        public static EmployeeModel Display()
        {
            EmployeeModel employee = new EmployeeModel();
            Console.WriteLine("Enter Employee Name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Number:");
            string Number = Console.ReadLine();
            Console.WriteLine("Enter Employee Email:");
            string Email = Console.ReadLine();
            employee.name = Name;
            employee.number = Number;
            employee.email = Email;
            return employee;

        }
    }
}