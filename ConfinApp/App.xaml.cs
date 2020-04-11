using ConfinApp.Services.Identity;
using ConfinApp.Services.Routing;
using ConfinApp.ViewModels;
using ConfinApp.Views;
using Splat;
using Xamarin.Forms;

namespace ConfinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeRouters();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private void InitializeRouters()
        {
            Locator.CurrentMutable.RegisterLazySingleton<IRoutingService>(() => new ShellRoutingService());
            Locator.CurrentMutable.RegisterLazySingleton<IIdentityService>(() => new IdentityServiceStub());

            Locator.CurrentMutable.Register(() => new OnboardingViewModel());
        }
    }
}
