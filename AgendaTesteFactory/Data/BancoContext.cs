using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTesteFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTesteFactory.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnderecoModel>()
                .HasOne(e => e.Cliente)
                .WithOne(c => c.Endereco)
                .HasForeignKey<EnderecoModel>(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
