using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConfinApp.Views
{
    public partial class ContactePage : ContentPage
    {
        public ICommand GencatCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        public ICommand EmergenciesCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        public ICommand TrucansCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        public ICommand MossosCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        public ICommand CatSalutCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        public ICommand InformacioCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));
        public ICommand EscriunosCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));


        public ContactePage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
