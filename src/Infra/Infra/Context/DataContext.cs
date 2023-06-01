using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    this.ObterDataCriacao(entry);
                }

                if (entry.State == EntityState.Modified)
                {
                    this.ObterDataAtualizacao(entry);
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private void ObterDataCriacao(EntityEntry entry)
        {
            if (entry.Entity.GetType().GetProperty("DataCriacao") != null)
            {
                entry.Property("DataCriacao").CurrentValue = DateTime.Now;
            }
        }

        private void ObterDataAtualizacao(EntityEntry entry)
        {
            if (entry.Entity.GetType().GetProperty("DataAtualizacao") != null)
            {
                entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
            }

            if (entry.Entity.GetType().GetProperty("DataCriacao") != null)
            {
                entry.Property("DataCriacao").IsModified = false;
            }
        }

    }
}
