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
            string sqlQuery = @"insert into Employee values(@employeename, @employeenumber, @employeeemail)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
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

            using (SqlConnection con = new SqlConnection(_connectionStrings))
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
        public EmployeeModel RemoveEmployee(EmployeeModel employee)
        {
            string sqlQuery = @"delete from Employee where employeeID = @employeeID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@employeeID", employee.employeeID);

                command.ExecuteNonQuery();
            }
            
            return employee;
        }
    

        
        public ItemModel AddItem(ItemModel item)
        {
            string sqlQuery = @"insert into Item values(@ItemName, @ItemPrice, @ItemCategory, @ItemDescription)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();
                //@ItemID, @ItemName, @ItemPrice, @ItemCategory, @ItemDescription
                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@ItemID", item.ItemID);
                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                command.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
                command.Parameters.AddWithValue("@ItemCategory", item.ItemCategory);
                command.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);

                command.ExecuteNonQuery();
            }

            return item;
        }

        public List<ItemModel> GetAllItem()
        {
            List<ItemModel> listOfItem = new List<ItemModel>();

            string sqlQuery = @"select * from Item";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfItem.Add(new ItemModel(){
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        ItemPrice = reader.GetDecimal(2),
                        ItemCategory = reader.GetString(3),
                        ItemDescription = reader.GetString(4)
                    });
                }

            } 
            return listOfItem;
        }

        public ItemModel RemoveItem(ItemModel Item)
        {
            string sqlQuery = @"delete from Item where ItemID = @ItemID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ItemID", Item.ItemID);

                command.ExecuteNonQuery();
            }
            
            return Item;
        }
    }
}