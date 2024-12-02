using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

static partial class Program
{
    static void Main(string[] args)
    {

        Library<Book> library = new Library<Book>();

        library.AddBookToLibrary(Book.AddNewBook("C# Programming", "John Doe", 123456789));
        library.AddBookToLibrary(Book.AddNewBook("Learn Python", "Jane Smith", 987654321));
        library.AddBookToLibrary(Book.AddNewBook("Java Fundamentals", "Alice Brown", 112233445));


        System.Console.WriteLine("|``````````````````````````````|");
        System.Console.WriteLine("            All Books           ");
        System.Console.WriteLine("|``````````````````````````````|");
        library.PrintAllBooks();



        List<Book> books = library.Filtration((book) => book.Author == "Jane Smith");
        library.DisplayFilteredBooks("Books by ane Smith", books);


        System.Console.WriteLine("|``````````````````````````````|");
        System.Console.WriteLine("         Using Indexer          ");
        System.Console.WriteLine("|``````````````````````````````|");

        System.Console.WriteLine(library["Learn Python"]);


    }

}




