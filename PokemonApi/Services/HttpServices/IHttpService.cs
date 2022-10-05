namespace PokemonApi.Services.HttpServices
{
    public interface IHttpService
    {
        Task<string> getPokemonByName(string name);

        Task<string> getAllPokemon(int limit, int offset);

        Task<string> getUrlPokemon(Uri? Url);
    }
}
