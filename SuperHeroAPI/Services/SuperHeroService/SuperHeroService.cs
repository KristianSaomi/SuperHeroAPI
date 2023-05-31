using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>>? GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes.Count <= 0 ? null : heroes;
        }

        public async Task<SuperHero?> GetSingelHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            return hero;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<PowerUps>> AddPowerUp(PowerUps power)
        {
            _context.PowerUps.Add(power);
            await _context.SaveChangesAsync();
            return await _context.PowerUps.ToListAsync();
        }

        public async Task<List<SuperHero>?> updateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            hero.PowerUps = request.PowerUps;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
