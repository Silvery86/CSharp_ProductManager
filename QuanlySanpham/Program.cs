using System;
using System.Collections.Generic;

namespace QuanlySanpham;


class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Program
{
    static List<Product> products = new List<Product>();

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("Product Management System");
            Console.WriteLine("1. Add product records");
            Console.WriteLine("2. Display product records");
            Console.WriteLine("3. Delete product by Id");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProduct();
                    WantToContinue();
                    break;
                case 2:
                    DisplayProducts();
                    break;
                case 3:
                    DeleteProduct();
                   
                    break;
                case 4:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            Console.WriteLine();
        } while (choice != 4);
    }

    static void AddProduct()
    {
        Console.WriteLine("Enter product details:");
        Console.Write("Product ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());
        products.Add(new Product { ProductId = id, Name = name, Price = price });
        Console.WriteLine("Product added successfully.");
    }

    static void DisplayProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        Console.WriteLine("Product ID\tName\tPrice");
        foreach (Product product in products)
        {
            Console.WriteLine("{0}\t{1}\t{2:C}", product.ProductId, product.Name, product.Price);
        }
    }

    static void DeleteProduct()
    {
        Console.Write("Enter Product ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        int index = products.FindIndex(p => p.ProductId == id);
        if (index == -1)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        products.RemoveAt(index);
        Console.WriteLine("Product deleted successfully.");
    }

    static void WantToContinue()
    {
        string input;
        do
        {
            Console.Write("Do you want to continue (Y/N)? ");
            input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                AddProduct();
                continue;
                
            }
            if (input == "n")
            {
                Main();
            }
            Console.WriteLine("Invalid input. Please enter Y or N.");

        }
        while (input != "n" || input != "N");
        
    }
}

