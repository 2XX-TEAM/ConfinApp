using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConfinApp.Views
{
    public partial class OnboardingPage : ContentPage
    {
        private Page mainPage;

        private Command _ometreCommand;
        public ICommand OmetreCommand
        {
            get { return _ometreCommand = _ometreCommand ?? new Command(ExecuteOmetreCommand); }
        }

        public OnboardingPage(Page MainPage)
        {
            InitializeComponent();
            BindingContext = this;

            this.mainPage = MainPage;
        }

        private async void ExecuteOmetreCommand()
        {
            //await Navigation.PushAsync(new AppShell());
        }
    }
}
