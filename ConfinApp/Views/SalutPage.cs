using Xamarin.Forms;

namespace ConfinApp.Views
{
    public class SalutPage : ContentPage
    {
        private WebView webView;

        public SalutPage()
        {
            Title = "Notícies";

            webView = new WebView
            {
                Source = "https://twitter.com/salutcat?lang=ca",
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
    }
}

