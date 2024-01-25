using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    public class Door: IDoor
    {
        public DoorState state;
        private readonly Action OnOpen = null;
        public double cost = 100;

        public Door(Dictionary<string, bool> requirements, TimeSpan threshold)
        {
            bool allValuesFalse = requirements.Values.All(value => value == false);
            if (allValuesFalse)
            {
                this.state = DoorState.CLOSED;
                this.cost = 100;
                Logger.Log(Logger.LogLevel.Info, "The cost of the door is: " + Convert.ToString(this.cost));
            }
            else
            {
                this.state = DoorState.CLOSED;
                this.cost = 200;
                this.OnOpen = () => { };
                DoorTimer timer = new DoorTimer(this, requirements, threshold);
                this.OnOpen += timer.Start;
                Logger.Log(Logger.LogLevel.Info, "The cost of the door is: " + Convert.ToString(this.cost));
            }
        }

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
                if (this.state == DoorState.OPENED) 
                { OnOpen?.Invoke(); } 
            }
        }



        public void CheckDoorState()
        {
            Logger.Log(Logger.LogLevel.Info, "DoorState: "+Convert.ToString(this.state));
        }
    }
}
