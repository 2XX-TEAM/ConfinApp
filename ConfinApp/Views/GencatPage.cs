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

            goBack = new ToolbarItem("Torna", null, () =>
            {
                webView.GoBack();
            });
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Url.Equals(TWITTER_GENCAT))
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

