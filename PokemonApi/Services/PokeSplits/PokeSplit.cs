using DTO;
using Models;

namespace PokemonApi.Services.PokeSplits
{
    public class PokeSplit : IPokeSplit
    {
        public PokemonDTO splitPokemon(GeneralData res)
        {
            var catchPokemon = new PokemonDTO() { };
            foreach (var i in res.Pokemons)
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

                var types = new TypesDTO()
                {
                    CreationTime = DateTime.Now,
                    Types = i.Types
                };

                var stats = new StatsDTO()
                {
                    CreationTime = DateTime.Now,
                    Stats = i.Stats
                };
                /*This is the New Pokemon with all his properties*/
                var pokemon = new PokemonDTO()
                {
                    Name = i.Name,
                    Weight = i.Weight,
                    Height = i.Height,
                    CreationTime = DateTime.Now,
                    /*Is a ICollection ("array of data") need a list to not have errors*/
                    Abilities = new List<AbilitiesDTO>() { abilities },
                    PokeSprite = sprite,
                    Types = types,
                    Stats = stats
                };

                catchPokemon = pokemon;
            }
            return catchPokemon;
        }
    }
}
