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

            Content = new StackLayout
            {
                Children = { webView }
            };
        }
    }
}

