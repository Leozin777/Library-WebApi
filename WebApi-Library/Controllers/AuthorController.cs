using Microsoft.AspNetCore.Mvc;
using WebApi_Library.Model.Dto;
using WebApi_Library.Model.Entities;
using WebApi_Library.Model.ViewModels;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Controllers
{
    [Route("api/")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IAuthorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/author")]
        public async Task<IActionResult> GetAllAsync()
        {
            var authorList = await _repository.GetAllAsync();

            List<AuthorDto> authorDtoList = new List<AuthorDto>();
            foreach(Author author in authorList)
            {
                var authorDto = new AuthorDto()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Description = author.Description
                };
                authorDtoList.Add(authorDto);
            }
            return Ok(authorDtoList);
        }

        [HttpGet("api/author/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var author = await _repository.GetByIdAsync(id);
            if(author == null)
                return NotFound();
            else
            {
                var authorDto = new AuthorDto()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Description = author.Description
                };
                return Ok(authorDto);
            }
        }

        [HttpPost("api/author")]
        public async Task<IActionResult> PostAsync([FromBody] AuthorViewModel model)
        {
            var author = new Author()
            {
                Name = model.Name,
                Description = model.Description
            };

            _repository.Save(author);
            await _unitOfWork.commitAsync();
            return Ok(new
            {
                message = "Autor " + author.Name + " foi cadastrado com sucesso!"
            });
        }

        [HttpPatch("api/author/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AuthorViewModel model)
        {
            var author = await _repository.GetByIdAsync(id);

            if (author == null)
                return NotFound();
            else
            {
                author.Name = model.Name;
                author.Description = model.Description;

                _repository.Update(author);
                await _unitOfWork.commitAsync();

                var AuthorDto = new AuthorDto()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Description = author.Description
                };

                return Ok(AuthorDto);
            }
        }

        [HttpDelete("api/author/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var authordel = _repository.Delete(id);
            await _unitOfWork.commitAsync();
            if (authordel == false)
                return NotFound();
            else
                return Ok(id);
        }

    }
}
