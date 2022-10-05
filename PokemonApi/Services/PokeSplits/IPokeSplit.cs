using DTO;
using Models;

namespace PokemonApi.Services.PokeSplits
{
    public interface IPokeSplit
    {
        PokemonDTO splitPokemon(GeneralData res);
    }
}
