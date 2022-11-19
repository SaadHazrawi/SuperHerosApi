using Microsoft.EntityFrameworkCore;
using SuperHeroApi.DbContexts;
using SuperHeroApi.DTOS;
using SuperHeroApi.Models.InterFAce;

namespace SuperHeroApi.Models.Repostriy
{
    public class SuperHeroRepostriy : ISuperHero
    {
        private readonly SuerpHeroAccess _context;

        public SuperHeroRepostriy(SuerpHeroAccess context)
        {
            _context = context;
        }
        public async Task<bool> IsFindAsync (int superHeroId)
        {
            return await _context.superHeroes.AnyAsync(i => i.Id == superHeroId);
        }
        public async Task<List<SuperHero>> GetAllAsync()
        {
            return await _context.superHeroes.ToListAsync();
        }
        public async Task<SuperHero?> GetByIdAsync(int superHeroid)
        {
            return await _context.superHeroes.SingleOrDefaultAsync(i => i.Id == superHeroid);
        }

        public async Task<SuperHero> CreateSuperHeroAsncy(SuperHero newSuperHero)
        {
            await _context.superHeroes.AddAsync(newSuperHero);
            _context.SaveChanges();
            return newSuperHero;
        }
        public  SuperHero  UpdateSuperHeroAsync(SuperHero updateSuperHero)
        {
            _context.superHeroes.Update(updateSuperHero);
            _context.SaveChanges();
            return updateSuperHero;

        }
        public SuperHero  DeleteSuperHeroAsync(SuperHero DelsuperHero)
        {
             _context.superHeroes.Remove(DelsuperHero);
            _context.SaveChanges();
            return DelsuperHero;
        }
 
    }
}
