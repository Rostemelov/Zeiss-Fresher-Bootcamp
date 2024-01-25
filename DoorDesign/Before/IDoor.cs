using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    internal interface IDoor
    {
        void SetState(DoorState state);
        void CheckDoorState();
    }
}
