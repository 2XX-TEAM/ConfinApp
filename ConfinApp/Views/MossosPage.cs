using Xamarin.Forms;

namespace ConfinApp.Views
{
    public class MossosPage : ContentPage
    {
        private WebView webView;

        public MossosPage()
        {
            Title = "Notícies";

            webView = new WebView
            {
                Source = "https://twitter.com/mossos?lang=ca",
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

