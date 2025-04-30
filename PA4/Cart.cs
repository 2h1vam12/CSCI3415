using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



public class Cart
{
    private const int MAX_ITEMS = 7;
    private int itemNum;
    private NameType owner;
    private List<Product> purchasedItems;

    public Cart(NameType theOwner)
    {
        owner = theOwner;
        itemNum = 0;
        purchasedItems = new List<Product>();
    }

    public bool RemoveItem(int productID)
    {
        if (itemNum == 0)
        {
            Console.WriteLine("Cart underflow: the cart is empty");
            return false;
        }

        foreach (var item in purchasedItems)
        {
            if (item.GetProdID() == productID)
            {
                purchasedItems.Remove(item);
                itemNum--;
                return true;
            }
        }

        Console.WriteLine($"Product ID {productID} not found.");
        return false;
    }


    private bool IsCartFull() => itemNum >= MAX_ITEMS;

    public void DisplayCart()
    {
        Console.WriteLine("\nMy Cart");
        Console.WriteLine("=======");
        Console.WriteLine($"\nCart Owner: {owner}\n");

        double total = 0;

        foreach (var item in purchasedItems)
        {
            item.DisplayProdInfo();
            total += item.GetPrice();
        }

        Console.WriteLine("\n===== Summary of Purchase ======");
        Console.WriteLine($"Total number of purchases: {itemNum}");
        Console.WriteLine($"Total purchasing amount: ${total:F2}");
        Console.WriteLine($"Average cost: ${(itemNum > 0 ? total / itemNum : 0):F2}");
    }

    public bool SaveCart(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Product p in purchasedItems)
                {
                    if (p is AudioProduct audio)
                    {
                        writer.WriteLine($"Audio,{audio.GetProdName()},{audio.GetPrice()},{audio.GetSinger()},{audio.GetGenre()},{audio.GetReviewRate()}");
                    }
                    else if (p is VideoProduct video)
                    {
                        writer.WriteLine($"Video,{video.GetProdName()},{video.GetPrice()},{video.GetDirector()},{video.GetReleaseYear()},{video.GetRunTime()},{video.GetFilmRate()},{video.GetReviewRate()}");
                    }
                    else if (p is EBook ebook)
                    {
                        writer.WriteLine($"Ebook,{ebook.GetProdName()},{ebook.GetPrice()},{ebook.GetAuthor()},{ebook.GetPages()},{ebook.GetReviewRate()}");
                    }
                    else if (p is PaperBook pb)
                    {
                        writer.WriteLine($"Paperbook,{pb.GetProdName()},{pb.GetPrice()},{pb.GetAuthor()},{pb.GetPages()},{pb.GetReviewRate()}");
                    }
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool ReadFromFile(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string type = parts[0];
                string name = parts[1];
                double price = double.Parse(parts[2]);

                if (type == "Audio")
                {
                    NameType singer = new NameType(parts[3], "");
                    GenreType genre = Enum.Parse<GenreType>(parts[4]);
                    float rating = float.Parse(parts[5]);
                    AudioProduct a = new AudioProduct(name, price, singer);
                    a.SetGenre(genre);
                    a.SetReviewRate(rating);
                    AddItem(a);
                }
                else if (type == "Video")
                {
                    NameType director = new NameType(parts[3], "");
                    int year = int.Parse(parts[4]);
                    int time = int.Parse(parts[5]);
                    FilmRateType rate = Enum.Parse<FilmRateType>(parts[6]);
                    float rating = float.Parse(parts[7]);
                    VideoProduct v = new VideoProduct(name, price, director, year, time);
                    v.SetFilmRate(rate);
                    v.SetReviewRate(rating);
                    AddItem(v);
                }
                else if (type == "Ebook")
                {
                    NameType author = new NameType(parts[3], "");
                    int pages = int.Parse(parts[4]);
                    float rating = float.Parse(parts[5]);
                    EBook e = new EBook(name, price, author, pages);
                    e.SetReviewRate(rating);
                    AddItem(e);
                }
                else if (type == "Paperbook")
                {
                    NameType author = new NameType(parts[3], "");
                    int pages = int.Parse(parts[4]);
                    float rating = float.Parse(parts[5]);
                    PaperBook p = new PaperBook(name, price, author, pages);
                    p.SetReviewRate(rating);
                    AddItem(p);
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Product SearchProduct(string prodName)
    {
        foreach (Product p in purchasedItems)
        {
            if (p.GetProdName() == prodName)
                return p;
        }
        return null;
    }

    public bool AddItem(Product p)
    {
        if (IsCartFull())
        {
            Console.WriteLine($"Cart overflow: {p.GetProdName()} Prod ID:{p.GetProdID()}, Max items: {MAX_ITEMS}");
            return false;
        }

        purchasedItems.Add(p);
        itemNum++;
        return true;
    }




}
