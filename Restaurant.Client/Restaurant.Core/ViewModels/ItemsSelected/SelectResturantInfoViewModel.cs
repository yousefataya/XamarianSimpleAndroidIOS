using AutoMapper;
using ReactiveUI;
using Restaurant.Abstractions.Api;
using Restaurant.Abstractions.DataTransferObjects;
using Restaurant.Abstractions.Facades;
using Restaurant.Abstractions.Providers;
using Restaurant.Abstractions.Services;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels.Food;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Restaurant.Core.ViewModels
{
   public class SelectResturantInfoViewModel : BaseViewModel, IRestaruantInfoViewModel
    {
        private string _streetname;
        private string _name;
        private string _address;
        private string _error;
        private bool fresturantLoaded;
        private readonly IMapper _mapper;
        private readonly IDiagnosticsFacade _diagnosticsFacade;
        private readonly IFoodsApi _foodsApi;
        private ObservableCollection<ResturantViewModel> _resturants;
        private ResturantViewModel _selectedResturant;

        internal SelectResturantInfoViewModel()
        {
        }

        public SelectResturantInfoViewModel(
              IMapper mapper,
              IFoodsApi foodsApi,
              IDiagnosticsFacade diagnosticsFacade,
              IAuthenticationProvider authenticationProvider,
              IMapper autoMapperFacade,
              INavigationService navigationService)
        {
            _mapper = mapper;
            _diagnosticsFacade = diagnosticsFacade;
            _foodsApi = foodsApi;
            var canLogin = this.WhenAny(x => x._streetname, x => x._name,
                (e, p) => !string.IsNullOrEmpty(e.Value) && !string.IsNullOrEmpty(p.Value));

            GoCatalog = ReactiveCommand.CreateFromTask(async () =>
                await navigationService.NavigateAsync(typeof(IResturantFoodsViewModel)));

            GoBack = ReactiveCommand.CreateFromTask(async () =>
            {
                IsLoading = true;
                var loginDto = autoMapperFacade.Map<LoginDto>(this);
                var tokenResponse = await authenticationProvider.Login(loginDto);

                if (tokenResponse.IsError)
                {
                    Error = "Invalid login or password!";
                    IsLoading = false;
                    return;
                }
                await navigationService.NavigateToMainPage(typeof(IMainViewModel));
                IsLoading = false;

            }, canLogin);
        }

        public ObservableCollection<ResturantViewModel> Resturants
        {
            get => _resturants;
            private set => this.RaiseAndSetIfChanged(ref _resturants, value);
        }

        public ResturantViewModel SelectedResturant
        {
            get => _selectedResturant;
            set => this.RaiseAndSetIfChanged(ref _selectedResturant, value);
        }

        public string Error
        {
            get => _error;
            set => this.RaiseAndSetIfChanged(ref _error, value);
        }

        /// <summary>
        ///  Gets and sets login command
        ///  Command that logins to service
        /// </summary>
        public ICommand GoBack { get; }

        public ICommand GoCatalog { get; }

        /// <summary>
        ///  Gets and sets user Email
        /// </summary>
        public string StreetName
        {
            get => _streetname;
            set => this.RaiseAndSetIfChanged(ref _streetname, value);
        }

        public string Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }

        /// <summary>
        ///  Gets and sets non encrypted user passwords
        /// </summary>
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public async Task LoadResturants()
        {
            if (fresturantLoaded)
                return;

            try
            {
                IsLoading = true;
                var foods = await _foodsApi.GetFoods();
                ResturantViewModel model = new ResturantViewModel();
                model.Name = "مطعم ابو عليص";
                model.Description = "مطعم ابو عليص";
                model.Picture = "icons8_restaurant_table_64.png";

                ResturantViewModel model_1 = new ResturantViewModel();
                model_1.Name = "مطعم ابو العدس";
                model_1.Description = "مطعم ابو العدس";
                model_1.Picture = "icons8_restaurant_table_64.png";

                ResturantViewModel model_2 = new ResturantViewModel();
                model_2.Name = "مطعم وشاورما الشام";
                model_2.Description = "ممطعم وشاورما الشام";
                model_2.Picture = "icons8_restaurant_table_64.png";

                var lists = new List<ResturantViewModel>();
                lists.Add(model);
                lists.Add(model_1);
                lists.Add(model_2);

                var rests = _mapper.Map<IEnumerable<ResturantViewModel>>(lists);
                Resturants = new ObservableCollection<ResturantViewModel>(rests);
                fresturantLoaded = true;

                IsLoading = false;
            }
            catch (Exception ex)
            {
                _diagnosticsFacade.TrackError(ex);
                Resturants = new ObservableCollection<ResturantViewModel>();
            }
            finally
            {
                IsLoading = false;
            }
        }
        public override string Title => "RestaurantInfoList";

    }
}
