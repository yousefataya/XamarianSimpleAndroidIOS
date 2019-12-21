using System.Windows.Input;
using AutoMapper;
using JetBrains.Annotations;
using ReactiveUI;
using Restaurant.Abstractions.DataTransferObjects;
using Restaurant.Abstractions.Facades;
using Restaurant.Abstractions.Providers;
using Restaurant.Abstractions.Services;
using Restaurant.Abstractions.ViewModels;

namespace Restaurant.Core.ViewModels
{
    [UsedImplicitly]
    public class SelectRolePageViewModel : BaseViewModel, ISelectRoleDetails
    {

        private string _createddate;
        private string _mobilenumber;
        private string _address;
        private string _error;

        public SelectRolePageViewModel(
              IAuthenticationProvider authenticationProvider,
              IMapper autoMapperFacade,
              INavigationService navigationService)
        {
            var canLogin = this.WhenAny(x => x._createddate, x => x._mobilenumber,
                (e, p) => !string.IsNullOrEmpty(e.Value) && !string.IsNullOrEmpty(p.Value));

            GoWorker = ReactiveCommand.CreateFromTask(async () =>
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

           GoCustomer = ReactiveCommand.CreateFromTask(async () =>
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

        public string Error
        {
            get => _error;
            set => this.RaiseAndSetIfChanged(ref _error, value);
        }

        /// <summary>
        ///  Gets and sets login command
        ///  Command that logins to service
        /// </summary>
        public ICommand GoWorker { get; }

        public ICommand GoCustomer { get; }

        /// <summary>
        ///  Gets and sets user Email
        /// </summary>
        public string CreatedDate
        {
            get => _createddate;
            set => this.RaiseAndSetIfChanged(ref _createddate, value);
        }

        public string Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }

        /// <summary>
        ///  Gets and sets non encrypted user passwords
        /// </summary>
        public string Mobile
        {
            get => _mobilenumber;
            set => this.RaiseAndSetIfChanged(ref _mobilenumber, value);
        }

        public override string Title => "SelectRoleType";


    }
}
