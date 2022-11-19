using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;

namespace SuperHeroApi.DbContexts
{
    public class SuerpHeroAccess:DbContext
    {
        public SuerpHeroAccess(DbContextOptions<SuerpHeroAccess> options):base(options)
        {

        }
        public DbSet<SuperHero> superHeroes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero()
                {
                    Id=1,
                    Name="Iron Man",
                    Description="The Iron Man In USA Marvile",
                    Place="NewYork"
                }
                );
        }
    }
}
