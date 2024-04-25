using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodApp.Models;
using System.Security.Principal;

namespace FoodApp.ContextDBConfig
{
    public class FoodAppDBContext : IdentityDbContext<ApplicationUser>
    {

        public FoodAppDBContext(DbContextOptions<FoodAppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Order> Orders { get; set; }


    }
}
