# TinyMart C# Product Catalog System

This project is an object-oriented product catalog system for a fictional store called TinyMart. 


## Project Structure

TinyMart/ │ ├── AudioProduct.cs ├── BookProduct.cs ├── Cart.cs ├── EBook.cs ├── NameType.cs ├── PaperBook.cs ├── Product.cs ├── Program.cs # main driver with test objects and cart logic ├── VideoProduct.cs ├── README.md ├── output.txt # redirected output file (see below) ├── CSCI3415_UMlDiagramHW5.png ├── Report.pdf # Reflective report └── Part1_Answers.pdf # Short answer questions

yaml
Copy
Edit
---

##  Extra Credit Part 1: Features

This project also includes the 7-point Extra Credit:

- `Cart.SaveCart(string filename)` — saves cart items to file in a custom format
- `Cart.ReadFromFile(string filename)` — loads products from a file and recreates them
- `Cart.SearchProduct(string name)` — looks up products in the cart by name
- `Product.sentPoint` — new sentiment score variable added with getter and setter
- `Program.cs` now:
  - Saves a cart to `cartfile.txt`
  - Reads it back into a new cart
  - Searches and removes an item by product name
  - Displays the updated cart

##  How to Run (in Replit or Local)

### In Replit
1. Open the provided Replit link
2. Click the green **"Run"** button at the top.
3. Output will appear in the console.
4. (Optional) Use **file redirection** as described below.

###  Locally
1. Make sure you have the .NET SDK installed:  
   https://dotnet.microsoft.com/en-us/download

2. Open terminal and navigate to the project folder.
3. Run:

```bash
dotnet run
Or redirect output to a text file:

bash
Copy
Edit
dotnet run > output.txt
