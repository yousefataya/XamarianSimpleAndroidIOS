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
    public class SelectResturantFoodsViewModel : BaseViewModel, IResturantFoodsViewModel
    {

        private string _streetname;
        private string _name;
        private string _address;
        private string _error;
        private bool fresturantLoaded;
        private readonly IMapper _mapper;
        private readonly IDiagnosticsFacade _diagnosticsFacade;
        private readonly IFoodsApi _foodsApi;
        private ObservableCollection<FoodViewModel> _resturants;
        private FoodViewModel _selectedResturant;


        internal SelectResturantFoodsViewModel()
        {
        }

        public SelectResturantFoodsViewModel(
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


        public ObservableCollection<FoodViewModel> Foods
        {
            get => _resturants;
            private set => this.RaiseAndSetIfChanged(ref _resturants, value);
        }

        public FoodViewModel SelectedFood
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
        public string Name
        {
            get => _streetname;
            set => this.RaiseAndSetIfChanged(ref _streetname, value);
        }

        public string Price
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }

        /// <summary>
        ///  Gets and sets non encrypted user passwords
        /// </summary>
        public string Size
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public async Task LoadCustomFoods()
        {
            if (fresturantLoaded)
                return;

            try
            {
                IsLoading = true;
                var foods = await _foodsApi.GetFoods();
                FoodViewModel model = new FoodViewModel();
                model.Name = "اكلات شعبية";
                model.Description = "مفتول";
                model.Picture = "food_1.jpeg";

                FoodViewModel model_1 = new FoodViewModel();
                model_1.Name = "اكلات شعبية";
                model_1.Description = "حمص و فول و فلافل";
                model_1.Picture = "food_2.jpeg";

                FoodViewModel model_2 = new FoodViewModel();
                model_2.Name = "اكلات شعبية";
                model_2.Description = "مقلوبة";
                model_2.Picture = "food_3.jpeg";

                FoodViewModel model_3 = new FoodViewModel();
                model_3.Name = "اكلات شعبية";
                model_3.Description = "شوربة العدس";
                model_3.Picture = "food_4.jpeg";

                var lists = new List<FoodViewModel>();
                lists.Add(model);
                lists.Add(model_1);
                lists.Add(model_2);

                var rests = _mapper.Map<IEnumerable<FoodViewModel>>(lists);
                Foods = new ObservableCollection<FoodViewModel>(rests);
                fresturantLoaded = true;

                IsLoading = false;
            }
            catch (Exception ex)
            {
                _diagnosticsFacade.TrackError(ex);
                Foods = new ObservableCollection<FoodViewModel>();
            }
            finally
            {
                IsLoading = false;
            }
        }
        public override string Title => "RestaurantInfoFoods";

    }
}
