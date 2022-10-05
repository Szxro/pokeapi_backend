namespace PokemonApi.Services.UrlService
{
    public interface IUrlService
    {
        string getUrlName(string name);

        string getUrlAll(int limit, int offset);
    }
}
