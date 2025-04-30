using System;
using System.Text;
using System.IO;

public abstract class Product
{
    protected int sentPoint;
    public void SetSentPoint(int val) => sentPoint = val;
    public int GetSentPoint() => sentPoint;
    private static int nextID = 1;
    private int productID;
    private string productName;
    private double price;
    private float reviewRate;

    public Product()
    {
        productID = CreateNewID();
        productName = "!No Name Product!";
        price = 1.0;
        reviewRate = 0.0f;
    }

    public Product(string aProdName, double aPrice)
    {
        productID = CreateNewID();
        productName = string.IsNullOrWhiteSpace(aProdName) ? "!No Name Product!" : aProdName;
        price = (aPrice > 0.0 && aPrice < 1000.0) ? aPrice : 1.0;
        reviewRate = 0.0f;
    }

    // Getters
    public int GetProdID() => productID;
    public string GetProdName() => productName;
    public double GetPrice() => price;
    public float GetReviewRate() => reviewRate;

    // Setters
    public void SetProdID(int id) => productID = id;
    public void SetProdName(string name) => productName = name;
    public void SetPrice(double p) => price = p;
    public void SetReviewRate(float rate) => reviewRate = rate;

    // Static method to generate unique ID
    private static int CreateNewID()
    {
        return nextID++;
    }

    // Abstract methods (must override in subclasses)
    public abstract string GetProdTypeStr();
    public abstract void DisplayContentsInfo();

    // Shared display method
    public virtual void DisplayProdInfo()
    {
        Console.WriteLine($"\n[{GetProdTypeStr()}]");
        Console.WriteLine($"Product ID: {productID}   Product Name: {productName}");
        Console.WriteLine($"Price: ${price}   Product Review Rate: {reviewRate}");
        DisplayContentsInfo(); // abstract hook
    }

    public override string ToString()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            DisplayProdInfo(); // already prints formatted info
            return sw.ToString();
        }
    }

}
