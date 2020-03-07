using Prism;
using Prism.Ioc;
using AppPokeApi.ViewModels;
using AppPokeApi.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PKCore.APIService;
using Acr.UserDialogs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppPokeApi
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Servicios RestApiService
            containerRegistry.RegisterInstance<IRestAPIServices>(new RestApiService());
            //Servicio ACR Dialogs
            containerRegistry.RegisterInstance(UserDialogs.Instance);

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
