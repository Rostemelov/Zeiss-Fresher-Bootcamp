using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    public class DoorCreator
    { 
        public object Fabricate()
        {
            object door;
            Logger.Log(Logger.LogLevel.Info, "Door Fabrication Started");
            Logger.Log(Logger.LogLevel.Info, "Choose your Type of Door. Enter SMART if you require a Smart Door and its features");
            if (Console.ReadLine() == "SMART")
            {
                Dictionary<string, bool> req = GetRequirements();

                Logger.Log(Logger.LogLevel.Info, "Set the door timer limit in seconds");
                int delay = Convert.ToInt32(Console.ReadLine());
                TimeSpan threshold = TimeSpan.FromSeconds(delay);
                door = new SmartDoor(req, threshold);
            }
            else
            {
                door = new Door();
            }
            
            return door;
        }

        public Dictionary<string, bool> GetRequirements() 
        {
            Dictionary<string, bool> requirements = new Dictionary<string, bool>
            {
                {"Buzzer", false },
                {"Pager", false },
                {"AutoClose", false },
            };
            //Not sure of alternative to reading requirements.
            Logger.Log(Logger.LogLevel.Info, "Should buzzer feature be included? Enter Y if yes");
            if(Console.ReadLine() == "Y") { requirements["Buzzer"] = true; }   
            Logger.Log(Logger.LogLevel.Info, "Should buzzer feature be included? Enter Y if yes");
            if (Console.ReadLine() == "Y") { requirements["Pager"] = true; }
            Logger.Log(Logger.LogLevel.Info, "Should autoclose feature be included? Enter Y if yes");
            if (Console.ReadLine() == "Y") { requirements["AutoClose"] = true; }
            return requirements;
        }
    }
}
