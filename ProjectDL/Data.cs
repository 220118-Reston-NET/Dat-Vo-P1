// class file Data
namespace ProjectDL
{
public class Data
{
    public static string ManageSpaceName(string Name)
    {
        string nameString = "";
        if (Name.Length > 10)
        {
            nameString = Name.Substring(0, 7) + "....";
        }
        else if (Name.Length <=10)
        {
            int numberOfMisingSpace = new int();
            nameString = Name;
            numberOfMisingSpace = 10-Name.Length;
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


    public static string IndexSearch(string NameInput, List<string> list1, List<string> list2)
    {
        int indexNum = list1.IndexOf(NameInput);
        return list2[indexNum];
        
    }


}

}