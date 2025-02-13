using System.Text.Json;
using CourseraAPIProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CourseraAPIProject.Controllers 
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookData _bookData;

        public BooksController(IBookData bookData) {
            _bookData = bookData;
        }

        [HttpGet]
        public ActionResult<Book[]> GetBooks() {
            var (books, success) = _bookData.GetBooks();
            if (!success) return NotFound();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetBook(int id) {
            var (book, success) = _bookData.GetBook(id);
            if (!success) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook(int? IdPreferred, Book? bookNew) {
            if(bookNew == null) 
                return BadRequest("Invalid JSON input.");

            (int? id, bool success) = _bookData.AddBook(IdPreferred, bookNew);
            if(!success)
                return BadRequest("Invalid JSON input.");

            return CreatedAtAction(nameof(GetBook), new { id }, bookNew);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Book> UpdateBook(int id, Book? bookUpdated) {
            if(bookUpdated == null) 
                return BadRequest("Invalid JSON input.");

            if(!_bookData.UpdateBook(id, bookUpdated))
                return NotFound();

            return Ok(bookUpdated);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteBook(int id) {
            if (!_bookData.DeleteBook(id)) return NotFound();
            return NoContent();
        }

        public Book? SerializeBook(string body){
            return JsonConvert.DeserializeObject<Book>(body);
        }
    }
}