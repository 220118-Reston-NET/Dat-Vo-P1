// See https://aka.ms/new-console-template for more information
using ProjectUI;

bool repeat = true;
IMenu mainmenu = new MainMenu();
IMenu foodmenu = new FoodMenu();
while (repeat)
{
mainmenu.Display();
string ans = mainmenu.UserChoice();

switch (ans)
{
    case "Exit":
        repeat = false;
        break;
    case "FoodMenu":
        foodmenu.Display();
        string result = foodmenu.UserChoice();
        break;
    case "InvalidInput":

        break;
}

}
