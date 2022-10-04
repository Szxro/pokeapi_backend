using Models.Common;

namespace ModelDB
{
    public class PokemonDB : commonData
    {
        public string Name { get; set; } = string.Empty;

        public int Weight { get; set; }

        public int Height { get; set; }

        public virtual ICollection<AbilitiesDB> Abilities { get; set; }

        public virtual SpriteDB PokeSprite { get; set; }
    }
}