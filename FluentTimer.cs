using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerBlogger.Timing
{
    public class FluentTimer
    {
        protected readonly ICollection<TimeSpan> Times;

        protected FluentTimer()
        {
            Times = new List<TimeSpan>();
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
            return new SimpleTimer(Times.Aggregate((t1, t2) => t1.Add(t2)), action);
        }
    }
}
