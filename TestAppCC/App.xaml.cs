using TestAppCC.ViewModels;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using TestAppCC.Views.Employees;
using TestAppCC.ViewModels.Employees;

namespace TestAppCC
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeePage, EmployeeViewModel>();
            containerRegistry.RegisterForNavigation<EmployeeDetailPage, EmployeeDetailViewModel>();
        }
    }
}
