
using BooksWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApp.Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MyDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

    }
}
