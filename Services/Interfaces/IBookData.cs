using CourseraAPIProject;
using Microsoft.AspNetCore.Http;

namespace CourseraAPIProject.Services.Interfaces
{
    public interface IBookData {
        public (Book[]? Books, bool Success) GetBooks();
        public (Book? Book, bool Success) GetBook(int id);
        public (int? Id, bool Success) AddBook(int? idPreferred, Book bookNew);
        public bool UpdateBook(int id, Book bookUpdated);
        public bool DeleteBook(int id);
    }
}

