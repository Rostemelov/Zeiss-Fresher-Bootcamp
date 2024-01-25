using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    public class AutoCloser
    {
        public void Alert(Door door)
        {
            door.SetState(DoorState.CLOSED);
            Logger.Log(Logger.LogLevel.Info, "AutoCloser says: Door opened for over 20 seconds. Closed the door");
        }
    }
}
