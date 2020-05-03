namespace shop.web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Country> countries{ get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
