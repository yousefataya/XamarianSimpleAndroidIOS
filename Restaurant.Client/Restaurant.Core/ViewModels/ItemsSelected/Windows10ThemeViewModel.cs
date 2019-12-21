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
   public class Windows10ThemeViewModel : BaseViewModel, IWindows10ThemeViewModel
    {
        private string _streetname;
        private string _name;
        private string _address;
        private string _error;
        private bool fresturantLoaded;
        private readonly IMapper _mapper;
        private readonly IDiagnosticsFacade _diagnosticsFacade;
        private readonly IFoodsApi _foodsApi;
        private ObservableCollection<SettingsViewModel> _settings;
        private SettingsViewModel _selectedSetting;

        internal Windows10ThemeViewModel()
        {
        }

        public Windows10ThemeViewModel(
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

            GoBack    =  ReactiveCommand.CreateFromTask(async () =>
                await navigationService.NavigateAsync(typeof(IResturantFoodsViewModel)));
        }

        public ObservableCollection<SettingsViewModel> Settings
        {
            get => _settings;
            private set => this.RaiseAndSetIfChanged(ref _settings, value);
        }

        public SettingsViewModel SelectedSettings
        {
            get => _selectedSetting;
            set => this.RaiseAndSetIfChanged(ref _selectedSetting, value);
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

        public async Task LoadSettings()
        {
            if (fresturantLoaded)
                return;

            try
            {
                IsLoading = true;
                var foods = await _foodsApi.GetFoods();
                SettingsViewModel model = new SettingsViewModel();
                model.Name = "الاعدادات";
                model.Description = "الاعدادات";
                model.Picture = "icons8_administrative_tools_100.png";

                SettingsViewModel model_1 = new SettingsViewModel();
                model_1.Name = "حركات حسابية";
                model_1.Description = "حركات حسابية";
                model_1.Picture = "icons8_money_bag_100.png";

                SettingsViewModel model_2 = new SettingsViewModel();
                model_2.Name = "دردشة";
                model_2.Description = "دردشة";
                model_2.Picture = "icons8_chat_100.png";

                var lists = new List<SettingsViewModel>();
                lists.Add(model);
                lists.Add(model_1);
                lists.Add(model_2);

                var rests = _mapper.Map<IEnumerable<SettingsViewModel>>(lists);
                Settings = new ObservableCollection<SettingsViewModel>(rests);
                fresturantLoaded = true;

                IsLoading = false;
            }
            catch (Exception ex)
            {
                _diagnosticsFacade.TrackError(ex);
                Settings = new ObservableCollection<SettingsViewModel>();
            }
            finally
            {
                IsLoading = false;
            }
        }
        public override string Title => "Settings";

    }
}
