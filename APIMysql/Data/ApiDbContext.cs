using APIMysql.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMysql.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Itens> Itens { get; set; }
    }
}
