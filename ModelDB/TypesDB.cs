using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class TypesDB : commonData
    {
        public int PokemonId { get; set; }

        public virtual PokemonDB PokemonDB { get; set; }    

        public string Types { get; set; }
    }
}
