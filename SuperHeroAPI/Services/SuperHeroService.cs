
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        // superHeroes is a list of SuperHero object
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
        new SuperHero { Id= 1, Name= "SpiderMan", FirstName= "Peter",LastName= "Parker",Place="New York"},
        new SuperHero { Id= 2, Name= "BatMan", FirstName= "Bruce",LastName= "Wayne",Place="Gotham"}
        };
        public List<SuperHero> AddSuperHero(SuperHero hero)
        {

            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero> DeleteSuperhero(int id)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return null;
            superHeroes.Remove(superHero);
            return superHeroes;
        }

        public SuperHero? GetSuperHeroById(int id)
        {
            // SuperHero? -- means it can return Null, superHero is a variable which store filtered value
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return null;
            return superHero;
        }

        

        public List<SuperHero>? GetSuperHeroes()
        {
                     return superHeroes;

        }

        public List<SuperHero> UpdateSuperhero(int id, SuperHero newhero)
        {
            SuperHero? superHero = superHeroes.Find(x => x.Id == id);
            if (superHero == null)
                return null;
            superHero.Name = newhero.Name;
            superHero.FirstName = newhero.FirstName;
            superHero.LastName = newhero.LastName;
            superHero.Place = newhero.Place;
            return superHeroes;
        }
    }
}
