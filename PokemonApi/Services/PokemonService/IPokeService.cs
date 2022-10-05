using DTO;
using ModelDB;
using Models;

namespace PokemonApi.Services.PokemonService
{
    public interface IPokeService
    {
        ServiceResponse<List<Pokemon>> getPokemonByName(string name);

        Task<ServiceResponse<List<PokemonDTO>>> savePokemon(string name);

        Task<ServiceResponse<List<PokemonDTO>>> getPokemonDB();

        ServiceResponse<List<Pokemon>> getAllPokemon(int limit = 20, int offset = 0);
    }
}
