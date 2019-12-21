using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace Restaurant.Droid
{
    [Activity(
        Label = "FoodDelivery",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            base.OnCreate(savedInstanceState);
            /*var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
            var notificationBuilder = new NotificationCompat.Builder(this)
            .SetSmallIcon(Resource.Drawable.icon)
            .SetContentTitle("Notification")
            .SetContentText("Please Wait While Settings is Processing")
            .SetAutoCancel(true)
            .SetSound(defaultSoundUri);

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());*/
            StartActivity(typeof(MainActivity));
        }
    }
}