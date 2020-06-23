using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pesinho_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pesinho_2._0.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Peso> Pesos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base (options)
        {

        }
    }
}
