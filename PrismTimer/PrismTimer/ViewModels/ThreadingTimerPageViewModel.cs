using System;
using System.Reactive.Linq;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using PrismTimer.Services;

namespace PrismTimer.ViewModels
{
	public class ThreadingTimerPageViewModel : BindableBase
	{
        public string Title { get; }
        public ReactiveProperty<long> CurrentCount { get; }
        public ReactiveCommand StartCommand { get; } = new ReactiveCommand();
        public ReactiveCommand StopCommand { get; } = new ReactiveCommand();

        public ThreadingTimerPageViewModel(ThreadingTimerModel threadingTimerModel)
        {
            this.Title = "Thread";
            this.CurrentCount = threadingTimerModel.ObserveProperty(x => x.CurrentCount).ToReactiveProperty();
            this.StartCommand.Subscribe(_ => threadingTimerModel.Start());
            this.StopCommand.Subscribe(_ => threadingTimerModel.Stop());
        }
	}
}
