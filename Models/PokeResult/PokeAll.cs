﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.PokeResult
{
    public class PokeAll
    {
        [JsonPropertyName("url")]
        public Uri? Url { get; set; }
    }
}
