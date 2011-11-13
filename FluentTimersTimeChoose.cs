using System;
using System.Collections.Generic;

namespace LoggerBlogger.Timing
{
    public class FluentTimersTimeChoose
    {
        private readonly FluentTimer _timer;

        private readonly ICollection<TimeSpan> _times;

        private readonly int _timeValue;

        public FluentTimersTimeChoose(FluentTimer timer, int timeValue, ICollection<TimeSpan> times)
        {
            _timer = timer;
            _times = times;
            _timeValue = timeValue;
        }

        public FluentTimer Seconds()
        {
            _times.Add(TimeSpan.FromSeconds(_timeValue));
            return _timer;
        }

        public FluentTimer Minutes()
        {
            _times.Add(TimeSpan.FromMinutes(_timeValue));
            return _timer;
        }

        public FluentTimer Hours()
        {
            _times.Add(TimeSpan.FromHours(_timeValue));
            return _timer;
        }

        public FluentTimer Days()
        {
            _times.Add(TimeSpan.FromDays(_timeValue));
            return _timer;
        }

        public FluentTimer OClock()
        {
            return Hours();
        }
    }
}
