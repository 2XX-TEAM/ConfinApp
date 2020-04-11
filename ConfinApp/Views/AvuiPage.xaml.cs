using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConfinApp.Views
{
    public partial class AvuiPage : ContentPage
    {
        public ICommand MesInformacioCommand => new Command<string>((url) => Xamarin.Essentials.Launcher.OpenAsync(new Uri("https://web.gencat.cat/ca/coronavirus/")));
        
        public AvuiPage()
        {
            InitializeComponent();
            BindingContext = this;
            
            //today.Text = DateTime.Now.ToShortDateString();
        }
    }
}
