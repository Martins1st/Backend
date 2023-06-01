using Application.Interfaces.Services;
using Application.ViewModels.Request.Cliente.Post;
using Application.ViewModels.Request.Cliente.Put;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils.Interfaces;
using WebApi.Controllers;

namespace Case.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ClienteController : PrincipalController
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService, INotificador notificador) : base(notificador)
        {
            _clienteService = clienteService;
        }
        
        [HttpGet()]
        public async Task<IActionResult> ObterAsync()
        {
            var response = await _clienteService.BuscarAsync();
            return CustomResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var response = await _clienteService.ObterPorIdAsync(id);
            return CustomResponse(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AdicionarAsync(ClientePostRequest request)
        {
            var response = await _clienteService.AdicionarAsync(request);

            return CustomResponse(response);
        }

        [HttpPut()]
        public async Task<IActionResult> AtualizarAsync(ClientePutRequest request)
        {
            var response = await _clienteService.AtualizarAsync(request);

            return CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarAsync(int id)
        {
            var response = await _clienteService.DesativarAsync(id);

            return CustomResponse(response);
        }
    }
}