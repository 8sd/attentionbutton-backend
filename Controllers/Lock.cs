using System;
using System.Threading;

namespace attentionbutton_backend.Controllers {
    public class Lock {
        ManualResetEvent waitForEvent = new ManualResetEvent(false);

        public bool wait(int timeout = 30000) { //Block
            return waitForEvent.WaitOne(timeout);
        }

        public void unwaitall() {
            try {
                waitForEvent.Set(); //Trigger all
                waitForEvent.Reset(); //Wait for next event
            } catch (Exception e) {
                Console.WriteLine("Error while triggering the MRE event");
                Console.Write(e.ToString());
                System.Environment.Exit (1);
            }
        }
    }
}