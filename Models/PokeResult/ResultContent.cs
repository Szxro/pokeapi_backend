using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.PokeResult
{
     public class ResultContent<T>
    {
        [JsonPropertyName("results")]
        public IEnumerable<T> Result { get; set; }  
    }
}
