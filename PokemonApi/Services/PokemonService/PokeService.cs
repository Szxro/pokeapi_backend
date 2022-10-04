using AutoMapper;
using Data;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelDB;
using Models;
using System.Text.Json;

namespace PokemonApi.Services.PokemonService
{
    public class PokeService : IPokeService
    {
        private readonly static HttpClient _client = new HttpClient();

        /*Urls*/
        private readonly string PokeUrl = "https://pokeapi.co/api/v2/pokemon";
        private readonly string PokeSave = "https://localhost:44348/api/Poke/search";

        /*Injection*/
        private readonly PokeContext _context;
        private readonly IMapper _mapper;
        public PokeService(PokeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;  
        }

        public async Task<ServiceResponse<List<Pokemon>>> getPokemonByName(string name)
        {
            var res = await _client.GetAsync($"{PokeUrl}/{name}");
            var content = await res.Content.ReadAsStringAsync();
            var cacthPokemon = new List<Pokemon>();

            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var pokemon = JsonSerializer.Deserialize<Pokemon>(content);
                    cacthPokemon.Add(pokemon);
                }
                return new ServiceResponse<List<Pokemon>>() { Data = cacthPokemon };
            } catch (Exception e)
            {
                return new ServiceResponse<List<Pokemon>>() { Message =e.Message,Success = false };
            }
        }

        public async Task<ServiceResponse<List<PokemonDTO>>> savePokemon(string name)
        {
            var res = await _client.GetAsync($"{PokeSave}/{name}");
            var content = await res.Content.ReadAsStringAsync();
            var resultContent = JsonSerializer.Deserialize<GeneralData>(content);

            try
            {
                if (res.IsSuccessStatusCode)
                {
                    foreach (var i in resultContent.Pokemons) 
                    {
                        var abilities = new AbilitiesDTO()
                        {
                            FirstAbility = i.Abilities.Select(x => x.Ability.Name).First(),
                            SecondAbilitiy = i.Abilities.Select(x => x.Ability.Name).Last(),
                            CreationTime = DateTime.Now
                        };

                        var sprite = new SpriteDTO()
                        {
                            CreationTime = DateTime.Now,
                            UrlSprite = i.Sprites.other.PokeImage.UrlImage
                        };

                        var pokemon = new PokemonDTO()
                        {
                            Name = i.Name,
                            Weight = i.Weight,
                            Height = i.Height,
                            CreationTime = DateTime.Now,
                            Abilities = new List<AbilitiesDTO>() { abilities },
                            PokeSprite = sprite
                        };

                        var pokemonDb = _mapper.Map<PokemonDB>(pokemon);
                        await _context.Pokemons.AddAsync(pokemonDb);
                    }
                 await _context.SaveChangesAsync();
                }
                return new ServiceResponse<List<PokemonDTO>>() { Data = await _context.Pokemons.Include(x => x.Abilities).Include(x => x.PokeSprite).Select(x => _mapper.Map<PokemonDTO>(x)).ToListAsync() };
            } catch (Exception e)
            {
                return new ServiceResponse<List<PokemonDTO>>() { Message = e.Message, Success = false };
            }
        }

        /*Get Pokemons from the data base*/
        public async Task<ServiceResponse<List<PokemonDTO>>> getPokemonDB()
        {
            return new ServiceResponse<List<PokemonDTO>>() { Data = await _context.Pokemons.Include(x => x.Abilities).Select(x => _mapper.Map<PokemonDTO>(x)).ToListAsync() };
        }
    }
}
