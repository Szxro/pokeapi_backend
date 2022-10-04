using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.PokeSprite
{
    public class SpriteContent
    {
        [JsonPropertyName("other")]
        public Other other { get; set; } 
    }

    public class Other {
        [JsonPropertyName("dream_world")]
        public PokeImage PokeImage { get; set; }    
    }

    public class PokeImage {
        [JsonPropertyName("front_default")]
        public Uri? UrlImage { get; set; }
    }
}
