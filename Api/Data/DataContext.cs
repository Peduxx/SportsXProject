using Api.Models;
using Microsoft.EntityFrameworkCore;
using VettaProject.Api.Models;

namespace Api.Data
{
    //Contexto de dados do projeto.
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasMany(client => client.PhoneNumber)
                .WithOne();
        }
    }
}