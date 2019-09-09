using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        // Antes de mudar os Dbsets
        //public DbSet<SalesWebMvc.Models.Departament> Departament { get; set; }

        // Adicionando mais Dbset para mais entidades
        // Depois fazer a migration para atualizar o banco de dados
        public DbSet<Departament> Departament { get; set; }

        public DbSet<Seller> Seller { get; set; }

        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}
