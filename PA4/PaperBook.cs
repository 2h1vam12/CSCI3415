using System;

public class PaperBook : BookProduct
{
    public PaperBook() : base() { }

    public PaperBook(string name, double price, NameType author, int pages)
        : base(name, price, author, pages) { }

    public override string GetProdTypeStr() => "Paper book";
}
