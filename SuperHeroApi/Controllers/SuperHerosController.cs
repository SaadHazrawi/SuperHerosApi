using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTOS;
using SuperHeroApi.Models;
using SuperHeroApi.Models.InterFAce;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHerosController : ControllerBase
    {
        private readonly ISuperHero _superHero;
        private readonly IMapper _mapper;

        public SuperHerosController(ISuperHero superHero, IMapper mapper)
        {
            this._superHero = superHero;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(await _superHero.GetAllAsync());
        }
        [HttpGet("{superHeroId}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int superHeroId)
        {
            var IsHere = await _superHero.IsFindAsync(superHeroId);
            if (!IsHere)
                return NotFound();
            return Ok(await _superHero.GetByIdAsync(superHeroId));
        }
        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddSuerpHero(SuperHeroCreate superHero)
        {
            var cretae = new SuperHero()
            {
                Name = superHero.Name,
                Description = superHero.Description,
                Place = superHero.Place
            };
            //var CreateSuperHero = _mapper.Map<SuperHero>(superHero);
            return Ok(_superHero.CreateSuperHeroAsncy(cretae));
        }
        [HttpPut("{superHeroId}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int superHeroId, SuperHeroCreate superHero)
        {
            var superHeroUpdate = await _superHero.IsFindAsync(superHeroId);
            if (!superHeroUpdate)
                return NotFound();
            var GetSuper = await _superHero.GetByIdAsync(superHeroId);
            GetSuper.Name = superHero.Name;
            GetSuper.Description = superHero.Description;
            GetSuper.Place = superHero.Place;
            return Ok( _superHero.UpdateSuperHeroAsync(GetSuper));

        }
        [HttpDelete("{superHeroId}")]
        public async Task<ActionResult> DeleteSuperHero(int superHeroId)
        {
            var IsHere = await _superHero.IsFindAsync(superHeroId);
            if (!IsHere)
                return NotFound();
            var GetSuper = await _superHero.GetByIdAsync(superHeroId);
            _superHero.DeleteSuperHeroAsync(GetSuper);
            return Ok();
        }
    }
}
