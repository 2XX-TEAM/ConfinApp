using ConfinApp.ViewModels;
using Splat;
using Xamarin.Forms;

namespace ConfinApp.Views
{
    public partial class OnboardingPage : ContentPage
    {
        public OnboardingPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        internal OnboardingViewModel ViewModel { get; set; } = Locator.Current.GetService<OnboardingViewModel>();

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
