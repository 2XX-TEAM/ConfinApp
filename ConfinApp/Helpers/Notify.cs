using System;
using Acr.UserDialogs;

namespace ConfinApp.Helpers
{
    public static class Notify
    {
        public static void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading("Carregant", MaskType.Clear);
        }

        public static void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
