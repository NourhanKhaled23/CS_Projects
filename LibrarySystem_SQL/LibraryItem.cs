using System;
using System.Collections.Generic;
public enum ItemType { Book, Magazine, DVD }


// Base class representing a library item
public abstract class LibraryItem
{
    public int ID { get; set; } // Primary key for the database
    public string Title { get; set; }
    public bool IsBorrowed { get; set; }
    public ItemType Type { get; set; } // To distinguish between Book, Magazine, and DVD

    // Abstract method for displaying details
    public abstract void DisplayDetails();
}







// Derived class for Books
public class Book : LibraryItem
{
    public string Author { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Book - ID: {ID}, Title: {Title}, Author: {Author}, Borrowed: {IsBorrowed}");
    }
}

// Derived class for Magazines
public class Magazine : LibraryItem
{
    public string Publisher { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Magazine - ID: {ID}, Title: {Title}, Publisher: {Publisher}, Borrowed: {IsBorrowed}");
    }
}

// Derived class for DVDs
public class DVD : LibraryItem
{
    public string Genre { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"DVD - ID: {ID}, Title: {Title}, Genre: {Genre}, Borrowed: {IsBorrowed}");
    }
}
