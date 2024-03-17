using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PunamFancyJewellers.DataLayer.DataModels;

namespace PunamFancyJewellers.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> ApplicationUsers { get; set; }
    }

}