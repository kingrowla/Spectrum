using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Refit;
using TestAppCC.API.Models;
using TestAppCC.API.Services;

namespace TestAppCC.ViewModels.Employees
{
    public class EmployeeViewModel : ViewModelBase, IInitializeAsync
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        public DelegateCommand<string> NavigateCommand { get; set; }
        public DelegateCommand<Employee> EmployeeSelectedComamnd { get; private set; }

        public bool IsBusy { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee { get; set; }
        public string LoginName { get; set; }
        public List<Employee> EmployeeResponse { get; set; }

        public EmployeeViewModel(
            INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;

            Title = "Employees";
            _navigationService = navigationService;
            EmployeeSelectedComamnd = new DelegateCommand<Employee>(ShowEmployeeDetail);

            //await _devicePermissionService.CheckAndRequestCameraPermissionAsync(async () =>
            //        await _popupService.PushAsync(_scanner));
            Prepare();
        }

        async Task<ObservableCollection<Employee>> GetAllEmployees()
        {
            try
            {
                var apiClient = RestService.For<IEmployeeService>(BaseEmployeeApi.BaseUrl);
                var response = await apiClient.Employees();
                return new ObservableCollection<Employee>(response);
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Service Error", ex.Message, "OK");
            }
            return null;
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("loginName"))
            {
                var result = await Task.Run(() => LoginName = (string)parameters["loginName"]);
            }
        }
        private void ShowEmployeeDetail(Employee employeeItem)
        {
            SelectedEmployee = employeeItem;
            var parameter = new NavigationParameters();
            parameter.Add("employeeItem", SelectedEmployee);
            IsBusy = true;
            _navigationService.NavigateAsync("EmployeeDetailPage", parameter);
            IsBusy = false;
        }
       
        private async void Prepare()
        {
            Employees = await GetAllEmployees();
            Console.Write(Employees);
        }
    }
}
