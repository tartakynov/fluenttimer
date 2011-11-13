using System;
using System.Collections.Generic;

namespace LoggerBlogger.BestPractice
{
    public class FluentTimersTimeChoose
    {
        private readonly BestPractice.FluentTimer _timer;

        private readonly ICollection<TimeSpan> _times;

        private readonly int _timeValue;

        public FluentTimersTimeChoose(BestPractice.FluentTimer timer, int timeValue, ICollection<TimeSpan> times)
        {
            _timer = timer;
            _times = times;
            _timeValue = timeValue;
        }

        public BestPractice.FluentTimer Seconds()
        {
            _times.Add(TimeSpan.FromSeconds(_timeValue));
            return _timer;
        }

        public BestPractice.FluentTimer Minutes()
        {
            _times.Add(TimeSpan.FromMinutes(_timeValue));
            return _timer;
        }

        public BestPractice.FluentTimer Hours()
        {
            _times.Add(TimeSpan.FromHours(_timeValue));
            return _timer;
        }

        public BestPractice.FluentTimer Days()
        {
            _times.Add(TimeSpan.FromDays(_timeValue));
            return _timer;
        }

    }
}
