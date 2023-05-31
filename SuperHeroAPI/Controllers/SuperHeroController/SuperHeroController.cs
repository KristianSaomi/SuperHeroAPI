using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.DataTransferObjects;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers.SuperHeroController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        private readonly IMapper _mapper;

        public SuperHeroController(ISuperHeroService superHeroService, IMapper mapper)
        {
            _superHeroService = superHeroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();
            if (result == null)
            {
                return NotFound("Sorry their is no superheroes in the list!");
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingelHero(int id)
        {
            var result = await _superHeroService.GetSingelHero(id);
            if (result == null)
                return NotFound("Sorry, but this hero dont exist!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPost("/power")]
        public async Task<ActionResult<PowerUps>> AddPowerUp(PowerUps power)
        {   
            var result = await _superHeroService.AddPowerUp(power);

            var response = _mapper.Map<PowerUpsDTO>(result);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroService.updateHero(id, request);
            if (result is null)
                return NotFound("Sorry, but this hero doesn´t exist");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var results = await _superHeroService.DeleteHero(id);
            if (results is null)
                return NotFound("Hero not found");
            return Ok(results);
        }
    }
}
