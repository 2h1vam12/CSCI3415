using System;

public enum GenreType { Blues, Classical, Country, Folk, Jazz, Metal, Pop, RnB, Rock }

public class AudioProduct : Product
{
    private NameType singer;
    private GenreType genre;

    public AudioProduct() : base()
    {
        singer = new NameType("Unknown", "");
        genre = GenreType.Pop;
    }

    public AudioProduct(string name, double price, NameType aSinger) : base(name, price)
    {
        singer = aSinger;
        genre = GenreType.Pop;
    }

    public NameType GetSinger() => singer;
    public GenreType GetGenre() => genre;
    public void SetSinger(NameType s) => singer = s;
    public void SetGenre(GenreType g) => genre = g;

    public override string GetProdTypeStr() => "Music";

    public override void DisplayContentsInfo()
    {
        Console.WriteLine($"Singer Name: {singer}");
        Console.WriteLine($"Genre: {genre}");
    }
}
