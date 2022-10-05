using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class StatsDB : commonData
    {
        public int PokemonId { get; set; }

        public PokemonDB Pokemon { get; set; }
        
        public string Stats { get; set; }
    }
}
