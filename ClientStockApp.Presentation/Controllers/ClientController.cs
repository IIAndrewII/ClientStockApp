using ClientStockApp.Application.DTOs;
using ClientStockApp.Application.Interfaces;
using ClientStockApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientStockApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientDto clientDto)
        {
            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                PhoneNumber = clientDto.PhoneNumber
            };

            await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDto clientDto)
        {
            var existingClient = await _clientService.GetClientByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.FirstName = clientDto.FirstName;
            existingClient.LastName = clientDto.LastName;
            existingClient.Email = clientDto.Email;
            existingClient.PhoneNumber = clientDto.PhoneNumber;

            await _clientService.UpdateClientAsync(existingClient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
