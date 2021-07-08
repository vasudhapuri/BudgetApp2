using System;

public class Expense
{
    public enum SpendingCategory
    {

        Bills,
        Grocery,
        Shopping,
        Travel,
        EMI

    }
    public string CategoryName { get; set; };
    public string CategoryImage { get; set; };
    public int cost { get; set; };
    public string date { get; set; };

    public Expense(SpendingCategory category)
    {
        CategoryName = category;
        CategoryImage = $"Assets/Images/{category}.png";
    }


    
}
}
