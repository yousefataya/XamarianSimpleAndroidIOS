using Restaurant.Core.ViewModels;
using Restaurant.Mobile.UI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Windows10Theme : Windows10ThemePageXaml
    {
        public Windows10Theme()
        {
            InitializeComponent();
            RestsList.SelectionChanged += (s, e) => { RestsList.SelectedItem = null; };
        }

        protected override async void OnLoaded()
        {
            base.OnLoaded();
            await AnimateControls(1, Easing.SinIn);
            await ViewModel.LoadSettings();
        }

        private async Task AnimateControls(int scale, Easing easing)
        {
            /*await backStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);
            await foodsStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);*/
        }

    }
    public abstract class Windows10ThemePageXaml : BaseContentPage<Windows10ThemeViewModel>
    {
    }
}