namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        int prevYAxis = -1;
        int prevXAxis = -1;
        bool moveRight = true;
        public Agent()
        {
        }

        public AgentAction DecideAction(Room room)
        {
            AgentAction action;
            int currentXAxis = room.XAxis;
            int currentYAxis = room.YAxis;
            bool isDirty = room.IsDirty;
            if(isDirty)
            {
                action = AgentAction.CLEAN;
            }
            else
            {
                if(currentXAxis == prevXAxis && currentYAxis == prevYAxis)
                {
                    action = AgentAction.MOVE_DOWN;
                    moveRight = !moveRight;
                }
                else
                {
                    if(moveRight)
                    {
                        action = AgentAction.MOVE_RIGHT;
                    }
                    else
                    {
                        action = AgentAction.MOVE_LEFT;
                    }
                }
                prevXAxis = currentXAxis;
                prevYAxis = currentYAxis;
            }   
            return action;
        }
    }
}