using Xamarin.Forms;

namespace ConfinApp.Views
{
    public class MossosPage : ContentPage
    {
        private WebView webView;
        private ToolbarItem goBack;
        private static readonly string TWITTER_MOSSOS = "https://mobile.twitter.com/mossos?lang=ca";

        public MossosPage()
        {
            Title = "Notícies";

            webView = new WebView
            {
                Source = TWITTER_MOSSOS,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            webView.Navigated += WebView_Navigated;

            Content = new StackLayout
            {
                Children = { webView }
            };

            goBack = new ToolbarItem("Enrere", null, () =>
            {
                webView.GoBack();
            });

        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (!e.Url.Equals(TWITTER_MOSSOS))
            {
                ToolbarItems.Add(goBack);
            }
            else
            {
                ToolbarItems.Remove(goBack);
            }
        }
    }
}

