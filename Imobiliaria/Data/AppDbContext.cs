using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Data;

public class AppDbContext : DbContext
{
    public DbSet<Models.Imobiliaria> Imobiliarias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
}