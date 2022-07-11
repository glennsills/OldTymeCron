using Microsoft.EntityFrameworkCore;

namespace TopNews;
public class TopNewsDbContext : DbContext
{
    public DbSet<TopNewsItem> TopNewsItem => Set<TopNewsItem>();

    public string DbPath { get; }

    public TopNewsDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "topnews.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
