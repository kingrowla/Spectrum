using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public DelegateCommand FilterByNameCommand { get; set; }
        public DelegateCommand<Employee> EmployeeSelectedComamnd { get; private set; }

        public bool IsBusy { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee { get; set; }
        public string LoginName { get; set; }
        public List<Employee> EmployeeResponse { get; set; }

        public EmployeeViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            Title = "Employees";
            EmployeeSelectedComamnd = new DelegateCommand<Employee>(ShowEmployeeDetail);
            FilterByNameCommand = new DelegateCommand(FilterEmployee);
        }

        private void FilterEmployee()
        {
            Employees = new ObservableCollection<Employee>(Employees.OrderBy(e => e.LastName));
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
            Employees = await GetAllEmployees();
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
    }
}
