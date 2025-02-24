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
    }
}
