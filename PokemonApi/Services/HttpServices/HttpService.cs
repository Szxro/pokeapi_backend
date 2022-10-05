using PokemonApi.Services.UrlService;

namespace PokemonApi.Services.HttpServices
{
    public class HttpService : IHttpService
    {
        private readonly static HttpClient _client = new HttpClient();
        private readonly IUrlService _url;
        public HttpService(IUrlService url)
        {
            _url = url;
        }

        public async Task<string> getAllPokemon(int limit, int offset)
        {
            var url = _url.getUrlAll(limit, offset);
            var res = await _client.GetAsync(url);
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> getPokemonByName(string name)
        {
            var url = _url.getUrlName(name);
            var res = await _client.GetAsync(url);
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> getUrlPokemon(Uri? Url)
        {
            if (Url == null)
                return string.Empty;

            var res = await _client.GetAsync(Url);
            return await res.Content.ReadAsStringAsync();
        }

    }
}
