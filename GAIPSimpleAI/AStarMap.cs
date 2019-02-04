using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIPSimpleAI
{
    public class AStarMap
    {
        public TileData[,] MapArray = new TileData[12, 12];

        public AStarMap()
        {
            for(int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    MapArray[x, y].XCoord = x;
                    MapArray[x, y].YCoord = y;
                    //MapArray[x, y].FCost = MapArray[x, y].GCost = MapArray[x, y].HCost = 0;
                    MapArray[x, y].TileState = mapSpaceState.unknown;
                }
            }
        }
    }
}
