// class file Data
namespace ProjectBL
{
public class Data
{
    public static string ManageSpaceName(string Name)
    {
        string nameString = "";
        if (Name.Length > 14)
        {
            nameString = Name.Substring(0, 10) + "....";
        }
        else if (Name.Length <=14)
        {
            int numberOfMisingSpace = new int();
            nameString = Name;
            numberOfMisingSpace = 14-Name.Length;
            for (int a = 0; a < numberOfMisingSpace+1; a++)
            {
                nameString = nameString + " ";
            }
        }
        return nameString;
    }

    public static string ManageSpaceNumber(string phoneNumber)
    {

        string numberString = "";
        numberString = " #" + phoneNumber;
        return numberString;
    }

    public static string ManageSpaceEmail(string email)
    {
        string emailString = "";
        if (email.Length > 20)
        {
            emailString = email.Substring(0, 16) + ".....";
        }
        else if (email.Length <=20)
        {
            int numberOfMisingSpace = new int();
            emailString = email;
            numberOfMisingSpace = 20-email.Length;
            for (int a = 0; a < numberOfMisingSpace+1; a++)
            {
                emailString = emailString + " ";
            }
        }
        return emailString;
    }

    public static string ManageSpacePrice(decimal price)
    {
        string priceString = "";
        //price.ToString().Length;
        int numberOfMisingSpace = new int();
        priceString = price.ToString();
        numberOfMisingSpace = 7-priceString.Length;

        for (int a = 0; a < numberOfMisingSpace+1; a++)
        {
            priceString = priceString + " ";
        }
        return priceString;
    }



}

}