using CFPkHex.Backend.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFPkHex.Core.Models.General
{
    public class Box
    {
        public string Name { get; set; }
        public IList<Pokemon> AllPokemon { get; set; }
    }
}
