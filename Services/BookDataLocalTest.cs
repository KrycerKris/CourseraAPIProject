using CourseraAPIProject.Services.Interfaces;

namespace CourseraAPIProject.Services {
    
    public class BookDataLocalTest : IBookData
    {

        private Dictionary<int, Book> books = new();

        public (int? Id, bool Success) AddBook(int? IdPreffered, Book newBook)
        {
            int id;
            if(IdPreffered == null || books.ContainsKey((int)IdPreffered))
                id = books.Keys.Max() + 1;
            else
                id = (int)IdPreffered;

            books.Add(id, newBook);
            return (id, true);
        }

        public bool DeleteBook(int id)
        {
            if(!books.ContainsKey(id))
                return false;

            books.Remove(id);
            return true;
        }

        public (Book? Book, bool Success) GetBook(int id)
        {
            if(books.TryGetValue(id, out Book? book))
                return (null, false);
            
            return (book, true);
        }

        public (Book[]? Books, bool Success) GetBooks()
        {
            return (books.Values.ToArray(), true);
        }

        public bool UpdateBook(int id, Book bookUpdated)
        {
            if(!books.TryGetValue(id, out Book? bookOld)) 
                return false;
            
            bookOld.Title = bookUpdated.Title;
            bookOld.Author = bookUpdated.Author;
            bookOld.ReleaseYear = bookUpdated.ReleaseYear;
            return true;
        }

    }
}