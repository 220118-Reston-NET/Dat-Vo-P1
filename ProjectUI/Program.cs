// See https://aka.ms/new-console-template for more information
global using Serilog;
using Microsoft.Extensions.Configuration;
using ProjectUI;
using ProjectDL;
using ProjectBL;

// Creating and configuring logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")    // logger save to this file path
    .CreateLogger();
//===========================================

bool repeat = true;
IMenu currentmenu = new MainMenu();

// List<EmployeeModel> ListOfEmployees = new List<EmployeeModel>();
// ListOfEmployees = Serialization.DeserialMain();


// String connnection
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string _connectionString = configuration.GetConnectionString("Reference2DB");
//===========================================


//MAIN WHILE LOOP
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
        currentmenu = new StoreFrontMenu(new ProjectBLStoreFront(new SQLRepository(_connectionString)));
        break;
    case "Item List":
        currentmenu = new ItemListMenu();
        break;
    case "Customer View":
        currentmenu = new CustomerViewMenu();
        break;
    case "Order History":
        currentmenu = new OrderHistoryMenu(new ProjectBLInventory(new SQLRepository(_connectionString)));
        break;
    case "Inventory Management Menu":
        currentmenu = new InventoryManageMentMenu(new ProjectBLInventory(new SQLRepository(_connectionString)));
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
    case "remove an employee":
        Log.Information("OPEN REMOVING EMOYPLYEE OPTIONS");
        currentmenu = new RemoveEmployeeMenu(new ProjectBLc(new SQLRepository(_connectionString)));
        break;
    case "search for an employee":
        Log.Information("OPEN SEARCH SEARCH EMPLOYEE MENU");
        currentmenu = new SearchEmployeeMenu(new ProjectBLc(new SQLRepository(_connectionString)));
        break;


    // Item List Menu Options
    case "add item":
        currentmenu = new AddItemMenu(new ProjectBLitem(new SQLRepository(_connectionString)));
        break;
    case "remove item":
        currentmenu = new RemoveItemMenu(new ProjectBLitem(new SQLRepository(_connectionString)));
        break;
    case "view item list":
        currentmenu = new ViewItemMenu(new ProjectBLitem(new SQLRepository(_connectionString)));
        break;
    case "search item":
        currentmenu = new SearchItemMenu(new ProjectBLitem(new SQLRepository(_connectionString)));
        break;


    // Customer View (before log in)
    case "New User":
        currentmenu = new AddCustomerMenu(new ProjectBLCustomer(new SQLRepository(_connectionString)));
        break;
    case "Login":
        currentmenu = new CustomerLoginMenu(new ProjectBLCustomer(new SQLRepository(_connectionString)));
        break;

    // Customer View (Logged in)
    case "Choose a store":
        currentmenu = new ChooseStoreFrontMenu(new ProjectBLStoreFront(new SQLRepository(_connectionString)));
        break;
    case "Display Inventory":
        currentmenu = new InventoryMenu(new ProjectBLInventory(new SQLRepository(_connectionString)));
        break;
    case "add item to cart":
        currentmenu = new AddItemToOrderMenu(new ProjectBLInventory(new SQLRepository(_connectionString)));
        break;

    // Inventory Management Options
    case "Replenish Item Menu":
        currentmenu = new RepleanishItemOptionsMenu(new ProjectBLInventory(new SQLRepository(_connectionString)));
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
