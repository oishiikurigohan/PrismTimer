using System;
using System.Reactive.Linq;
using Prism.Mvvm;

namespace PrismTimer.Services
{
    public class RxTimerModel : BindableBase
    {
        private IDisposable subscription;
        private long currentCount;
        public long CurrentCount
        {
            get { return currentCount; }
            set { this.SetProperty(ref this.currentCount, value); }
        }
        private bool canStarted;
        public bool CanStarted
        {
            get { return canStarted; }
            set { this.SetProperty(ref this.canStarted, value); }
        }

        public RxTimerModel()
        {
            CanStarted = true;
        }

        public void Start()
        {
            subscription = Observable.Interval(TimeSpan.FromSeconds(0.5)).Subscribe(x => { CurrentCount = x; });
            CanStarted = false;
        }

        public void Stop()
        {
            subscription.Dispose();
            CanStarted = true;
        }
    }
}
