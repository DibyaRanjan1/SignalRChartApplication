using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRChartApplication.TimeManager
{
    public class TimerChart
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; }
        public TimerChart(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 2000, 3000);
            TimerStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).Seconds > 120)
            {
                _timer.Dispose();
            }
        }
    }
}
