using System.Reflection.Metadata.Ecma335;
using LinqOperators.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinqOperators.Data;

public class NutshellContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // lembrar de excluir o BD e recriar de novo com exemplos do curso dominando ef core
        const string strConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LinqOperators;Integrated Security=True;pooling=True";

        optionsBuilder
            .UseSqlServer(strConnection)
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void  OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
           entity.ToTable("Customer") ;
           entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("Purchase");
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Description).IsRequired();
        });
    }
}