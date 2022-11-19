using SuperHeroApi.DTOS;

namespace SuperHeroApi.Models.InterFAce
{
    public interface ISuperHero
    {
        Task<bool> IsFindAsync(int superHeroId);
        Task<List<SuperHero>> GetAllAsync();
        Task<SuperHero> GetByIdAsync(int superHeroid);
        Task<SuperHero> CreateSuperHeroAsncy(SuperHero newSuperHero);
        SuperHero  UpdateSuperHeroAsync(SuperHero updateSuperHero);
        SuperHero  DeleteSuperHeroAsync(SuperHero DelsuperHero);
    }
}
