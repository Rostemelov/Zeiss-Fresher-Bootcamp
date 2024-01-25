using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    public class Pager: IAlertSystem
    {
        public void Alert()
        {
            Logger.Log(Logger.LogLevel.Warning, "Pager says: Door opened for over 20 seconds");
        }
    }
}
