using Acr.UserDialogs;
using AppPokeApi.Models;
using PKCore.APIService;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppPokeApi.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        public INavigationService navigationService { get; set; }

        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        private string _pass;

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public DelegateCommand btninicioSesion { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IRestAPIServices restApiService)
            :base(navigationService, restApiService)
        {
            btninicioSesion = new DelegateCommand(IniciarSesion);
        }

        private async void IniciarSesion()
        {
            User user = new User();
            user.correo = Correo;
            user.password = Pass;
            if (Correo == "pokemon@gmail.com" && Pass == "poke123")
            {
                await NavigationService.NavigateAsync(new Uri("CA:///NavigationPage/MainPage", UriKind.Absolute));
            }
            else
            {
                UserDialogs.Instance.Alert("Correo o contraseña invalida, favor de verificar", "Error", "Aceptar");
            }
        }
    }
}
