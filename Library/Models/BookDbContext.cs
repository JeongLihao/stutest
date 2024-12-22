using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class BookDbContext :DbContext
{
    public DbSet<Book> Books {get;set;}=null!;

    public DbSet<Type> Types{get;set;}=null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var Sqlstring = $"server=H-JEONG-LAPTOP;database=Library1;uid=sa;pwd=123456;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(Sqlstring);
    }
}