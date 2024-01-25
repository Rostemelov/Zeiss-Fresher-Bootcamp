using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseDoor
{
    public class Door : IDoor
    {
        public DoorState state;
        public double cost = 100;

        public Door()
        {
            this.state = DoorState.CLOSED;
            Logger.Log(Logger.LogLevel.Info, "The cost of the door is: " + Convert.ToString(this.cost));
        }

        public void SetState(DoorState state)
        {
            if (this.state != state)
            {
                this.state = state;
            }
        }



        public void CheckDoorState()
        {
            Logger.Log(Logger.LogLevel.Info, "DoorState: " + Convert.ToString(this.state));
        }
    }
}
