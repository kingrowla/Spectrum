using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using TestAppCC.API.Models;

namespace TestAppCC.ViewModels.Employees
{
    public class EmployeeDetailViewModel : ViewModelBase, IInitializeAsync
    {
        public DelegateCommand<string> NavigateCommand { get; set; }

        public bool IsBusy { get; set; }
        public Employee EmployeeItem { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string IpAddress { get; set; }

        public EmployeeDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Employee Detail View";
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("employeeItem"))
            {
                var result = await Task.Run(() => EmployeeItem = (Employee)parameters["employeeItem"]);
                FirstName = result.FirstName;
                LastName = result.LastName;
                Department = result.Department;
                IpAddress = result.IpAddress;
                Email = result.Email;
            }
        }
    }
}
