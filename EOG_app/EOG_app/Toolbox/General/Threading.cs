using System;
using System.Threading;

namespace Toolbox.General
{
    public class Threading
    {
        public Thread thread;
        public ThreadMethod threadMethod;
        public delegate void ThreadMethod();

        public bool isPaused = true;
        public bool isAlive;

        public Threading(ThreadMethod _threadMethod)
        {
            isAlive = true;
            threadMethod = _threadMethod;
            thread = new Thread(RunMethod);
        }

        private void RunMethod()
        {
            while (isAlive)
            {
                if (!isPaused)
                {
                    threadMethod();
                }
            }
        }

        public void Pause()
        {
            isPaused = true;
        }

        public void Resume()
        {
            isPaused = false;
        }

        public void Start()
        {
            isPaused = false;
            thread.Start();
        }

        public void Stop()
        {
            // .NET doesn't provides a native method to kill a thread
            // a possible workaround for this, is to create a new thread, with the same name
            // But, PYAGNI
            isAlive = false;
            isPaused = true;
            thread.Abort();
        }
    }
}
