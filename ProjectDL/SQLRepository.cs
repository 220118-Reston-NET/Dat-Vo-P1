using ProjectModel;
using System.Data.SqlClient;
namespace ProjectDL
{
    public class SQLRepository:IRepository 
    {
        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            string sqlQuery = @"insert into Employee values(@employeeID, @employeename, @employeenumber, @employeeemail)";

            using (SqlConnection con = new SqlConnection("Server=tcp:project-db-fl.database.windows.net,1433;Initial Catalog=ProjectDB;Persist Security Info=False;User ID=Project0admin;Password=DatVo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@employeeID",employee.employeeID);
                command.Parameters.AddWithValue("@employeename",employee.name);
                command.Parameters.AddWithValue("@employeenumber",employee.number);
                command.Parameters.AddWithValue("@employeeemail",employee.email);

                command.ExecuteNonQuery();
            }

            return employee;
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> listOfEmployee = new List<EmployeeModel>();

            string sqlQuery = @"select * from Employee";

            using (SqlConnection con = new SqlConnection("Server=tcp:project-db-fl.database.windows.net,1433;Initial Catalog=ProjectDB;Persist Security Info=False;User ID=Project0admin;Password=DatVo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfEmployee.Add(new EmployeeModel(){
                        employeeID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        number = reader.GetString(2),
                        email = reader.GetString(3)
                    });
                }

            } 

            return listOfEmployee;
        }
    }
}