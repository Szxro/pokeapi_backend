using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class GeneralData
    {
        [JsonPropertyName("data")]
        public IEnumerable<Pokemon> Pokemons { get; set; }
    }
}
