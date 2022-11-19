using AutoMapper;
using SuperHeroApi.DTOS;
using SuperHeroApi.Models;

namespace SuperHeroApi.Profiles
{
    public class SuperHeroProfile:Profile
    {
        public SuperHeroProfile()
        {
            CreateMap<SuperHero,SuperHeroCreate>();
        }
    }
}
