namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetSuperHeroes();
        SuperHero? GetSuperHeroById(int id);
        List<SuperHero> AddSuperHero(SuperHero hero);
        List<SuperHero>?UpdateSuperhero(int id, SuperHero newhero);

        List<SuperHero>?DeleteSuperhero(int id);
    }
}
