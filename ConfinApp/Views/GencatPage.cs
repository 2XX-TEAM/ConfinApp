using Xamarin.Forms;

namespace ConfinApp.Views
{
    public class GencatPage : ContentPage
    {
        private WebView webView;
        private ToolbarItem goBack;
        private static readonly string TWITTER_GENCAT = "https://mobile.twitter.com/gencat?lang=ca";


        public GencatPage()
        {
            Title = "Notícies";

            webView = new WebView
            {
                Source = TWITTER_GENCAT,
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
            if (!e.Url.Equals(TWITTER_GENCAT))
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

