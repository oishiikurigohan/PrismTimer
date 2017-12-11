using PrismTimer.Services;
using PrismTimer.Views;
using DryIoc;
using Prism.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismTimer
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/PrismTabbedPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<PrismTabbedPage>();
            Container.RegisterTypeForNavigation<RxTimerPage>();
            Container.RegisterTypeForNavigation<ThreadingTimerPage>();
            Container.RegisterInstance(new RxTimerModel());
            Container.RegisterInstance(new ThreadingTimerModel());
        }
    }
}
