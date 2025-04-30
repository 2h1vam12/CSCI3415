using System;

public enum FilmRateType { NotRated, G, PG, PG_13, R, NC_17 }

public class VideoProduct : Product
{
    private NameType director;
    private FilmRateType filmRate;
    private int releaseYear;
    private int runTime;

    public VideoProduct() : base()
    {
        director = new NameType("Unknown", "");
        filmRate = FilmRateType.NotRated;
        releaseYear = 2000;
        runTime = 90;
    }

    public VideoProduct(string name, double price, NameType dir, int year, int time) : base(name, price)
    {
        director = dir;
        filmRate = FilmRateType.NotRated;
        releaseYear = year;
        runTime = time;
    }

    public NameType GetDirector() => director;
    public FilmRateType GetFilmRate() => filmRate;
    public int GetReleaseYear() => releaseYear;
    public int GetRunTime() => runTime;

    public void SetDirector(NameType d) => director = d;
    public void SetFilmRate(FilmRateType rate) => filmRate = rate;
    public void SetReleaseYear(int y) => releaseYear = y;
    public void SetRunTime(int t) => runTime = t;

    public bool IsNewRelease(int year) => releaseYear >= year;

    public override string GetProdTypeStr() => "Movie";

    public override void DisplayContentsInfo()
    {
        Console.WriteLine($"Director Name: {director}");
        Console.WriteLine($"Release Year: {releaseYear}");
        Console.WriteLine($"Runtime: {runTime} minutes");
        Console.WriteLine($"Film Rating: {filmRate}");
    }
}
