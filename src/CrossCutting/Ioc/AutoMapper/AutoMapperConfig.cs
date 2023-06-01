using Application.ViewModels.Request.Cliente.Post;
using Application.ViewModels.Response.Cliente.Get;
using AutoMapper;
using Domain.Entidades;

namespace Ioc.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClientePostRequest, Cliente>();
            CreateMap<Cliente, ClienteGetResponse>();
        }

    }
}
