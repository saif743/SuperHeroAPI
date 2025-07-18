
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // superHeroes is a list of SuperHero object
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
        new SuperHero { Id= 1, Name= "SpiderMan", FirstName= "Peter",LastName= "Parker",Place="New York"},
        new SuperHero { Id= 2, Name= "BatMan", FirstName= "Bruce",LastName= "Wayne",Place="Gotham"}
        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetsuperHeroes()
        {
            return Ok(superHeroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            // SuperHero? -- means it can return Null, superHero is a variable which store filtered value
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return NotFound("super Hero not Found for this Id");
            return Ok(superHero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperhero(int id , SuperHero newhero)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return NotFound("super Hero not Found for this Id");
            superHero.Name = newhero.Name;
            superHero.FirstName = newhero.FirstName;
            superHero.LastName = newhero.LastName;
            superHero.Place = newhero.Place;
            return Ok(superHeroes);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperhero(int id)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return NotFound("super Hero not Found for this Id");
            superHeroes.Remove(superHero);
            return Ok(superHeroes);
        }


    }
}
