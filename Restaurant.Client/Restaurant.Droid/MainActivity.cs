using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Autofac;
using ImageCircle.Forms.Plugin.Abstractions;
using ImageCircle.Forms.Plugin.Droid;
using Restaurant.Abstractions.Services;
using Restaurant.Droid.Renderers;
using Restaurant.Mobile.UI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AColor = Android.Graphics.Color;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
/*using Android.App;*/
using Android.Content;
/*using Android.Content.PM;*/
/*using Android.OS;*/
using Android.Runtime;
/*using Android.Support.V7.App;*/
/*using DualSplash.Android.Ioc.Locator;
using DualSplash.Core;
using DualSplash.Core.Ioc;*/
using Xamarin;
/*using Xamarin.Forms;*/
/*using XLabs.Ioc;
using XLabs.Ioc.Autofac;*/
using Application = Android.App.Application;

namespace Restaurant.Droid
{
    [Activity(
        Label = "FoodDelivery", 
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   
    public class MainActivity : FormsAppCompatActivity
    {
        static MainActivity()
        {
            AppCompatDelegate.CompatVectorFromResourcesEnabled = true;
        }

        
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);
            /*Forms.SetFlags("FastRenderers_Experimental");*/
            /*Forms.SetFlags("CollectionView_Experimental", "FastRenderers_Experimental", "UseLegacyRenderers");*/
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental", "FastRenderers_Experimental", "UseLegacyRenderers");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            /*Forms.Init(this, bundle);*/
            
            ImageCircleRenderer.Init();
            MakeStatusBarTranslucent(false);
            LoadApplication(new App(new AndroidPlatformInitializer()));
        }       

        internal void MakeStatusBarTranslucent(bool makeTranslucent)
        {
            if (makeTranslucent)
            {
                SetStatusBarColor(AColor.Transparent);
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable);
                }
            }
            else
            {                
                SetStatusBarColor(GetColorPrimaryDark());
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                }
            }
        }

        private AColor GetColorPrimaryDark()
        {
            using (var value = new TypedValue())
            {
                if (Theme.ResolveAttribute(Resource.Attribute.colorPrimaryDark, value, true))
                {
                    var color = new AColor(value.Data);
                    return color;
                }

                return AColor.Transparent;
            }
        }

        internal AColor GetColorPrimary()
        {
            using (var value = new TypedValue())
            {
                if (Theme.ResolveAttribute(Resource.Attribute.colorPrimary, value, true))
                {
                    var color = new AColor(value.Data);
                    return color;
                }

                return AColor.Transparent;
            }
        }
    }

    public class AndroidPlatformInitializer : MobilePlatformInitializer
    {
        protected override void RegisterTypes(ContainerBuilder builder)
        {
            base.RegisterTypes(builder);
            builder.RegisterType<LoggingService>().As<ILoggingService>();
        }
    }


}