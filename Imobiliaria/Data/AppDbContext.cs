using Imobiliaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Data;

public class AppDbContext : DbContext
{
    public DbSet<Anuncio>? Anuncios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
}