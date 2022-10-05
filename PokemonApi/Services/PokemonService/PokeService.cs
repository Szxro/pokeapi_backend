using AutoMapper;
using Data;
using DTO;
using Microsoft.EntityFrameworkCore;
using ModelDB;
using Models;
using Models.PokeResult;
using PokemonApi.Services.HttpServices;
using PokemonApi.Services.PokeSplits;
using System.Text.Json;

namespace PokemonApi.Services.PokemonService
{
    public class PokeService : IPokeService
    {
        /*Injection*/
        private readonly PokeContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpService _http;
        private readonly IPokeSplit _pokeSplit;

        public PokeService(PokeContext context, IMapper mapper, IHttpService http, IPokeSplit pokeSplit)
        {
            _context = context;
            _mapper = mapper;
            _http = http;
            _pokeSplit = pokeSplit;
        }
        /*Get Pokemon By Name*/
        public ServiceResponse<List<Pokemon>> getPokemonByName(string name)
        {
            var content = _http.getPokemonByName(name);
            var cacthPokemon = new List<Pokemon>();
            try
            {
                if (content.Result != "Not Found")
                {
                    var pokemon = JsonSerializer.Deserialize<Pokemon>(content.Result);
                    cacthPokemon.Add(pokemon);
                }
                else
                {
                    return new ServiceResponse<List<Pokemon>>() { Message = "Pokemon Not Found", Success = false };
                }
                return new ServiceResponse<List<Pokemon>>() { Data = cacthPokemon };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Pokemon>>() { Message = e.Message, Success = false };
            }
        }
        /*Save Pokemon*/
        public async Task<ServiceResponse<List<PokemonDTO>>> savePokemon(string name)
        {
            var res = getPokemonByName(name);
            if (!res.Success)
            {
                return new ServiceResponse<List<PokemonDTO>>() { Message = "Pokemon Not Found", Success = false };
            }
            else
            {
                var content = new GeneralData() { Pokemons = res.Data };
                try
                {
                    var pokeSplit = _pokeSplit.splitPokemon(content);
                    var pokeName = await _context.Pokemons.Where(x => x.Name == pokeSplit.Name).FirstOrDefaultAsync();
                    if (pokeName != null)
                        return new ServiceResponse<List<PokemonDTO>>() { Message = "The Pokemon Existed", Success = false };
                    var pokemonDb = _mapper.Map<PokemonDB>(pokeSplit);
                    await _context.Pokemons.AddAsync(pokemonDb);
                    await _context.SaveChangesAsync();

                    return new ServiceResponse<List<PokemonDTO>>() { Data = await _context.Pokemons.Include(x => x.Abilities).Include(x => x.PokeSprite).Include(x => x.Types).Include(x => x.Stats).Select(x => _mapper.Map<PokemonDTO>(x)).ToListAsync() };
                }
                catch (Exception e)
                {
                    return new ServiceResponse<List<PokemonDTO>>() { Message = e.Message, Success = false };
                }
            }
        }

        /*Get Pokemons from the data base*/
        public async Task<ServiceResponse<List<PokemonDTO>>> getPokemonDB()
        {
            /*If the DB have no data is going to throw another response*/
            if (await _context.Pokemons.CountAsync() <= 0)
                return new ServiceResponse<List<PokemonDTO>>() { Message = "No Data Found", Success = false };
            /*Else is going to throw the result*/
            return new ServiceResponse<List<PokemonDTO>>() { Data = await _context.Pokemons.Include(x => x.Abilities).Include(x => x.PokeSprite).Include(x => x.Types).Include(x => x.Stats).Select(x => _mapper.Map<PokemonDTO>(x)).ToListAsync() };
        }

        /*Get All the Pokemon from the Api*/
        public ServiceResponse<List<Pokemon>> getAllPokemon(int limit = 20, int offset = 0)
        {
            var content = _http.getAllPokemon(limit, offset);
            var catchPokemon = new List<Pokemon>();
            var resultContent = JsonSerializer.Deserialize<ResultContent<PokeAll>>(content.Result);
            try
            {
                if (resultContent.Result.Count() > 0)
                {
                    foreach (var i in resultContent.Result)
                    {
                        var resUrl = _http.getUrlPokemon(i.Url);
                        if (resUrl.Result == string.Empty)
                            return new ServiceResponse<List<Pokemon>>() { Message = "No Urls Find to some Pokemons", Success = false };
                        var pokemon = JsonSerializer.Deserialize<Pokemon>(resUrl.Result);
                        catchPokemon.Add(pokemon);
                    }
                }
                else
                {
                    return new ServiceResponse<List<Pokemon>>() { Message = "No Data Found in PokeApi", Success = false };
                }

                return new ServiceResponse<List<Pokemon>> { Data = catchPokemon };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Pokemon>> { Success = false, Message = $"{e.Message}" };
            }
        }
    }
}
