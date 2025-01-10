using System.Globalization;
using ProductManager.Entities;

namespace ProductManager;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        
        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("---------------------------------------------");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Product #{i + 1} data:");
            
            Console.Write("Common, used or imported (c/u/i)? ");
            char ch = char.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            switch (ch)
            {
                case 'c':
                    products.Add(new Product(name, price));
                    break;
                case 'u':
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateOnly manufactureDate = DateOnly.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    
                    Product usedProduct = new UsedProduct(name, price, manufactureDate);
                    products.Add(usedProduct);
                    break;
                case 'i':
                    Console.Write("Customs fee: ");
                    double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    
                    Product importedProduct = new ImportedProduct(name, price, fee);
                    products.Add(importedProduct);
                    break;
                default:
                    break;
            }
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine("");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Price Tags");
        
        foreach (var product in products)
        {
            Console.WriteLine(product.PriceTag());
        }
        
    }
}