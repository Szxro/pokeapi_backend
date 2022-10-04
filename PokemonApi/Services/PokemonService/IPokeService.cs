using DTO;
using ModelDB;
using Models;

namespace PokemonApi.Services.PokemonService
{
    public interface IPokeService
    {
        Task<ServiceResponse<List<Pokemon>>> getPokemonByName(string name);

        Task<ServiceResponse<List<PokemonDTO>>> savePokemon(string name);

        Task<ServiceResponse<List<PokemonDTO>>> getPokemonDB();
    }
}
