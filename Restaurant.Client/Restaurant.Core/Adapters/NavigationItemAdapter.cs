using Restaurant.Abstractions;
using Restaurant.Abstractions.Adapters;
using Restaurant.Abstractions.Enums;
using Restaurant.Abstractions.Factories;
using Restaurant.Abstractions.Services;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;
using System.Threading.Tasks;

namespace Restaurant.Core.Adapters
{
    public class NavigationItemAdapter : INavigationItemAdapter
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigationService _navigationService;

        public NavigationItemAdapter(IViewModelFactory viewModelFactory , INavigationService navigationService)
        {
            _viewModelFactory = viewModelFactory;
            _navigationService = navigationService;
        }

        public INavigatableViewModel GetViewModelFromNavigationItem(NavigationItem navigationItem)
        {
            switch (navigationItem)
            {
                case NavigationItem.Foods:
                    return _viewModelFactory.GetViewModel(typeof(FoodsViewModel));
                case NavigationItem.SelectRoleWorker:
                    /*Task.Run(async () => await _navigationService.NavigateAsync(typeof(ISelectRoleDetails)));*/
                    return _viewModelFactory.GetViewModel(typeof(ISelectRoleDetails));
                case NavigationItem.Info:
                    return _viewModelFactory.GetViewModel(typeof(IRestaruantInfoViewModel)); // TODO:
                case NavigationItem.Settings:
                    return _viewModelFactory.GetViewModel(typeof(IWindows10ThemeViewModel)); // TODO:
                //case NavigationItem.Settings:
                //    return _viewModelFactory.GetViewModel(typeof(object)); // TODO:
                default:
                    return null;
            }
        }
    }
}