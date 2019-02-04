using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIPSimpleAI
{
    public enum mapSpaceState { unknown, movable, immovable, visitedOnce };

    public class Map
    {
        public mapSpaceState[,] mapArray = new mapSpaceState[12, 12];

        public Map()
        {
            for (int x = 0; x <= 11; x++)
            {
                for (int y = 0; y <= 11; y++)
                {
                    mapArray[x, y] = mapSpaceState.unknown;

                    if (x == 0 || y == 0 || x == 11 || y == 11)
                    {
                        mapArray[x, y] = mapSpaceState.immovable;
                    }
                }
            }
            

            //setMap();

        }


    }
}
