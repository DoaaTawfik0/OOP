
class Book
{
    public string Title { set; get; }
    public string Author { set; get; }
    public int ISBN { set; get; }

    private Book(string title, string author, int isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    public static Book AddNewBook(string title, string author, int isbn)
    {
        return new Book(title, author, isbn);
    }

    public override string ToString()
    {
        return $"Author: {Author,-15} Title: {Title,-20} ISBN: {ISBN}";
    }


}