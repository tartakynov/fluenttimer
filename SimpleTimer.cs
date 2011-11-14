using System;
using System.Threading;

namespace LoggerBlogger.Timing
{
    public class SimpleTimer
    {
        private Timer _timer;

        private Action<SimpleTimer> _action;

        private readonly AutoResetEvent _stopEvent = new AutoResetEvent(false);

        protected SimpleTimer()
        {
            
        }

        protected SimpleTimer(TimeSpan time, Action<SimpleTimer> action)
        {
            PeriodicTimer(TimeSpan.FromMinutes(1), delegate
            {
                // Console.WriteLine("{0} {1}", (DateTime.Now.TimeOfDay - time).TotalMinutes, (int)Math.Round((DateTime.Now.TimeOfDay - time).TotalMinutes));
                if (((int)DateTime.Now.TimeOfDay.TotalMinutes - (int)time.TotalMinutes) == 0)
                    action(this);
            });
        }

        /// <summary>
        /// Calls action at exact time0
        /// </summary>
        public static SimpleTimer ScheduledTimer(TimeSpan time, Action<SimpleTimer> action)
        {
            return new SimpleTimer(time, action);
        }

        /// <summary>
        /// Calls action with specified period
        /// </summary>
        public static SimpleTimer PeriodicTimer(TimeSpan period, Action<SimpleTimer> action)
        {
            var timer = new SimpleTimer
                            {
                                _action = action
                            };
            Action async = delegate
                               {
                                   using (timer._timer = new Timer(timer.TimerCallback, null, 0, (int) (period.TotalSeconds*1000)))
                                   {
                                       // wait for a call to stop
                                       timer._stopEvent.WaitOne();
                                   }
                               };
            async.BeginInvoke(null, null);
            return timer;
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
            _action(this);
        }
    }
}
