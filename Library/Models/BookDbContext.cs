using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class BookDbContext :DbContext
{
    public DbSet<Book> Books {get;set;}=null!;

    public DbSet<BookType> BookTypes{get;set;}=null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // var Sqlstring = $"server=H-JEONG-LAPTOP;database=Library1;uid=sa;pwd=123456;TrustServerCertificate=true";
        var Sqlstring = $"server=.\\SQLEXPRESS;database=Library1;uid=sa;pwd=123456;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(Sqlstring);
    }

}

// 生成迁移文件  dotnet ef migrations add FirstInit
// 依赖包 dotnet add package Microsoft.EntityFrameworkCore.Design
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// 工具包 dotnet tool install --global dotnet-ef
// 同步到数据库：dotnet ef database update

