using Microsoft.EntityFrameworkCore;

using LibraryReactPOC.Server.Models;

namespace LibraryReactPOC.Server.Infrastructure
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
