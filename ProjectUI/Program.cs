// See https://aka.ms/new-console-template for more information
using ProjectUI;
using ProjectModel;
using ProjectDL;

bool repeat = true;
IMenu currentmenu = new MainMenu();
List<EmployeeModel> ListOfEmployees = new List<EmployeeModel>();
ListOfEmployees = Serialization.DeserialMain();

while (repeat)
{
Console.WriteLine(currentmenu.GetType());
//currentmenu = new RemoveEmployee();
if (currentmenu.GetType() == typeof(ViewEmployeeList) || currentmenu.GetType() == typeof(RemoveEmployee) || currentmenu.GetType() == typeof(RemoveEmployeeIndex)) 
{
    ViewEmployeeList.Display(ListOfEmployees);
}
else
{
    currentmenu.Display();
}

// if (currentmenu.GetType() == typeof(RemoveEmployeeIndex))
// {
//     RemoveEmployeeIndex.UserChoice(ListOfEmployees);
// }

string ans = currentmenu.UserChoice();

switch (ans)
{
    //back button for all menu
    case "go back":
        if (currentmenu.GetType() == typeof(EmployeeList))
        {
            currentmenu = new MainMenu();
        }
        else if (currentmenu.GetType() == typeof(ViewEmployeeList))
        {
            currentmenu = new EmployeeList();
        }
        else if (currentmenu.GetType() == typeof(RemoveEmployee))
        {
            currentmenu = new ViewEmployeeList();
        }
        break;
    //Main Menu options
    case "Exit":
        repeat = false;
        break;
    case "Employee List":
        currentmenu = new EmployeeList();
        break;
    case "InvalidInput":
        Console.WriteLine("Invalid Input");
        break;
    // Employee List options
    case "add an employee":
        ListOfEmployees.Add(AddEmployee.Display());
        Serialization.SerialMain(ListOfEmployees);
        break;
    case "view employee list": 
        currentmenu = new ViewEmployeeList();
        break;
    case "remove an employee":
        currentmenu = new RemoveEmployee();
        break;
    case "search for an employee":
        currentmenu = new SearchEmployeeOptions();
        break;
    // Remove Employee options
    case "remove employee by index": 
        currentmenu = new RemoveEmployeeIndex();

        ListOfEmployees = RemoveEmployeeIndex.UserChoice(ListOfEmployees);
        Serialization.SerialMain(ListOfEmployees);
        currentmenu = new RemoveEmployee();
        break;

    // Search Employee options
    case "":

        break;

    // default statement
    default:
        Console.WriteLine("Unaccounted error");
        repeat = false;
        break;


}

}
