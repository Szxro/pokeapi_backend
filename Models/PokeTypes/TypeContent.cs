using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.PokeTypes
{
     public class TypeContent
    {
        [JsonPropertyName("type")]
        public Types Type { get; set; }
    }
}
