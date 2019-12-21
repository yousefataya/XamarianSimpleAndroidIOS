using Restaurant.Core.ViewModels;
using Restaurant.Core.ViewModels.Food;
using Restaurant.Mobile.UI.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResturantInfo : ResturantDetailPageXaml
    {
        
        public ResturantInfo()
        {
            InitializeComponent();
            RestsList.SelectionChanged += (s, e) => { RestsList.SelectedItem = null; };
        }
        protected override async void OnLoaded()
        {
            base.OnLoaded();
            await AnimateControls(1, Easing.SinIn);
            await ViewModel.LoadResturants();
        }

        private async Task AnimateControls(int scale, Easing easing)
        {
            /*await backStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);
            await foodsStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);*/
        }
    }
    public abstract class ResturantDetailPageXaml : BaseContentPage<SelectResturantInfoViewModel>
    {
    }
}