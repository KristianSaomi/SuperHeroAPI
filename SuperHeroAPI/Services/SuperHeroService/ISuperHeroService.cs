namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task <List<SuperHero>>? GetAllHeroes();
        Task <SuperHero>? GetSingelHero(int id);
        Task <List<SuperHero>> AddHero(SuperHero hero);
        Task <List<SuperHero>?> updateHero(int id, SuperHero request);
        Task <List<SuperHero>?> DeleteHero(int id);

        Task <List<PowerUps>> AddPowerUp(PowerUps power);


    }
}
