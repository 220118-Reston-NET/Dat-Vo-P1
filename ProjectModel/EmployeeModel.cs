namespace ProjectModel
{
    public class EmployeeModel
    {
        public string name { get; set; }
        public string number { get; set; }
        public string email { get; set; }

        public EmployeeModel()
        {
            name = "Default Employee";
            number = "Default Number";
            email = "Default Email";
        }
    }
}