using System;
using System.Threading;

namespace LoggerBlogger.BestPractice
{
    public class SimpleTimer
    {
        private System.Threading.Timer _timer;

        private readonly Action _action;

        private readonly AutoResetEvent _stopEvent = new AutoResetEvent(false);

        public SimpleTimer(TimeSpan period, Action action)
        {
            _action = action;
            Action async = delegate()
                           {
                               using (_timer = new System.Threading.Timer(TimerCallback, null, 0, (int)(period.TotalSeconds * 1000)))
                               {
                                   // wait for a call to stop
                                   _stopEvent.WaitOne();
                               }
                           };
            async.BeginInvoke(null, null);
        }

        /// <summary>
        /// Stop timer
        /// </summary>
        public void Stop()
        {
            _stopEvent.Set();
        }

        private void TimerCallback(Object state)
        {
            _action();
        }
    }
}
