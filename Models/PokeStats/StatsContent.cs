using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.PokeStats
{
    public class StatsContent
    {
        [JsonPropertyName("base_stat")]
        public int BaseStats { get; set; }

        [JsonPropertyName("stat")]
        public Stats Stats { get; set; }
    }
}
