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

            goBack = new ToolbarItem("Torna", null, () =>
            {
                webView.GoBack();
            });

        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Url.Equals(TWITTER_MOSSOS))
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

