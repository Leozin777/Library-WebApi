using Microsoft.AspNetCore.Mvc;
using WebApi_Library.Data;
using WebApi_Library.Model.Dto;
using WebApi_Library.Model.Entities;
using WebApi_Library.Model.ViewModels;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Controllers
{
    [Route("api/")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IClientRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/clients")]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientsList = await _repository.GetAllAsync();

            List<ClientDto> clientsDto = new List<ClientDto>();

            foreach(Client client in clientsList)
            {
                var clientDto = new ClientDto()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Cpf = client.Cpf,
                    PhoneNumber = client.PhoneNumber,
                    Address = client.Address
                };

                clientsDto.Add(clientDto);
            }
            return Ok(clientsDto);
        }

        [HttpGet("api/clients/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
                return NotFound();
            else
            {
                var clientDto = new ClientDto()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Cpf = client.Cpf,
                    PhoneNumber = client.PhoneNumber,
                    Address = client.Address
                };
                return Ok(clientDto);
            }
        }

        [HttpPost("api/clients")]
        public async Task<IActionResult> Post([FromBody] ClientViewModelPost model)
        {
            var client = new Client()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Cpf = model.Cpf,
                Address = model.Address
            };

            _repository.Save(client);
            await _unitOfWork.commitAsync();

            return Ok(new
            {
                message = "Cliente " + client.Name + " foi cadastrado com sucesso!"
            });
        }

        [HttpPatch("api/clients/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ClientViewModelPut model)
        {
            var client = await _repository.GetByIdAsync(id);

            if (client == null)
                return NotFound();
            else
            {
                client.Name = model.Name;
                client.PhoneNumber = model.PhoneNumber;
                client.Address = model.Address;

                _repository.Update(client);
                await _unitOfWork.commitAsync();

                var clientDto = new ClientDto()
                {
                    Id = client.Id,
                    Name = client.Name,
                    PhoneNumber = client.PhoneNumber,
                    Address = client.Address
                };

                return Ok(clientDto);
            }
        }

        [HttpDelete("api/clients/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var clientDel = _repository.Delete(id);
            await _unitOfWork.commitAsync();

            if (clientDel == false)
                return NotFound();
            else
                return Ok(id);
        }

    }
}
