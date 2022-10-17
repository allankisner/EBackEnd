using EBackEnd.Models;
using EBackEnd.Service;
using Microsoft.EntityFrameworkCore;

namespace EBackEnd.Data
{
    public class EwaveDbContext : DbContext 
    {
        public EwaveDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    modelBuilder.Entity<Produto>().HasData(
        //        new Produto
        //        {
        //        //return ApiService.ObterProdutos();*/
        //        }
        //        ) ;

        //    modelBuilder.Entity<Cliente>().HasData(
        //        new Cliente
        //        {

        //        }
        //        );

        //    modelBuilder.Entity<Venda>().HasData(
        //        new Produto
        //        {

        //        }
        //        );
        //}
      
    }
}
