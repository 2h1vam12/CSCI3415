## Abstract
For this project, I implemented it in C# and created a product catalog system for TinyMart. C# is a statically typed, OOP language made by Microsoft that runs on their .Net framework. It is mostly used for desktop applications, web development, and enterprise systems. C# has support for key OOP features from all 4 pillars of OOP which make it suitable for large scale modular systems. This project allowed me to apply these principles to products and their relationships 

## Approach 
I began by creating a UML Diagram on Lucidcharts, identifying the base class as Product and the derived classes: AudioProduct, VideoProduct, and BookProduct. Then I identified subclasses from BookProduct: Ebook and PaperBook. 

I divided all of these classes into a separate .cs file for modularity:

- Product.cs: Abstract base class 
  - AudioProduct.cs, VideoProduct.cs, BookProduct.cs, EBook.cs, PaperBook.cs
- Cart.cs: Handle shopping logic
- Program.cs: main for testing

Polymorphism was also tested by adding various product types to the cart and invoking the DisplayProdInfo method to make sure there is a correct method dispatch.

## Key Learnings

- How to use abstract classes and override methods with virtual and override.
- Implementing custom enums (GenreType, FilmRateType) in a clean way to enhance flexibility
- Using inheritance and method overriding for specialized class behaviors.
- How to structure a multi file project in C# and avoid circular dependencies.
- How important a centralized static ID generator is for tracking unique products

## Unique or Distinctive Features 

- C# has the ability to explicitly mark method as virtual, override, or abstract that helped me enforce good design disciplines
- ToString() could be overridden to provide a default object representation through the product info display method
- C# offers LINQ, delegates, and events that all improve scalability. I did not use this but I remember from my research.

## Likes and Dislikes 

- Likes: Strong type checking and IntelliSense support which made debugging way easier. The structure of access modifiers like private/public/protected kept all my classes clean and encapsulated.
- Dislikes: Very verbose or verb heavy in method and property declarations compared to languages like python. More complex syntax for defining simple data holding objects like NameType.

## Additional Notes

One challenge I had was managing object relationships while keeping my UML accurate. For example, making sure BookProduct was abstract so EBook and PaperBook can extend it without instantiation errors. Another challenge I faced was logic errors when making sure MAX_ITEMS in Cart.cs were enforced correctly and then adding and removing logic. 

## Conclusion 

This project refreshed my memory from OOP but also improved my understanding on how to structure and test a class hierarchy in an effective way. It helped to reinforce the importance of a clean interface design, inheritance structure, and method overriding. I feel way more confident working with OOP in C# and a lot of C related languages, and I liked the support for modular and scalable software development.
