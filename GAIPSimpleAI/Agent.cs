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

        //private void turn()
        //{
        //    recordMove();
        //    movementCheck();

        //    try
        //    {
        //        DetermineMovement();
        //        if (movementHistory.Last() != ((XLocation * 10) + YLocation))
        //        {
        //            //if (xDif != 0 && yDif != 0)
        //            //    diagonalMovement(false);
        //            //else if (xDif != 0)
        //            //    horizontalMovement(false);
        //            //else
        //            //    verticalMovement(false);

        //            //DetermineMovement();

        //        }
        //        else
        //        {
        //            //if ((XGoal - XLocation) < (YGoal - YLocation))
        //            {
        //                try
        //                {
        //                    verticalMovement(true);
        //                }
        //                catch (Exception e)
        //                {
        //                    try
        //                    {
        //                        horizontalMovement(true);
        //                    }
        //                    catch (Exception f)
        //                    {
        //                        diagonalMovement(true);
        //                    }
        //                }
        //            }

        //            //if (xDif != 0 && yDif != 0)
        //            //else if (xDif != 0)
        //            //else

        //        }



        //    }
        //    catch (Exception e)
        //    {
        //        // movement history is empty
        //        if (xDif != 0 && yDif != 0)
        //            diagonalMovement(false);
        //        else if (xDif != 0)
        //            horizontalMovement(false);
        //        else
        //            verticalMovement(false);

        //    }

        //}

        //private void movementCheck()
        //{
        //    for (int xCheck = -1; xCheck < 2; xCheck++)
        //    {
        //        for (int yCheck = -1; yCheck < 2; yCheck++)
        //        {
        //            try
        //            {
        //                if (agentMap.mapArray[XLocation + xCheck, YLocation + yCheck] == mapSpaceState.unknown)
        //                {
        //                    agentMap.mapArray[XLocation + xCheck, YLocation + yCheck] = Game.checkLocation(XLocation + xCheck, YLocation + yCheck);
        //                }

        //            }
        //            catch (Exception e)
        //            {
        //                // Out of bounds
        //            }
        //        }
        //    }

        //}

        //private void goalAnalysis()
        //{
        //    xDif = XGoal - XLocation;
        //    yDif = YGoal - YLocation;

        //    if (xDif > 0)
        //        xDif = 1;
        //    else if (xDif < 0)
        //        xDif = -1;
        //    else
        //        xDif = 0;

        //    if (yDif > 0)
        //        yDif = 1;
        //    else if (yDif < 0)
        //        yDif = -1;
        //    else
        //        yDif = 0;

        //}

        //private void DetermineMovement()
        //{
        //    if ((xDif > 0 && yDif > 0) || (xDif < 0 && yDif < 0))
        //    {
        //        diagonalMovement(false);
        //    }
        //    else if (xDif == 0)
        //    {
        //        verticalMovement(false);
        //    }
        //    else if (yDif == 0)
        //    {
        //        horizontalMovement(false);
        //    }
        //    else
        //    {
        //        // return spot?
        //    }
        //}

        //private void recordMove()
        //{
        //    displayLocation();
        //    int record = (XLocation * 10) + YLocation;
        //    movementHistory.Add(record);
        //}

        //private void diagonalMovement(bool stuck)
        //{
        //    if (!stuck)
        //    {
        //        if (agentMap.mapArray[XLocation + xDif, YLocation + yDif] == mapSpaceState.movable)
        //        {
        //            XLocation += xDif;
        //            YLocation += yDif;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            if (agentMap.mapArray[XLocation - xDif, YLocation - yDif] == mapSpaceState.movable)
        //            {
        //                XLocation -= xDif;
        //                YLocation -= yDif;
        //            }
        //            else if (agentMap.mapArray[XLocation + xDif, YLocation - yDif] == mapSpaceState.movable)
        //            {
        //                XLocation += xDif;
        //                YLocation -= yDif;
        //            }
        //            else if (agentMap.mapArray[XLocation + xDif, YLocation - yDif] == mapSpaceState.movable)
        //            {
        //                XLocation -= xDif;
        //                YLocation += yDif;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            // out of bounds
        //        }
        //    }
        //}

        //private void horizontalMovement(bool stuck)
        //{
        //    if (!stuck)
        //    {
        //        if (agentMap.mapArray[XLocation + xDif, YLocation] == mapSpaceState.movable)
        //        {
        //            XLocation += xDif;
        //        }
        //    }
        //    else
        //    {
        //        if (agentMap.mapArray[XLocation - xDif, YLocation] == mapSpaceState.movable)
        //        {
        //            XLocation -= xDif;
        //        }
        //    }
        //}

        //private void verticalMovement(bool stuck)
        //{
        //    if (!stuck)
        //    {
        //        if (agentMap.mapArray[XLocation, YLocation + yDif] == mapSpaceState.movable)
        //        {
        //            YLocation += yDif;
        //        }
        //    }
        //    else
        //    {
        //        if (agentMap.mapArray[XLocation, YLocation - yDif] == mapSpaceState.movable)
        //        {
        //            YLocation -= yDif;
        //        }
        //    }
        //}

        //private void displayLocation()
        //{
        //    Console.WriteLine("[" + XLocation + ", " + YLocation + "]");
        //}

        private void turn()
        {
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
            Console.WriteLine("[" + XLocation + ", " + YLocation + "]");
            Console.ReadLine();

        }

        private void Move(mapSpaceState check)
        {
            //if ((XLocation + xDir <= limit && YLocation + yDir <= limit) && agentMap.mapArray[XLocation + xDir, YLocation + yDir] == mapSpaceState.movable)
            //{
            //    // Head directly towards Goal if possible
            //    XLocation += xDir;
            //    YLocation += yDir;
            //}
            //else if ((YLocation + yDir <= limit) && agentMap.mapArray[XLocation, YLocation + yDir] == mapSpaceState.movable)
            //{
            //    // Else head towards Goal vertically if possible
            //    YLocation += yDir;
            //}
            //else if ((XLocation + xDir <= limit) && agentMap.mapArray[XLocation + xDir, YLocation] == mapSpaceState.movable)
            //{
            //    // Else head towards Goal horizontally if possible
            //    XLocation += xDir;
            //}
            //else if (agentMap.mapArray[XLocation + xDir, YLocation - yDir] == mapSpaceState.movable)
            //{
            //    // Head towards Goal horizontally and away vertically if possible
            //    XLocation += xDir;
            //    YLocation -= yDir;
            //}
            //else if ((XLocation - xDir <= limit && YLocation + yDir <= limit) && agentMap.mapArray[XLocation - xDir, YLocation + yDir] == mapSpaceState.movable)
            //{
            //    // Head towards Goal vertically and away horizontally if possible
            //    XLocation -= xDir;
            //    YLocation += yDir;
            //}
            //else if ((YLocation - yDir <= limit) && agentMap.mapArray[XLocation, YLocation - yDir] == mapSpaceState.movable)
            //{
            //    // Else head away from Goal vertically if possible
            //    YLocation -= yDir;
            //    emergencyProtocols = true;
            //}
            //else if ((XLocation - xDir <= limit) && agentMap.mapArray[XLocation - xDir, YLocation] == mapSpaceState.movable)
            //{
            //    // Else head away from Goal horizontally if possible
            //    XLocation -= xDir;
            //    emergencyProtocols = true;
            //}
            //else
            //{
            //    // Else last resort, go completely away from goal
            //    XLocation -= xDir;
            //    YLocation -= yDir;
            //    emergencyProtocols = true;
            //}

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
                YLocation -= yDir;
            }
            else if (agentMap.mapArray[XLocation - xDir, YLocation + yDir] == check)
            {
                // Head towards Goal vertically and away horizontally if possible
                XLocation -= xDir;
                YLocation += yDir;
            }
            else if (agentMap.mapArray[XLocation, YLocation - yDir] == check)
            {
                // Else head away from Goal vertically if possible
                YLocation -= yDir;
            }
            else if (agentMap.mapArray[XLocation - xDir, YLocation] == check)
            {
                // Else head away from Goal horizontally if possible
                XLocation -= xDir;
            }
            else if (agentMap.mapArray[XLocation - xDir, YLocation - yDir] == check)
            {
                // Else last resort, go completely away from goal
                XLocation -= xDir;
                YLocation -= yDir;
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

        private void diagonalMove(bool dangerSuperMegaEmergencyProtocolActivation)
        {
            if(!dangerSuperMegaEmergencyProtocolActivation)
            {
                try
                {
                    if (agentMap.mapArray[XLocation + xDir, YLocation + yDir] == mapSpaceState.movable)
                    {
                        XLocation += xDir;
                        YLocation += yDir;
                    }
                    else
                    {
                        horizontalMove(false);
                    }
                    //else if (agentMap.mapArray[XLocation + xDir, YLocation + yDir] == mapSpaceState.movable)
                    //{
                    //    XLocation += xDir;
                    //    YLocation += yDir;
                    //}
                }
                catch (Exception e)
                {
                    // out of bouds?
                }
            } // if !dangerSuperMegaEmergencyProtocolActivation
            else
            {

            }
        }

        private void verticalMove(bool dangerSuperMegaEmergencyProtocolActivation)
        {
            try
            {
                if (agentMap.mapArray[XLocation, YLocation + yDir] == mapSpaceState.movable)
                {
                    YLocation += yDir;
                }
                else
                {
                    if(xDif > yDif)
                    {
                        verticalMove(true);
                    }
                }
            }
            catch (Exception e)
            {
                // out of bouds?
            }
        }

        private void horizontalMove(bool dangerSuperMegaEmergencyProtocolActivation)
        {
            try
            {
                if (agentMap.mapArray[XLocation + xDir, YLocation] == mapSpaceState.movable)
                {
                    XLocation += xDir;
                }
                else
                {
                    verticalMove(false);
                }
            }
            catch(Exception e)
            {
                // out of bouds?
            }
        }
    }
}
