using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIPSimpleAI
{
    class AStarAgent
    {
        int XCoord, YCoord, XCoordPrev, YCoordPrev;
        int XStart, YStart, XGoal, YGoal;

        AStarMap agentMap;

        public AStarAgent()
        {
            XStart = YStart = 1;
            XGoal = YGoal = 10;
        }

        private void MovementCheck()
        {
            for (int xCheck = -1; xCheck <= 1; xCheck++)
            {
                for (int yCheck = -1; yCheck <= 1; yCheck++)
                {
                    try
                    {
                        if (agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].TileState == mapSpaceState.unknown)
                        {
                            // Get tile moveable state
                            agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].TileState = Game.checkLocation(XCoord + xCheck, YCoord + yCheck);

                            // Set GCost
                            SetGCost(xCheck, yCheck);

                            // Set HCost
                            SetHCost(xCheck, yCheck);

                            // Set FCost
                            SetFCost(xCheck, yCheck);

                        }

                    }
                    catch (Exception e)
                    {
                        // Out of bounds
                    }
                }
            }

        }

        private void SetFCost(int xCheck, int yCheck)
        {
            agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].FCost = agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].GCost + agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].HCost;
        }

        private void SetHCost(int xCheck, int yCheck)
        {
            agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].HCost = Math.Abs(XGoal - XCoord) + Math.Abs(YGoal - YCoord);
        }

        private void SetGCost(int xCheck, int yCheck)
        {
            if ((XCoord == XCoordPrev) ^ (YCoord == YCoordPrev))
            {
                agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].GCost = agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].parent.GCost + 10;
            }
            else if ((XCoord == XCoordPrev) && (YCoord == YCoordPrev))
            {
                agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].GCost = agentMap.MapArray[XCoord + xCheck, YCoord + yCheck].parent.GCost + 14;
            }
        }
    }
}
