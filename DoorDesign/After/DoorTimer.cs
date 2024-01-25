using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PurchaseDoor
{
    public class DoorTimer
    {
        public event Action OnTimerUp = null;
        public event Action<Door> OnAutomatedTimerUp = null;
        readonly SmartDoor door;
        TimeSpan threshold;
       
        public DoorTimer(SmartDoor door, Dictionary<string, bool> requirements, TimeSpan threshold)
        {
            this.door = door;
            this.threshold = threshold;
            //Not sure what alternative to use to add required features. 
            if (requirements["Pager"] || requirements["Buzzer"])    
            {
                this.OnTimerUp = () => { };
                if (requirements["Pager"])
                { 
                    this.door.cost += 100;
                    Pager pager = new Pager();
                    OnTimerUp += new Action(pager.Alert);
                }
                if (requirements["Buzzer"])
                {
                    this.door.cost += 100;
                    Buzzer buzzer = new Buzzer();
                    OnTimerUp += new Action(buzzer.Alert);
                }
            }
            if (requirements["AutoClose"])
            { 
                this.door.cost += 100;  
                AutoCloser autoCloser = new AutoCloser();
                OnAutomatedTimerUp = new Action<Door>(autoCloser.Alert);
            }
        }

         public void Start() 
        {
            Task timer = Timer(this.threshold);
            Console.WriteLine("TimerStart");
        }

        private async Task Timer(TimeSpan delay) 
        {
            await Task.Delay(delay);
            if (this.door.state == DoorState.OPENED)
            {
                OnTimerUp?.Invoke();
                OnAutomatedTimerUp?.Invoke(this.door);
            }
        }
    }
}
