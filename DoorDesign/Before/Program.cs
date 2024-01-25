using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PurchaseDoor
{
    internal class Program
    {
        static void Main()
        {
            DoorCreator creator = new DoorCreator();
            Door door= creator.Fabricate();
            bool running = true;
            short choice;
            while (running)
            {
                Logger.Log(Logger.LogLevel.Info, "Enter:\n 1 - Open Door\n 2 - Close Door\n 3 - Check Door State\n 4 - Exit");
                choice = Convert.ToInt16(Console.ReadLine());
                //calls the appropriate function here based on user choice.
                switch(choice)
                {
                    case 1:
                        door.SetState(DoorState.OPENED);
                        break;
                    case 2:
                        door.SetState(DoorState.CLOSED);
                        break;
                    case 3:
                        door.CheckDoorState();
                        break;
                    case 4:
                        running = false;
                        break;
                }
                
            }
        }
    }
}
