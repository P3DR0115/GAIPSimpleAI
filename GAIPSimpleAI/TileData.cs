using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIPSimpleAI
{
    public class TileData
    {
        public mapSpaceState TileState;
        public int XCoord, YCoord;
        public int GCost, HCost, FCost;

        public TileData parent;
    }
}
