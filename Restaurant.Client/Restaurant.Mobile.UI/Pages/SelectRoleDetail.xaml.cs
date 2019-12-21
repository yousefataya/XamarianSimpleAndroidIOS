using Restaurant.Core.ViewModels;
using Restaurant.Core.ViewModels.Food;
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
    public partial class SelectRoleDetail : SelectDetailPageXaml
    {
        public SelectRoleDetail()
        {
            InitializeComponent();
        }

        protected override async void OnLoaded()
        {
            await AnimateControls(1, Easing.SinIn);
        }

        private async Task AnimateControls(int scale, Easing easing)
        {
            await mobileStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);
            await personStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);
            await addressStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);
        }

    }

    public abstract class SelectDetailPageXaml : BaseContentPage<SelectRoleBaseViewModel>
    {
    }

}