using Restaurant.Core.ViewModels;
using Restaurant.Mobile.UI.Constants;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResturantFoodInfo : ResturantFoodsViewModelPageXaml
    {
        public ResturantFoodInfo()
        {
            InitializeComponent();
            RestsList.SelectionChanged += (s, e) => { RestsList.SelectedItem = null; };
        }
        protected override async void OnLoaded()
        {
            base.OnLoaded();
            await AnimateControls(1, Easing.SinIn);
            await ViewModel.LoadCustomFoods();
        }

        private async Task AnimateControls(int scale, Easing easing)
        {
            /*await backStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);
            await recordsStack.ScaleTo(scale, AppConstants.AnimationSpeed, easing);*/
        }
    }
    public abstract class ResturantFoodsViewModelPageXaml : BaseContentPage<SelectResturantFoodsViewModel>
    {
    }

}