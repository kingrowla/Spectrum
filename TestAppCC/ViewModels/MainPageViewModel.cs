using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace TestAppCC.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public DelegateCommand<string> NavigateCommand { get; set; }
        public DelegateCommand ShowPasswordCommand { get; set; }

        public bool IsBusy { get; set; } 

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string ShowPasswordButtonText { get; set; }
        
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            Title = "Test Application";
            ShowPasswordButtonText = "show";
            NavigateCommand = new DelegateCommand<string>(Navigate);
            ShowPasswordCommand = new DelegateCommand(TogglePassword);
        }

        async void Navigate(string name)
        {
            if (string.IsNullOrEmpty(LoginName))
            {
               await _dialogService.DisplayAlertAsync("Login Error", "While there's really no credentials to authenticate to, please enter any value for a username to continue.", "OK");
            }
            else
            {
                var parameter = new NavigationParameters();
                parameter.Add("loginName", LoginName);
                IsBusy = true;
                await _navigationService.NavigateAsync(name, parameter);
                IsBusy = false;
            }
        }
        async void TogglePassword()
        {
           
        }
    }
}
