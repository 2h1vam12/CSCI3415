using System;

class Program
{
    static void Main(string[] args)
    {
        NameType singer1 = new NameType("Beetles", "");
        NameType singer2 = new NameType("Michael", "Jackson");
        NameType singer3 = new NameType("Taylor", "Swift");

        AudioProduct music1 = new AudioProduct("Yesterday", 16.5, singer1);
        music1.SetGenre(GenreType.Pop);
        music1.SetReviewRate(9.8f);

        AudioProduct music2 = new AudioProduct("We are the World", 13.75, singer2);
        music2.SetGenre(GenreType.Country);
        music2.SetReviewRate(9.1f);

        AudioProduct music3 = new AudioProduct("Love Story", 12.99, singer3);
        music3.SetGenre(GenreType.Folk);
        music3.SetReviewRate(8.9f);

        NameType director1 = new NameType("Robert", "Wise");
        NameType director2 = new NameType("George", "Lucas");

        VideoProduct movie1 = new VideoProduct("Sound of Music", 22.0, director1, 1965, 175);
        movie1.SetFilmRate(FilmRateType.G);
        movie1.SetReviewRate(9.2f);

        VideoProduct movie2 = new VideoProduct("Star Wars", 22.0, director2, 1977, 120);
        movie2.SetFilmRate(FilmRateType.PG);
        movie2.SetReviewRate(8.5f);

        NameType author1 = new NameType("Ernest", "Hemmingway");

        EBook ebook1 = new EBook("The Old Man and the Sea", 8.3, author1, 127);
        ebook1.SetReviewRate(9.5f);

        PaperBook paper1 = new PaperBook("To Kill a Mockingbird", 10.5, new NameType("Harper", "Lee"), 281);
        paper1.SetReviewRate(9.6f);

        NameType owner = new NameType("John", "Smith");
        Cart myCart = new Cart(owner);

        myCart.AddItem(music1);
        myCart.AddItem(music2);
        myCart.AddItem(music3);
        myCart.AddItem(movie1);
        myCart.AddItem(movie2);
        myCart.AddItem(ebook1);
        myCart.AddItem(paper1);
        myCart.SaveCart("cartfile.txt");
        Cart loadedCart = new Cart(new NameType("Shivam", "Pathak"));
        loadedCart.ReadFromFile("cartfile.txt");

        // Remove a product by name
        var found = loadedCart.SearchProduct("Star Wars");
        if (found != null)
        {
            loadedCart.RemoveItem(found.GetProdID());
        }

        // Display remaining items
        loadedCart.DisplayCart();


        myCart.RemoveItem(music2.GetProdID());
        myCart.RemoveItem(paper1.GetProdID());

        myCart.DisplayCart();
        }
    }


