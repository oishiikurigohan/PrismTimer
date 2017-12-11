using System.Threading;
using Prism.Mvvm;

namespace PrismTimer.Services
{
    public class ThreadingTimerModel : BindableBase
    {
        private Timer timer;
        private long currentCount;
        public long CurrentCount
        {
            get { return currentCount; }
            set { this.SetProperty(ref this.currentCount, value); }
        }

        public ThreadingTimerModel()
        {
            var callBack = new TimerCallback((o) => { CurrentCount++; });
            timer = new Timer(callBack, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start() => timer.Change(0, 1000);
        public void Stop() => timer.Change(Timeout.Infinite, Timeout.Infinite);
    }
}
