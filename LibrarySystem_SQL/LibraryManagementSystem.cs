using System;
using System.Linq;

public class LibraryManagementSystem
{
    public void AddLibraryItem()
    {
        Console.WriteLine("Choose item type to add (1: Book, 2: Magazine, 3: DVD): ");
        int choice = int.Parse(Console.ReadLine());

        LibraryItem item;
        switch (choice)
        {
            case 1:
                item = new Book { Type = ItemType.Book };
                Console.Write("Enter Book Title: ");
                item.Title = Console.ReadLine();
                Console.Write("Enter Author: ");
                ((Book)item).Author = Console.ReadLine();
                break;
            case 2:
                item = new Magazine { Type = ItemType.Magazine };
                Console.Write("Enter Magazine Title: ");
                item.Title = Console.ReadLine();
                Console.Write("Enter Publisher: ");
                ((Magazine)item).Publisher = Console.ReadLine();
                break;
            case 3:
                item = new DVD { Type = ItemType.DVD };
                Console.Write("Enter DVD Title: ");
                item.Title = Console.ReadLine();
                Console.Write("Enter Genre: ");
                ((DVD)item).Genre = Console.ReadLine();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        // Save the item to the database
        using (var context = new LibraryContext())
        {
            context.LibraryItems.Add(item);
            context.SaveChanges();
        }

        Console.WriteLine("Item added successfully!");
    }

    public void ViewAllItems()
    {
        using (var context = new LibraryContext())
        {
            var items = context.LibraryItems.ToList();
            if (items.Count == 0)
            {
                Console.WriteLine("No items found.");
            }
            else
            {
                Console.WriteLine("\nLibrary Items:");
                foreach (var item in items)
                {
                    item.DisplayDetails();
                }
            }
        }
    }

    public void BorrowItem()
    {
        Console.Write("Enter ID of item to borrow: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new LibraryContext())
        {
            var item = context.LibraryItems.Find(id);
            if (item == null)
            {
                Console.WriteLine("Item not found.");
            }
            else if (item.IsBorrowed)
            {
                Console.WriteLine("Item is already borrowed.");
            }
            else
            {
                item.IsBorrowed = true;
                context.SaveChanges();
                Console.WriteLine("Item borrowed successfully!");
            }
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Library Item");
            Console.WriteLine("2. View All Items");
            Console.WriteLine("3. Borrow Item");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddLibraryItem();
                    break;
                case 2:
                    ViewAllItems();
                    break;
                case 3:
                    BorrowItem();
                    break;
                case 4:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}