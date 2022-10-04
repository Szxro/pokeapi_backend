using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class SpriteDB : commonData
    {
        public int PokemonId { get; set; }

        public virtual PokemonDB Pokemon { get; set; }

        public Uri? UrlSprite { get; set; }
    }
}
