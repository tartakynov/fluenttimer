using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerBlogger.Timing
{
    public class FluentTimer
    {
        protected readonly ICollection<TimeSpan> Times;

        protected Boolean IsPeriodic = true;

        protected FluentTimer()
        {
            Times = new List<TimeSpan>();
        }

        public static FluentTimersTimeChoose At(Int32 timeValue)
        {
            var timer = new FluentTimer
            {
                IsPeriodic = false
            };
            return new FluentTimersTimeChoose(timer, timeValue, timer.Times);
        }

        public static FluentTimersTimeChoose Each(Int32 timeValue)
        {
            var timer = new FluentTimer();
            return new FluentTimersTimeChoose(timer, timeValue, timer.Times);
        }

        public FluentTimersTimeChoose And(Int32 timeValue)
        {
            return new FluentTimersTimeChoose(this, timeValue, Times);
        }

        public SimpleTimer Call(Action action)
        {
            var time = Times.Aggregate((t1, t2) => t1.Add(t2));
            return IsPeriodic ? SimpleTimer.PeriodicTimer(time, action) : SimpleTimer.ScheduledTimer(time, action);
        }
    }
}
