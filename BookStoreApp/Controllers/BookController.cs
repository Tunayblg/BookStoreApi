using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? sort = null)
        {
            var books = await _bookService.GetAllAsync(sort);
            return Ok(books);
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok("Kitap Silindi");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id); //Service içindeki GetById Fonksiyonu çagırılır.
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] BookDto bookDto)
        {
            await _bookService.AddAsync(bookDto);
            return Ok("Eklendi");

        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, [FromBody] BookDto bookDto)
        {
            await _bookService.UpdateAsync(id, bookDto);
            return Ok("Güncellendi");
        }







    }
}
