namespace ProjectModel
{
    public class CustomerModel
    {
        public int customerID { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        

        public CustomerModel()
        {
            name = "";
            //phonenumber = "number";
            //email = "email";
        }
    }

}