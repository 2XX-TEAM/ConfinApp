using System;
using System.Collections.Generic;
using ConfinApp.Models;
using ConfinApp.Services;
using ConfinApp.Views;
using Xamarin.Forms;

namespace ConfinApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
            
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {

        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }
    }
}
