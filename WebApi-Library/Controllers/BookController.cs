using Microsoft.AspNetCore.Mvc;
using WebApi_Library.Model.Dto;
using WebApi_Library.Model.Entities;
using WebApi_Library.Model.ViewModels;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Controllers
{
    [Route("api/")]
    public class BookController : ControllerBase
    {
        public readonly IBookRepository _repository;
        public readonly IUnitOfWork _unitOfWork;

        public BookController(IBookRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/book")]
        public async Task<IActionResult> GetAllAsync()
        {
            var bookList = await _repository.GetAllAsync();

            List<BookDto> bookDtoList = new List<BookDto>();
            foreach(Book book in bookList)
            {
                var bookDto = new BookDto()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Genre = book.Genre,
                    Description = book.Description
                };
                bookDtoList.Add(bookDto);
            }
            return Ok(bookDtoList);
        }

        [HttpGet("api/book/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            else
            {
                var bookDto = new BookDto()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Genre = book.Genre,
                    Description = book.Description
                };
                return Ok(bookDto);
            }
        }

        [HttpPost("api/book")]
        public async Task<IActionResult> PostAsync([FromBody] BookViewModel model)
        {
            var book = new Book()
            {
                Name = model.Name,
                Genre = model.Genre,
                Description = model.Description
            };

            _repository.Save(book);
            await _unitOfWork.commitAsync();
            return Ok(new
            {
                message = "Livro " + book.Name + " foi cadastrado com sucesso!"
            });
        }

        [HttpPatch("api/book/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] BookViewModel model)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
                return NotFound();
            else
            {
                book.Name = model.Name;
                book.Genre = model.Genre;
                book.Description = model.Description;

                _repository.Update(book);
                await _unitOfWork.commitAsync();

                var bookDto = new BookDto()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Description = book.Description
                };

                return Ok(bookDto);
            }
        }

        [HttpDelete("api/book/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var bookdel = _repository.Delete(id);
            await _unitOfWork.commitAsync();
            if (bookdel == false)
                return NotFound();
            else
                return Ok(id);
        }

    }
}
