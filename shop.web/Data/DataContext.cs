namespace shop.web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
