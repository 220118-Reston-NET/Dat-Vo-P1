namespace ProjectModel;
public class Item
{
    public string Name {get; set;}
    public int Price {get; set;}
    public int CaloricFact {get; set;}
    public string Catergory {get; set;}
    public string Description {get; set;}

    public Item()
    {
        Name = "----";
        Price = 999999;
        CaloricFact = 999999;
        Catergory = "----";
        Description = "Bite-sized pieces of boneless chicken breast, seasoned to perfection, freshly breaded and pressure cooked in 100% refined peanut oil. Available with choice of dipping sauce.";
    }

}
