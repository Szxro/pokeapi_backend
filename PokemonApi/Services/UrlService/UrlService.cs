namespace PokemonApi.Services.UrlService
{
    public class UrlService : IUrlService
    {
        private readonly string PokeUrl = "https://pokeapi.co/api/v2/pokemon";
        private readonly string PokeAll = "https://pokeapi.co/api/v2/pokemon";

        public string getUrlAll(int limit, int offset)
        {
            return $"{PokeAll}?limit={limit}&offset={offset}";
        }

        public string getUrlName(string name)
        {
            return $"{PokeUrl}/{name}";
        }
    }
}
