using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIPSimpleAI
{
    public class Agent
    {
        private int XLocation;
        private int YLocation;

        public int XGoal;
        public int YGoal;
        public bool goalReached;

        int xDif, yDif;
        int xDir, yDir;

        int limit;
        bool emergencyProtocols;

        List<int> movementHistory;
        int yPrev, xPrev;
        int yPrevDir, xPrevDir;

        public Map agentMap;

        public Agent()
        {
            movementHistory = new List<int>();

            XLocation = YLocation = 1;
            XGoal = YGoal = 10;
            limit = 11;
            emergencyProtocols = false;
            goalReached = false;
            agentMap = new Map();
            agentMap.mapArray[XLocation, YLocation] = mapSpaceState.movable;
        }

        public void play()
        {
            while (!goalReached)
            {
                goalAnalysis();

                if (xDif == 0 && yDif == 0)
                {
                    // Done
                    Console.WriteLine("Reached Goal");
                    goalReached = true;
                }
                else
                    turn();
            }

        }
        
        private void turn()
        {
            Console.WriteLine("[" + XLocation + ", " + YLocation + "]");
            recordLocation();

            movementCheck();

            if(agentMap.mapArray[XLocation, YLocation] == mapSpaceState.movable)
                agentMap.mapArray[XLocation, YLocation] = mapSpaceState.visitedOnce;
            else if(agentMap.mapArray[XLocation, YLocation] == mapSpaceState.visitedOnce)
                agentMap.mapArray[XLocation, YLocation] = mapSpaceState.immovable;

            emergencyProtocols = false;
            Move(mapSpaceState.movable);

            if (emergencyProtocols)
                Move(mapSpaceState.visitedOnce);

            if (emergencyProtocols)
            {
                Console.WriteLine("Stuck");
            }

            emergencyProtocols = false;
            Console.ReadLine();

        }

        private void Move(mapSpaceState check)
        {
            bool locked = false;

            // Horizontally or Vertically matched goal
            //if (xDir == 0 || yDir == 0)
            {
                // Recall your last position
                locked = true;

                yPrev = movementHistory.Last() % 10;
                xPrev = (movementHistory.Last() - yPrev) / 10;

                xPrevDir =(XLocation - xPrev);
                yPrevDir = (YLocation - yPrev);
            }
            
            if (agentMap.mapArray[XLocation + xDir, YLocation + yDir] == check)
            {
                // Head directly towards Goal if possible
                XLocation += xDir;
                YLocation += yDir;
            }
            else if (agentMap.mapArray[XLocation, YLocation + yDir] == check)
            {
                // Else head towards Goal vertically if possible
                YLocation += yDir;
            }
            else if (agentMap.mapArray[XLocation + xDir, YLocation] == check)
            {
                // Else head towards Goal horizontally if possible
                XLocation += xDir;
            }
            else if (agentMap.mapArray[XLocation + xDir, YLocation - yDir] == check)
            {
                // Head towards Goal horizontally and away vertically if possible
                XLocation += xDir;
                YLocation -= yPrevDir;
            }
            else if (agentMap.mapArray[XLocation - xDir, YLocation + yDir] == check)
            {
                // Head towards Goal vertically and away horizontally if possible
                XLocation -= xPrevDir;
                YLocation += yDir;
            }
            else if (agentMap.mapArray[XLocation, YLocation - yDir] == check)
            {
                // Else head away from Goal vertically if possible
                YLocation -= yPrevDir;
            }
            else if (agentMap.mapArray[XLocation - xDir, YLocation] == check)
            {
                // Else head away from Goal horizontally if possible
                XLocation -= xPrevDir;
            }
            else if (agentMap.mapArray[XLocation - xDir, YLocation - yDir] == check)
            {
                // Else last resort, go completely away from goal
                XLocation -= xPrevDir;
                YLocation -= yPrevDir;
            }
            else
            {
                emergencyProtocols = true;
            }

        }

        private void goalAnalysis()
        {
            xDif = XGoal - XLocation;
            yDif = YGoal - YLocation;

            if (xDif > 0)
                xDir = 1;
            else if (xDif < 0)
                xDir = -1;
            else
                xDir = 0;

            if (yDif > 0)
                yDir = 1;
            else if (yDif < 0)
                yDir = -1;
            else
                yDir = 0;
        }

        private void movementCheck()
        {
            for (int xCheck = -1; xCheck < 2; xCheck++)
            {
                for (int yCheck = -1; yCheck < 2; yCheck++)
                {
                    try
                    {
                        if (agentMap.mapArray[XLocation + xCheck, YLocation + yCheck] == mapSpaceState.unknown)
                        {
                            agentMap.mapArray[XLocation + xCheck, YLocation + yCheck] = Game.checkLocation(XLocation + xCheck, YLocation + yCheck);
                        }

                    }
                    catch (Exception e)
                    {
                        // Out of bounds
                    }
                }
            }

        }

        private void recordLocation()
        {
            // Ex. if the agent is at spot 10, 6 it will be recorded as 106. 
            movementHistory.Add(((XLocation * 10) + YLocation));
        }
    }
}
