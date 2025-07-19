
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this._superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetsuperHeroes()
        {
            return Ok(_superHeroService.GetSuperHeroes());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            SuperHero? superHero = _superHeroService.GetSuperHeroById(id);
            if (superHero == null)
                return NotFound("super Hero not Found for this Id");
            return Ok(superHero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {

            return Ok(_superHeroService.AddSuperHero(hero));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperhero(int id , SuperHero newhero)
        {
            var heroes  = _superHeroService.GetSuperHeroById(id);
            if (heroes == null)
                return NotFound("super Hero not Found for this Id");
            return Ok(heroes);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperhero(int id)
        {
            var heroes = _superHeroService.DeleteSuperhero(id);
            if (heroes == null)
                return NotFound("super Hero not Found for this Id");
            return Ok(heroes);
        }


    }
}
