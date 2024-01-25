using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    public class Buzzer: IAlertSystem
    {
        public void Alert()
        {
            Logger.Log(Logger.LogLevel.Warning,"Buzzer says: Door opened for over 20 seconds");
        }
    }
}
