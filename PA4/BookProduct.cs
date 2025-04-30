using System;

public abstract class BookProduct : Product
{
    private NameType author;
    private int pages;

    public BookProduct() : base()
    {
        author = new NameType("Unknown", "");
        pages = 0;
    }

    public BookProduct(string name, double price, NameType a, int p) : base(name, price)
    {
        author = a;
        pages = p;
    }

    public NameType GetAuthor() => author;
    public int GetPages() => pages;

    public void SetAuthor(NameType a) => author = a;
    public void SetPages(int p) => pages = p;

    public override void DisplayContentsInfo()
    {
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Pages: {pages}");
    }

    // Note: GetProdTypeStr() is still abstract here
    public abstract override string GetProdTypeStr();
}
