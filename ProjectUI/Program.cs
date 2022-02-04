// See https://aka.ms/new-console-template for more information
global using Serilog;
using Microsoft.Extensions.Configuration;
using ProjectUI;
using ProjectModel;
using ProjectDL;
using ProjectBL;

// Creating and configuring logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")    // logger save to this file path
    .CreateLogger();

bool repeat = true;
IMenu currentmenu = new MainMenu();
List<EmployeeModel> ListOfEmployees = new List<EmployeeModel>();
ListOfEmployees = Serialization.DeserialMain();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string _connectionString = configuration.GetConnectionString("Reference2DB");


//==========Test==============
// Console.WriteLine("test");
// currentmenu = new ViewEmployeeMenu(new ProjectBLc(new SQLRepository(_connectionString)));
// currentmenu.Display();
// string anst = currentmenu.UserChoice();
//========Test=================


while (repeat)
{
//Console.WriteLine(currentmenu.GetType()); //display current menu in termninal

currentmenu.Display();

string ans = currentmenu.UserChoice();

switch (ans)
{
    //Main Menu options
    case "Exit":
        Log.Information("EXITING PROGRAM");
        Log.CloseAndFlush();
        repeat = false;
        break;
    case "Main Menu":
        Log.Information("RETURN TO MAIN MENU");
        currentmenu = new MainMenu();
        break;
    case "Employee List":
        Log.Information("OPEN EMPLOYEE LIST");
        currentmenu = new EmployeeList();
        break;
    case "StoreFront Menu":
        Log.Information("OPENING STOREFRONT MENU");
        currentmenu = new StoreFrontMenu();
        break;
    case "Item List":
        currentmenu = new ItemListMenu();
        break;
    case "InvalidInput":
        Log.Information("INVALID INPUT DETECTED");
        Console.WriteLine("Invalid Input");
        break;


    // Employee List options
    case "add an employee":
        Log.Information("OPENING ADD AN EMPLOYEE MENU");
        currentmenu = new AddEmployeeMenu(new ProjectBLc(new SQLRepository(_connectionString)));

        break;
    case "view employee list": 
        Log.Information("OPENING EMPLOYEE LIST");
        currentmenu = new ViewEmployeeMenu(new ProjectBLc(new SQLRepository(_connectionString)));
        break;
    // case "remove an employee":
    //     Log.Information("OPEN REMOVING EMOYPLYEE OPTIONS");
    //     currentmenu = new RemoveEmployee();
    //     break;
    case "search for an employee":
        Log.Information("OPEN SEARCH SEARCH EMPLOYEE MENU");
        currentmenu = new SearchEmployeeMenu(new ProjectBLc(new SQLRepository(_connectionString)));
        break;

    // Remove Employee options
    // case "remove employee by index": 
    //     Log.Information("REMOVING EMPLOYEE BY INDEX");
    //     currentmenu = new RemoveEmployeeIndex();
    //     ListOfEmployees = RemoveEmployeeIndex.UserChoice(ListOfEmployees);
    //     Serialization.SerialMain(ListOfEmployees);
    //     currentmenu = new RemoveEmployee();
    //     break;

    // Search Employee options
    // case "search employee by name":
    //     Log.Information("SEARCHING EMPLOYEE BY NAME");
    //     SearchEmployeeOptions.SearchByName();
    //     currentmenu = new SearchEmployeeOptions();
    //     break;
    // case "search employee by number":
    //     Log.Information("SEARCHING EMPLOYEE BY NUMBER");
    //     SearchEmployeeOptions.SearchByNumber();
    //     currentmenu = new SearchEmployeeOptions();
    //     break;
    // case "search employee by email":
    //     Log.Information("SEARCHING AN EMPLOYEE BY EMAIL");
    //     SearchEmployeeOptions.SearchByEmail();
    //     currentmenu = new SearchEmployeeOptions();
    //     break;

    // Item List Menu Options
    case "add item":
        //currentmenu = new AddItemMenu(new ProjectBLc(new SQLRepository(_connectionString)))
        break;
    case "remove item":

        break;
    case "view item list":

        break;

    // StoreFront
    case "":
        break;


    // default statement
    default:
        Log.Information("DEFAULT CASE (program closed)");
        Log.CloseAndFlush();
        Console.WriteLine("Unaccounted error");
        repeat = false;
        break;
}

}
