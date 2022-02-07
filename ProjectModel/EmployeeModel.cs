namespace ProjectModel
{
    public class EmployeeModel
    {
        public int employeeID { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string email { get; set; }

        public EmployeeModel()
        {
            //employeeID = 0;
            name = "Employee Name";
            number = "Employee Number";
            email = "Employee Email";
        }
    }
}