using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;
using System;
using WindowsAzure.Messaging;

namespace ConfinApp.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            string messageBody = string.Empty;
            string title = string.Empty;
            string redirectTo = string.Empty;

            if (message.GetNotification() != null)
            {
                messageBody = message.GetNotification().Body;
            }

            // NOTE: test messages sent via the Azure portal will be received here
            else
            {
                title = message.Data["title"];
                messageBody = message.Data["body"];
                redirectTo = message.Data["redirectTo"];
            }

            // convert the incoming message to a local notification
            SendLocalNotification(title, messageBody, redirectTo);

            // send the incoming message directly to the MainPage
            //SendMessageToMainPage(messageBody);
        }

        public override void OnNewToken(string token)
        {
            SendRegistrationToServer(token);
        }

        void SendLocalNotification(string title, string body, string redirectTo)
        {
            //var intent = new Intent(this, typeof(MainActivity));
            var intent = new Intent(Intent.ActionView);
            intent.SetPackage("com.google.android.youtube");
            intent.SetData(Android.Net.Uri.Parse("https://www.youtube.com/watch?v=vKRWFOiF_hM"));


            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("message", body);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, AppConstants.NotificationChannelName)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentText(body)
                .SetAutoCancel(true)
                .SetShowWhen(false)
                .SetContentIntent(pendingIntent);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                notificationBuilder.SetChannelId(AppConstants.NotificationChannelName);
            }

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());
        }

        /*void SendMessageToMainPage(string body)
        {
            (App.Current.MainPage as MainPage)?.AddMessage(body);
        }*/

        void SendRegistrationToServer(string token)
        {
            try
            {
                NotificationHub hub = new NotificationHub(AppConstants.NotificationHubName, AppConstants.ListenConnectionString, this);

                // register device with Azure Notification Hub using the token from FCM
                Registration registration = hub.Register(token, AppConstants.SubscriptionTags);

                // subscribe to the SubscriptionTags list with a simple template.
                string pnsHandle = registration.PNSHandle;
                TemplateRegistration templateReg = hub.RegisterTemplate(pnsHandle, "defaultTemplate", AppConstants.FCMTemplateBody, AppConstants.SubscriptionTags);
            }
            catch (Exception e)
            {
                Log.Error(AppConstants.DebugTag, $"Error registering device: {e.Message}");
            }
        }
    }
}
