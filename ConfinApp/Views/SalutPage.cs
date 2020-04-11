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

            goBack = new ToolbarItem("Torna", null, () =>
            {
                webView.GoBack();
            });
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Url.Equals(TWITTER_SALUT))
            {
                if (ToolbarItems.Count > 0)
                {
                    ToolbarItems.Remove(goBack);
                }
            }
            else
            {
                if (ToolbarItems.Count == 0)
                {
                    if (ToolbarItems.Count == 0)
                    {
                        ToolbarItems.Add(goBack);
                    }
                }
            }
        }
    }
}

