﻿using System;
using System.Collections.Generic;
using ConfinApp.Models;
using ConfinApp.Services;
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
            RegisterRoutes();
            BindingContext = this;
            
        }


        async void RegisterRoutes()
        {
            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }

            List<COVID19_Cat> covidCatData = await PandemicData.GetIncidenciaCatalunya();
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {

        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {

        }
    }
}
