using CourseraAPIProject;

public interface IBookData {
    public  Book[] GetBooks();
    public Book GetBook(int id);
    public int AddBook(Book newBook);
    public int UpdateBook(Book updatedBook);
    public void DeleteBook(Book book);

}

