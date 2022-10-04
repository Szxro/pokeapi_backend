using Models.PokeAbilities;
using Models.PokeSprite;
using Models.PokeStats;
using Models.PokeTypes;
using System.Text.Json.Serialization;

namespace Models
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("abilities")]
        public AbilitiesContent[] Abilities { get; set; }

        [JsonPropertyName("types")]
        public TypeContent[] Types { get; set; }

        [JsonPropertyName("sprites")]
        public SpriteContent Sprites { get; set; }

        [JsonPropertyName("stats")]

        public StatsContent[] Stats { get; set; }

    }
}