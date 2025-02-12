using CourseraAPIProject.Services.Interfaces;

namespace CourseraAPIProject.Services {
    
    public class BookDataLocalTest : IBookData
    {

        private List<Book> books = new();

        public (int? Id, bool Success) AddBook(Book newBook)
        {
            newBook.Id = books.Count + 1;
            books.Add(newBook);
            return (newBook.Id, true);
        }

        public bool DeleteBook(int id)
        {
            Book? bookMatching = books.FirstOrDefault(book => book.Id == id);
            if(bookMatching == null) return false;
            
            books.Remove(bookMatching);
            return true;
        }

        public (Book? Book, bool Success) GetBook(int id)
        {
            Book? bookMatching = books.FirstOrDefault(book => book.Id == id);
            if(bookMatching == null) return (null, false);
            
            return (bookMatching, true);
        }

        public (Book[]? Books, bool Success) GetBooks()
        {
            return (books.ToArray(), true);
        }

        public bool UpdateBook(Book updatedBook)
        {
            Book? bookMatching = books.FirstOrDefault(book => book.Id == updatedBook.Id);
            if(bookMatching == null) return false;
            
            bookMatching.Title = updatedBook.Title;
            bookMatching.Author = updatedBook.Author;
            bookMatching.ReleaseYear = updatedBook.ReleaseYear;
            return true;
        }
    }
}