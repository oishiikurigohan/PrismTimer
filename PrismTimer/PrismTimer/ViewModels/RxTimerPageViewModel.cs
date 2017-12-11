using System;
using System.Reactive.Linq;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using PrismTimer.Services;

namespace PrismTimer.ViewModels
{
	public class RxTimerPageViewModel : BindableBase
	{
        public string Title { get; }
        public ReactiveProperty<bool> IsStartButtonEnabled { get; }
        public ReactiveProperty<long> CurrentCount { get; }
        public ReactiveCommand StartCommand { get; } = new ReactiveCommand();
        public ReactiveCommand StopCommand { get; } = new ReactiveCommand();

        public RxTimerPageViewModel(RxTimerModel rxTimerModel)
        {
            this.Title = "Rx";
            this.CurrentCount = rxTimerModel.ObserveProperty(x => x.CurrentCount).ToReactiveProperty();
            this.IsStartButtonEnabled = rxTimerModel.ObserveProperty(x => x.CanStarted).ToReactiveProperty();
            this.StartCommand.Subscribe(_ => rxTimerModel.Start());
            this.StopCommand.Subscribe(_ => rxTimerModel.Stop());
        }
	}
}
