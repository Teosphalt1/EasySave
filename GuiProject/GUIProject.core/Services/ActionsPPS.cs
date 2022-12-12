using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUIProject
{
    public class ActionsPPS
    {
        public void Play(ManualResetEvent manualResetEvent)
        {
            new ActionsPPS().Play(manualResetEvent);
        }

        public void Pause(ManualResetEvent manualResetEvent)
        {
            new ActionsPPS().Pause(manualResetEvent);
        }

        public void Stop(IList<Thread> threadList)
        {
            if (threadList != null)
            {
                foreach (Thread thread in threadList)
                {
                    thread.Interrupt();
                }
            }
            threadList.Clear();
        }
    }
}
