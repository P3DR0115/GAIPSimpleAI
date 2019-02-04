using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIPSimpleAI
{
    public class Game
    {
        public Agent smith;
        public static Map puzzleMap;

        public Game()
        {
            puzzleMap = new Map();
            setPuzzleMap();
            smith = new Agent();

            //smith.XGoal = smith.YGoal = 9;
            smith.play();
        }

        public void setPuzzleMap()
        {
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    puzzleMap.mapArray[x, y] = mapSpaceState.movable;
                }
            }

            puzzleMap.mapArray[2, 3] = mapSpaceState.immovable;
            puzzleMap.mapArray[3, 6] = mapSpaceState.immovable;
            puzzleMap.mapArray[3, 8] = mapSpaceState.immovable;
            puzzleMap.mapArray[4, 2] = mapSpaceState.immovable;
            puzzleMap.mapArray[4, 3] = mapSpaceState.immovable;
            puzzleMap.mapArray[4, 4] = mapSpaceState.immovable;
            puzzleMap.mapArray[5, 8] = mapSpaceState.immovable;
            puzzleMap.mapArray[5, 9] = mapSpaceState.immovable;
            puzzleMap.mapArray[5, 10] = mapSpaceState.immovable;
            puzzleMap.mapArray[6, 1] = mapSpaceState.immovable;
            puzzleMap.mapArray[6, 2] = mapSpaceState.immovable;
            puzzleMap.mapArray[6, 3] = mapSpaceState.immovable;
            puzzleMap.mapArray[7, 6] = mapSpaceState.immovable;
            puzzleMap.mapArray[7, 8] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 2] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 3] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 4] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 5] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 8] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 9] = mapSpaceState.immovable;
            puzzleMap.mapArray[9, 10] = mapSpaceState.immovable;
        }

        public static mapSpaceState checkLocation(int xCoord, int yCoord)
        {
            return puzzleMap.mapArray[xCoord, yCoord];
        }
    }

}