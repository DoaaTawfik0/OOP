class Library<T> where T : Book
{
    private List<T> Books = new List<T>();

    public void AddBookToLibrary(T book)
    {
        Books.Add(book);
    }

    public T? this[string title]
    {
        get { return Books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase)); }
    }

    public delegate bool DelFilter(T b);

    public List<T> Filtration(DelFilter filter)
    {
        List<T> FilteredBooks = new List<T> { };
        foreach (var book in Books)
        {
            if (filter(book))
            {
                FilteredBooks.Add(book);
            }
        }
        return FilteredBooks;
    }

    public void DisplayFilteredBooks(string header, List<T> filteredBooks)
    {
        Console.WriteLine("|" + new string('-', 30) + "|");
        Console.WriteLine("        " + header + "        ");
        Console.WriteLine("|" + new string('-', 30) + "|");
        foreach (var book in filteredBooks)
        {
            Console.WriteLine(book);
        }
    }

    public void PrintAllBooks()
    {
        foreach (var book in Books)
        {
            Console.WriteLine(book);
        }
    }
}
