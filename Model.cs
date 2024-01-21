
namespace EFIntro;
using Microsoft.EntityFrameworkCore;

public class User
{
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int? PostID { get; set; }    
  
    
}
public class Post
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime? PublishedOn { get; set; }
    public int? BlogId { get; set; }
    public int? UserId { get; set; }
}

public class Blog
{
    public int? Id { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }
    public int? PostId { get; set; }
}





public class BloggingContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; } 
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path=Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "bloggning.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder option) =>
        option.UseSqlite($"data source={DbPath}");
 
}

