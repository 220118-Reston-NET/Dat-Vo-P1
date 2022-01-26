using System.Text.Json;
using ProjectModel;
namespace ProjectDL
{
    public class Serialization
    {
        private static string _filepath = "../ProjectDL/DataBase/";

        public static void SerialMain(List<EmployeeModel> list1)
        {
            string jsonString = JsonSerializer.Serialize(list1, new JsonSerializerOptions {WriteIndented = true});
            //Console.WriteLine("=====Serializing=====");
            //Console.WriteLine(jsonString);       
            //Console.WriteLine("=====================");
            string path = _filepath + "EmployeeList.json";

            //File class will create a JSON file (if there isn't one already) or overwrite
            File.WriteAllText(path, jsonString);  
        }

        public static List<EmployeeModel> DeserialMain()
        {
                string path = _filepath + "EmployeeList.json";
                string jsonString2 = File.ReadAllText(path);     

                List<EmployeeModel> listing = JsonSerializer.Deserialize<List<EmployeeModel>>(jsonString2);
                return listing;
        }

    }
}