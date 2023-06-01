using Application.Interfaces.Services;
using Application.ViewModels.Request.Cliente.Post;
using Application.ViewModels.Request.Cliente.Put;
using Application.ViewModels.Response.Cliente.Get;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.UnitOfWork;
using Utils.Interfaces;
using Utils.Models;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly INotificador _notificador;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper,IUnitOfWork uow, INotificador notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _uow = uow;
            _notificador = notificador;
        }
        public async Task<bool> AdicionarAsync(ClientePostRequest request)
        {
            var entidade = _mapper.Map<Cliente>(request);

            await _clienteRepository.AdicionarAsync(entidade);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AtualizarAsync(ClientePutRequest request)
        {
            var entidade = await _clienteRepository.ObterPorId(request.Id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao("Não existe nenhum Cliente com esse ID"));
                return false;
            }

            _clienteRepository.RastrearEntidade(entidade);

            entidade.Nome = request.Nome;
            entidade.OrcamentoInicial = request.OrcamentoInicial;

            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ClienteGetResponse>> BuscarAsync()
        {
            var entidades = await _clienteRepository.ObterAsync();

            var response = _mapper.Map<IEnumerable<ClienteGetResponse>>(entidades);

            return response;
        }

        public async Task<bool> DesativarAsync(int id)
        {
            var entidade = await _clienteRepository.ObterPorId(id);

            if(entidade == null)
            {
                _notificador.Handle(new Notificacao("Não existe nenhum Cliente com esse ID"));
                return false;
            }

            _clienteRepository.RastrearEntidade(entidade);

            entidade.Desativar();

            

            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<ClienteGetResponse> ObterPorIdAsync(int id)
        {
            var entidade = await _clienteRepository.ObterPorId(id);

            if (entidade == null)
            {
                _notificador.Handle(new Notificacao("Não existe nenhum Cliente com esse ID"));
                return null;
            }

            var response = _mapper.Map<ClienteGetResponse>(entidade);

            return response;
        }
    }
}
