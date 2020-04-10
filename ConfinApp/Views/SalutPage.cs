using Xamarin.Forms;

namespace ConfinApp.Views
{
    public class SalutPage : ContentPage
    {
        private WebView webView;
        private ToolbarItem goBack;
        private static readonly string TWITTER_SALUT = "https://mobile.twitter.com/salutcat?lang=ca";

        public SalutPage()
        {
            Title = "Notícies";

            webView = new WebView
            {
                Source = TWITTER_SALUT,
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
            if (!e.Url.Equals(TWITTER_SALUT))
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

