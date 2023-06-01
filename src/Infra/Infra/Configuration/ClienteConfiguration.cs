using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entidades;

namespace Infra.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.OrcamentoInicial);
            builder.Property(x => x.DataAtualizacao);
            builder.Property(x => x.EstaAtivo);
        }
    }
}
