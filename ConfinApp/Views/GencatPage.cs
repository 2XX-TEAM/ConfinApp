using Xamarin.Forms;

namespace ConfinApp.Views
{
    public class GencatPage : ContentPage
    {
        private WebView webView;

        public GencatPage()
        {
            Title = "Notícies";

            webView = new WebView
            {
                Source = "https://twitter.com/gencat?lang=ca",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };


            ToolbarItems.Add(new ToolbarItem("Back", null, () =>
            {
                webView.GoBack();
            }));

            Content = new StackLayout
            {
                Children = { webView }
            };

        }

        
        protected override bool OnBackButtonPressed()
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert", "SDSD", "ASD", "ADA");

            });

            return true;
        }

    }
}

