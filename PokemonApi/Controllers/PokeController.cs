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

        public async Task<ActionResult<ServiceResponse<List<Pokemon>>>> getPokemonByName(string name)
        {
            var res = await _service.getPokemonByName(name);
            if (res.Data.Count() <= 0)
                return NotFound(new ServiceResponse<List<Pokemon>>() { Message = "Pokemon Not Found", Success = false });
            return Ok(res);
        }

        [HttpGet("save/{name}")]

        public async Task<ActionResult<ServiceResponse<List<PokemonDTO>>>> savePokemon(string name)
        {
            var res = await _service.savePokemon(name);
            if (!res.Success)
                return BadRequest(res);
            if (res.Data.Count() <= 0)
                return NotFound(new ServiceResponse<List<PokemonDTO>>() {Message ="Pokemon not Found", Success = false });
            return Ok(res);
        }

        [HttpGet("getPokemons")]
        public async Task<ActionResult<ServiceResponse<List<PokemonDTO>>>> getPokemonDB()
        {
            return Ok(await _service.getPokemonDB());
        }
    }
}
