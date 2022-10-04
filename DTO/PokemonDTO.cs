namespace DTO
{
    public class PokemonDTO
    {
        public string Name { get; set; } = string.Empty;

        public int Weight { get; set; }

        public int Height { get; set; }

        public ICollection<AbilitiesDTO> Abilities { get; set; } 

        public SpriteDTO PokeSprite { get; set; }   

        public DateTime CreationTime { get; set; }
    }
}