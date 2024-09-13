using CFPkHex.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFPkHex.Core.Repository
{
    public interface IBoxRepository
    {
        public IList<Box> Boxes { get; }
    }
}
