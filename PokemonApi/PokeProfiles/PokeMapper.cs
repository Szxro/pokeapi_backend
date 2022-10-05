using AutoMapper;
using DTO;
using ModelDB;

namespace PokemonApi.PokeProfiles
{
    public class PokeMapper : Profile
    {
        public PokeMapper()
        {
            //PokemonDTO - PokemonDB
            CreateMap<PokemonDTO, PokemonDB>();
            CreateMap<PokemonDB, PokemonDTO>();
            //AbilitiesDTO - AbilitiesDB
            CreateMap<AbilitiesDTO, AbilitiesDB>();
            CreateMap<AbilitiesDB, AbilitiesDTO>();
            //SpriteDTO - SpriteDB
            CreateMap<SpriteDTO, SpriteDB>();
            CreateMap<SpriteDB, SpriteDTO>();
            //TypesDTO - TypesDB
            CreateMap<TypesDTO, TypesDB>();
            CreateMap<TypesDB, TypesDTO>();
            //StatsDTO - StatsDB
            CreateMap<StatsDTO, StatsDB>();
            CreateMap<StatsDB, StatsDTO>();  
        }
    }
}
