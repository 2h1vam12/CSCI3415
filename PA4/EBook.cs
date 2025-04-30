using System;

public class EBook : BookProduct
{
    public EBook() : base() { }

    public EBook(string name, double price, NameType author, int pages)
        : base(name, price, author, pages) { }

    public override string GetProdTypeStr() => "E book";
}
