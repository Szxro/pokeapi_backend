using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelDB;
using Models;
using PokemonApi.Services;
using PokemonApi.Services.PokemonService;

namespace PokemonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {
        private readonly IPokeService _service;

        public PokeController(IPokeService service)
        {
            _service = service;
        }

        [HttpGet("search/{name}")]

        public ActionResult<ServiceResponse<List<Pokemon>>> getPokemonByName(string name)
        {
            return Ok(_service.getPokemonByName(name));
        }

        [HttpGet("save/{name}")]

        public async Task<ActionResult<ServiceResponse<List<PokemonDTO>>>> savePokemon(string name)
        {
            return Ok(await _service.savePokemon(name));
        }

        [HttpGet("getPokemons")]
        public async Task<ActionResult<ServiceResponse<List<PokemonDTO>>>> getPokemonDB()
        {
            return Ok(await _service.getPokemonDB());
        }

        [HttpGet("GetAll")]

        public ActionResult<ServiceResponse<List<Pokemon>>> getAllPokemons(int limit = 20, int offset = 0) 
        {
            return Ok(_service.getAllPokemon(limit, offset));
        }
    }
}
